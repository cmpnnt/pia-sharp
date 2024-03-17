using Cmpnnt.Pia.Ctl.Lib.Results;

namespace Cmpnnt.Pia.Ctl.Lib;

public interface ICommandLineWrapper
{
    ///  <summary>
    ///  Invokes piactl with the specified command. Conforms to <see cref="ExecuteDelegate"/> 
    ///  </summary>
    ///  <param name="command">The CLI command to be passed to piactl.</param>
    ///  <param name="options">The options to configure PiaCtl.</param>
    ///  <param name="ct">A cancellation token.</param>
    ///  <returns>A `Task&lt;PiaResults&gt;` containing standard output and standard error results.</returns>
    Task<PiaResults> Execute(string command, PiaCtlOptions options, CancellationToken ct = default);

    /// <summary>
    /// Invokes piactl with the specified command and keeps the it running for a given time. Unless the command errors,
    /// this method will return success when the timeout expires. Conforms to <see cref="ExecuteTimedDelegate"/> 
    /// </summary>
    /// <param name="command">The CLI command to be passed to piactl.</param>
    /// <param name="options">The options to configure PiaCtl.</param>
    /// <param name="timeout">The time, in seconds, after which to cancel the task.</param>
    /// <returns>A `Task&lt;PiaResults&gt;` containing standard output and standard error results.</returns>
    Task<PiaResults> ExecuteTimed(uint timeout, string command, PiaCtlOptions options);
}