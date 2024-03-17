using System.Diagnostics;
using System.Text;
using Cmpnnt.Pia.Ctl.Enums;
using Cmpnnt.Pia.Ctl.Extensions;
using Cmpnnt.Pia.Ctl.Lib.Results;

namespace Cmpnnt.Pia.Ctl.Lib;

/// <summary>
/// A delegate representing a non-timed operation to be executed by the <see cref="CommandRunner"/>
/// </summary>
///  <param name="command">The CLI command to be passed to the piactl binary</param>
///  <param name="options">The options to configure PiaCtl.</param>
///  <param name="ct">A cancellation token.</param>
public delegate Task<PiaResults> ExecuteDelegate(string command, PiaCtlOptions options, CancellationToken ct = default);
    
/// <summary>
/// A delegate representing a timed operation to be executed by the <see cref="CommandRunner"/>
/// </summary>
/// <param name="command">The CLI command to be passed to the piactl binary</param>
/// <param name="options">The options to configure PiaCtl.</param>
/// <param name="timeout">The time, in seconds, after which to cancel the task</param>
public delegate Task<PiaResults> ExecuteTimedDelegate(uint timeout, string command, PiaCtlOptions options);

/// <summary>
/// Formats and executes a `piactl` command line command.
/// </summary>
public class CommandRunner : ICommandRunner
{

    /// <summary>
    /// Formats and executes a `piactl` command line command.
    /// </summary>
    /// <param name="execute">A delegate representing the process call to execute the `piactl` command line utility</param>
    /// <param name="command">A Command enum value representing a top-level piactl command.</param>
    /// <param name="action">A DaemonAction enum value representing a specific action to be taken by the PIA daemon.</param>
    /// <param name="options">A PiaCtlOptions instance.</param>
    /// <param name="debug">Print debug logs to stderr.</param>
    ///  <returns>A `Task&lt;PiaResults&gt;` containing standard output and standard error results.</returns>
    public Task<PiaResults> Run(ExecuteDelegate execute, Command command, DaemonAction action, PiaCtlOptions options, bool debug = false)
    {
        StringBuilder sb = new();

        sb.Append(command.ToStringF() + " ");

        if (action != DaemonAction.None)
        {
            sb.Append(action.ToStringF() + " ");
        }

        if (debug)
        {
            sb.Append("--debug");
        }
        
        //string cmd = debug ? $"{command.ToStringF()} {action.ToStringF()} --debug" : $"{command.ToStringF()} {action.ToStringF()}";
        return execute(sb.ToString().ToLower(), options);
    }

    /// <summary>
    /// Formats and executes a `piactl` command line command.
    /// </summary>
    /// <param name="execute">A delegate representing the process call to execute the `piactl` command line utility</param>
    /// <param name="command">A Command enum value representing a top-level piactl command.</param>
    /// <param name="action">A DaemonAction enum value representing a specific action to be taken by the PIA daemon.</param>
    /// <param name="argument">A string argument to be passed to the piactl daemon.</param>
    /// <param name="options">A PiaCtlOptions instance.</param>
    /// <param name="debug">Print debug logs to stderr.</param>
    ///  <returns>A `Task&lt;PiaResults&gt;` containing standard output and standard error results.</returns>
    public Task<PiaResults> Run(ExecuteDelegate execute, Command command, DaemonAction action, string argument, PiaCtlOptions options, bool debug = false)
    {
        StringBuilder sb = new();

        sb.Append(command.ToStringF() + " ");

        if (action != DaemonAction.None)
        {
            sb.Append(action.ToStringF() + " ");
        }
        
        sb.Append(argument + " ");

        if (debug)
        {
            sb.Append("--debug");
        }
        
        return execute(sb.ToString().ToLower(), options);
    }

    /// <summary>
    /// Formats and executes a `piactl` command line command.
    /// </summary>
    /// <param name="execute">A delegate representing the process call to execute the `piactl` command line utility</param>
    /// <param name="command">A Command enum value representing a top-level piactl command.</param>
    /// <param name="action">A DaemonAction enum value representing a specific action to be taken by the PIA daemon.</param>
    /// <param name="argument1">A string argument to be passed to the piactl daemon.</param>
    /// <param name="argument2">A string argument to be passed to the piactl daemon.</param>
    /// <param name="options">A PiaCtlOptions instance.</param>
    /// <param name="debug">Print debug logs to stderr.</param>
    ///  <returns>A `Task&lt;PiaResults&gt;` containing standard output and standard error results.</returns>
    public Task<PiaResults> Run(ExecuteDelegate execute, Command command, DaemonAction action, string argument1, string argument2, PiaCtlOptions options, bool debug = false)
    {
        StringBuilder sb = new();

        sb.Append(command.ToStringF() + " ");

        if (action != DaemonAction.None)
        {
            sb.Append(action.ToStringF() + " ");
        }
    
        sb.Append(argument1 + " ");
        sb.Append(argument2 + " ");

        if (debug)
        {
            sb.Append("--debug");
        }

        return execute(sb.ToString().ToLower(), options);
    }

    /// <summary>
    /// Formats and executes a `piactl` command line command.
    /// </summary>
    /// <param name="execute">A delegate representing the process call to execute the `piactl` command line utility</param>
    /// <param name="command">A Command enum value representing a top-level piactl command.</param>
    /// <param name="action">A DaemonAction enum value representing a specific action to be taken by the PIA daemon.</param>
    /// <param name="argument">A bool argument to be passed to the piactl daemon.</param>
    /// <param name="options">A PiaCtlOptions instance.</param>
    /// <param name="debug">Print debug logs to stderr.</param>
    ///  <returns>A `Task&lt;PiaResults&gt;` containing standard output and standard error results.</returns>
    public Task<PiaResults> Run(ExecuteDelegate execute, Command command, DaemonAction action, bool argument, PiaCtlOptions options, bool debug = false)
    {
        StringBuilder sb = new();

        sb.Append(command.ToStringF() + " ");

        if (action != DaemonAction.None)
        {
            sb.Append(action.ToStringF() + " ");
        }
        
        sb.Append(argument + " ");

        if (debug)
        {
            sb.Append("--debug");
        }

        return execute(sb.ToString().ToLower(), options);
    }

    /// <summary>
    /// Formats and executes a `piactl` command line command.
    /// </summary>
    /// <param name="execute">A delegate representing the process call to execute the `piactl` command line utility</param>
    /// <param name="command">A Command enum value representing a top-level piactl command.</param>
    /// <param name="action">A DaemonAction enum value representing a specific action to be taken by the PIA daemon.</param>
    /// <param name="argument">A uint argument to be passed to the Command Line Wrapper</param>
    /// <param name="options">A PiaCtlOptions instance.</param>
    /// <param name="debug">Print debug logs to stderr.</param>
    ///  <returns>A `Task&lt;PiaResults&gt;` containing standard output and standard error results.</returns>
    public Task<PiaResults> Run(ExecuteTimedDelegate execute, Command command, DaemonAction action, uint argument, PiaCtlOptions options, bool debug = false)
    {
        StringBuilder sb = new();

        sb.Append(command.ToStringF() + " ");

        if (action != DaemonAction.None)
        {
            sb.Append(action.ToStringF() + " ");
        }
        
        sb.Append(argument + " ");

        if (debug)
        {
            sb.Append("--debug");
        }
        
        return execute(argument, sb.ToString().ToLower(), options);
    }
}