using System.Diagnostics;
using Cmpnnt.Pia.Ctl.Enums;
using Cmpnnt.Pia.Ctl.Lib.Results;

namespace Cmpnnt.Pia.Ctl.Lib;


/// <summary>
/// Wraps the system console, invokes the piactl executable and captures the output.
/// </summary>
public class CommandLineWrapper : ICommandLineWrapper
{

    ///  <summary>
    ///  Invokes piactl with the specified command. Conforms to <see cref="ExecuteDelegate"/> 
    ///  </summary>
    ///  <param name="command">The CLI command to be passed to piactl</param>
    ///  <param name="options">The options to configure PiaCtl.</param>
    ///  <param name="ct">A cancellation token.</param>
    ///  <returns>A `Task&lt;PiaResults&gt;` containing standard output and standard error results.</returns>
    public async Task<PiaResults> Execute(string command, PiaCtlOptions options, CancellationToken ct = default)
    {
        using var proc = new Process
        {
            StartInfo =
            {
                FileName = options.PiaPath,
                Arguments = command,
                CreateNoWindow = true,
                UseShellExecute = false,
                RedirectStandardError = true,
                RedirectStandardOutput = true,
            }
        };
        
        // Set as completed first and change later if necessary
        PiaResults piaResults = new(){Status = Status.Completed};
        
        proc.OutputDataReceived += (_, e) =>
        {
            if (!string.IsNullOrEmpty(e.Data))
            {
                piaResults.StandardOutputResults?.Add(e.Data.Trim());
            }
        };
        
        proc.ErrorDataReceived += (_, e) =>
        {
            if (!string.IsNullOrEmpty(e.Data))
            {
                piaResults.StandardErrorResults?.Add(e.Data.Trim());
                piaResults.Status = Status.Error;
            }
        };

        proc.Start();

        // Asynchronously read the standard output of the spawned process.
        // This raises OutputDataReceived events for each line of output.
        proc.BeginOutputReadLine();
        proc.BeginErrorReadLine();

        try
        {
            await proc.WaitForExitAsync(ct);
        }
        catch (OperationCanceledException)
        {
            // Process always throws this exception when the token is canceled
            // Assume if ct was passed in and the operation was canceled, it was via `ExecuteTimed()` below (therefore successful)
            piaResults.Status = ct == default ? Status.Completed : Status.Canceled;
        }
        catch (Exception)
        {
            piaResults.Status = Status.Error;
        }
        finally
        {
            proc.Close();
        }
        
        return piaResults;
    }

    /// <summary>
    /// Invokes piactl with the specified command and keeps the it running for a given time. Unless the command errors,
    /// this method will return success when the timeout expires. Conforms to <see cref="ExecuteTimedDelegate"/> 
    /// </summary>
    /// <param name="command">The CLI command to be passed to piactl</param>
    /// <param name="options">The options to configure PiaCtl.</param>
    /// <param name="timeout">The time, in seconds, after which to cancel the task</param>
    /// <returns>A `Task&lt;PiaResults&gt;` containing standard output and standard error results.</returns>
    public async Task<PiaResults> ExecuteTimed(uint timeout, string command, PiaCtlOptions options)
    {
        CancellationTokenSource cts = new();
        cts.CancelAfter(TimeSpan.FromSeconds(timeout));
        CancellationToken ct = cts.Token;

        PiaResults results = await Execute(command, options, ct: ct);
        return results;
    }
}