using Cmpnnt.Pia.Ctl.Enums;
using Cmpnnt.Pia.Ctl.Lib.Results;

namespace Cmpnnt.Pia.Ctl.Lib;

public interface ICommandRunner
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
    Task<PiaResults> Run(ExecuteDelegate execute, Command command, DaemonAction action, PiaCtlOptions options, bool debug = false);

    /// <summary>
    /// Formats and executes a `piactl` command line command.
    /// </summary>
    /// <param name="execute">A delegate representing the process call to execute the `piactl` command line utility</param>
    /// <param name="command">A Command enum value representing a top-level piactl command.</param>
    /// <param name="action">A DaemonAction enum value representing a specific action to be taken by the PIA daemon.</param>
    /// <param name="argument">A string argument to be passed to the piactl daemon.</param>
    /// <param name="options">The options to configure PiaCtl.</param>
    /// <param name="debug">Print debug logs to stderr.</param>
    ///  <returns>A `Task&lt;PiaResults&gt;` containing standard output and standard error results.</returns>
    Task<PiaResults> Run(ExecuteDelegate execute, Command command, DaemonAction action, string argument, PiaCtlOptions options, bool debug = false);

    /// <summary>
    /// Formats and executes a `piactl` command line command.
    /// </summary>
    /// <param name="execute">A delegate representing the process call to execute the `piactl` command line utility</param>
    /// <param name="command">A Command enum value representing a top-level piactl command.</param>
    /// <param name="action">A DaemonAction enum value representing a specific action to be taken by the PIA daemon.</param>
    /// <param name="argument1">A string argument to be passed to the piactl daemon.</param>
    /// <param name="argument2">A string argument to be passed to the piactl daemon.</param>
    /// <param name="options">The options to configure PiaCtl.</param>
    /// <param name="debug">Print debug logs to stderr.</param>
    ///  <returns>A `Task&lt;PiaResults&gt;` containing standard output and standard error results.</returns>
    Task<PiaResults> Run(ExecuteDelegate execute, Command command, DaemonAction action, string argument1, string argument2, PiaCtlOptions options, bool debug = false);

    /// <summary>
    /// Formats and executes a `piactl` command line command.
    /// </summary>
    /// <param name="execute">A delegate representing the process call to execute the `piactl` command line utility</param>
    /// <param name="command">A Command enum value representing a top-level piactl command.</param>
    /// <param name="action">A DaemonAction enum value representing a specific action to be taken by the PIA daemon.</param>
    /// <param name="argument">A bool argument to be passed to the piactl daemon.</param>
    /// <param name="options">The options to configure PiaCtl.</param>
    /// <param name="debug">Print debug logs to stderr.</param>
    ///  <returns>A `Task&lt;PiaResults&gt;` containing standard output and standard error results.</returns>
    Task<PiaResults> Run(ExecuteDelegate execute, Command command, DaemonAction action, bool argument, PiaCtlOptions options, bool debug = false);

    /// <summary>
    /// Formats and executes a `piactl` command line command.
    /// </summary>
    /// <param name="execute">A delegate representing the process call to execute the `piactl` command line utility</param>
    /// <param name="command">A Command enum value representing a top-level piactl command.</param>
    /// <param name="action">A DaemonAction enum value representing a specific action to be taken by the PIA daemon.</param>
    /// <param name="argument">A uint argument to be passed to the Command Line Wrapper</param>
    /// <param name="options">The options to configure PiaCtl.</param>
    /// <param name="debug">Print debug logs to stderr.</param>
    ///  <returns>A `Task&lt;PiaResults&gt;` containing standard output and standard error results.</returns>
    Task<PiaResults> Run(ExecuteTimedDelegate execute, Command command, DaemonAction action, uint argument, PiaCtlOptions options, bool debug = false);
}