using Cmpnnt.Pia.Ctl.Enums;
using Cmpnnt.Pia.Ctl.Lib;
using Cmpnnt.Pia.Ctl.Lib.Results;

namespace Cmpnnt.Pia.Ctl;

/// <summary>
/// A convenience class to call the commands available in the piactl command line application.
/// The methods are all asynchronous despite not using the `async` suffix.
/// </summary>
public class PiaCtl
{

    private readonly PiaCtlOptions _piaCtlOptions;
    private readonly ICommandLineWrapper _commandLineWrapper;
    private readonly CommandRunner _commandRunner;

    /// <summary>
    /// Allows options and a a <see cref="CommandLineWrapper"/> implementation to be set during construction.</summary>
    /// <param name="piaCtlOptions">The options to configure </param>
    /// <param name="commandLineWrapper">A wrapper around the system's command line interface. The methods defined
    /// in this interface match <see cref="ExecuteDelegate">ExecuteDelegate</see> and <see cref="ExecuteTimedDelegate">ExecuteTimedDelegate</see></param>
    public PiaCtl(PiaCtlOptions piaCtlOptions, ICommandLineWrapper commandLineWrapper)
    {
        _piaCtlOptions = piaCtlOptions;
        _commandLineWrapper = commandLineWrapper;
        _commandRunner = new CommandRunner();
    }
    
    /// <summary>
    /// Allows a <see cref="CommandLineWrapper"/> implementation to be set during construction.
    /// </summary>
    /// <param name="commandLineWrapper" />A wrapper around the system's command line interface. The methods defined
    /// in this interface match <see cref="ExecuteDelegate" /> and <see cref="ExecuteTimedDelegate" />/param>
    public PiaCtl(ICommandLineWrapper commandLineWrapper)
    {
        _piaCtlOptions = new PiaCtlOptions();
        _commandLineWrapper = commandLineWrapper;
        _commandRunner = new CommandRunner();
    }
    
    /// <summary>
    /// Allows options to be set during construction.
    /// </summary>
    /// <param name="piaCtlOptions"></param>
    public PiaCtl(PiaCtlOptions piaCtlOptions)
    {
        _piaCtlOptions = piaCtlOptions;
        _commandLineWrapper = new CommandLineWrapper();
        _commandRunner = new CommandRunner();
    }
    
    /// <summary>
    /// The default constructor.
    /// </summary>
    public PiaCtl()
    {
        _piaCtlOptions = new PiaCtlOptions();
        _commandLineWrapper = new CommandLineWrapper();
        _commandRunner = new CommandRunner();
    }

    //Connection
    
    /// <summary>
    /// Connects to the VPN, or reconnects to apply new settings. To use this command, the PIA GUI client must
    /// be running, or background mode must be enabled with `piactl background enable`. By default, the PIA daemon
    /// is inactive when the GUI client is not running. This is an `async` method.
    /// </summary>
    /// <param name="debug">Prints debug logs to stderr.</param>
    /// <returns>A `Task&lt;PiaResults&gt;` containing standard output and standard error results.</returns>
    public async Task<PiaResults> Connect(bool debug = false)
    {
        return await _commandRunner.Run(
                _commandLineWrapper.Execute, 
                Command.Connect, 
                DaemonAction.None, 
                _piaCtlOptions, 
                debug)
            .ConfigureAwait(false);
    }
    
    /// <summary>
    /// Logs into Private Internet Access using a login file. This is an `async` method.
    /// </summary>
    /// <param name="loginFilePath">The path to the text file containing your login information as specified by `piactl.exe --help`.</param>
    /// <param name="debug">Prints debug logs to stderr.</param>
    /// <returns>A `Task&lt;PiaResults&gt;` containing standard output and standard error results.</returns>
    public async Task<PiaResults> Login(string loginFilePath, bool debug = false)
    {
        return await _commandRunner.Run(
                _commandLineWrapper.Execute, 
                Command.Login,
                DaemonAction.None,
                loginFilePath,
                _piaCtlOptions,
                debug)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Disconnects from the VPN. This is an `async` method.
    /// </summary>
    /// <param name="debug">Prints debug logs to stderr.</param>
    /// <returns>A `Task&lt;PiaResults&gt;` containing standard output and standard error results.</returns>
    public async Task<PiaResults> Disconnect(bool debug = false)
    {
        return await _commandRunner.Run(
                _commandLineWrapper.Execute, 
                Command.Disconnect, 
                DaemonAction.None, 
                _piaCtlOptions, 
                debug)
            .ConfigureAwait(false);
    }
    
    /// <summary>
    /// Log out your PIA account on this computer. This is an `async` method.
    /// </summary>
    /// <param name="debug">Prints debug logs to stderr.</param>
    /// <returns>A `Task&lt;PiaResults&gt;` containing standard output and standard error results.</returns>
    public async Task<PiaResults> Logout(bool debug = false)
    {
        return await _commandRunner.Run(
                _commandLineWrapper.Execute, 
                Command.Logout, 
                DaemonAction.None, 
                _piaCtlOptions, 
                debug)
            .ConfigureAwait(false);
    }
    
    /// <summary>
    /// Resets daemon settings to the defaults (ports/protocols/etc). This affects the PIA daemon itself,
    /// not this instance of the CLI wrapper. This is an `async` method.
    /// </summary>
    /// <param name="debug">Prints debug logs to stderr.</param>
    /// <returns>A `Task&lt;PiaResults&gt;` containing standard output and standard error results.</returns>
    public async Task<PiaResults> ResetSettings(bool debug = false)
    {
        return await _commandRunner.Run(
                _commandLineWrapper.Execute, 
                Command.ResetSettings, 
                DaemonAction.None, 
                _piaCtlOptions, 
                debug)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Adds a dedicated IP address to your VPN. The dedicated IP token must be in a text file by itself. This is an `async` method.
    /// </summary>
    /// <param name="tokenFilePath">The path to the text file containing your dedicated IP token.</param>
    /// <param name="debug">Prints debug logs to stderr.</param>
    /// <returns>A `Task&lt;PiaResults&gt;` containing standard output and standard error results.</returns>
    //Dedicated IP
    public async Task<PiaResults> AddDedicatedIp(string tokenFilePath, bool debug = false)
    {
        return await _commandRunner.Run(
                _commandLineWrapper.Execute, 
                Command.DedicatedIp,
                DaemonAction.None,
                "add",
                tokenFilePath,
                _piaCtlOptions,
                debug)
            .ConfigureAwait(false);
    }
    
    /// <summary>
    /// Removes a dedicated IP address from your VPN. This is an `async` method.
    /// </summary>
    /// <param name="regionId">The region associated with the dedicated IP as shown by the method `GetRegions()`
    /// or `piactl.exe get regions`</param>
    /// <param name="debug">Prints debug logs to stderr.</param>
    /// <returns>A `Task&lt;PiaResults&gt;` containing standard output and standard error results.</returns>
    public async Task<PiaResults> RemoveDedicatedIp(string regionId, bool debug = false)
    {
        return await _commandRunner.Run(
                _commandLineWrapper.Execute, 
                Command.DedicatedIp,
                DaemonAction.None,
                "remove",
                regionId,
                _piaCtlOptions,
                debug)
            .ConfigureAwait(false);
    }

    //Background
    
    /// <summary>
    /// Allow the killswitch and/or VPN connection to remain active in the background when the GUI client is not running.
    /// When enabled, the PIA daemon will stay active even if the GUI client is closed or has not been started. This
    /// allows `Connection.Connect()` to be used even if the GUI client is not running. Disabling background activation
    /// will disconnect the VPN and deactivate killswitch if the GUI client is not running. This is an `async` method.
    /// </summary>
    /// <param name="debug">Prints debug logs to stderr.</param>
    /// <returns>A `Task&lt;PiaResults&gt;` containing standard output and standard error results.</returns>
    public async Task<PiaResults> BackgroundEnable(bool debug = false)
    {
        return await _commandRunner.Run(
                _commandLineWrapper.Execute, 
                Command.Background,
                DaemonAction.None,
                "enable",
                _piaCtlOptions,
                debug)
            .ConfigureAwait(false);
    }
    
    /// <summary>
    /// Foregrounds a backgrounded PIA daemon. This is an `async` method.
    /// </summary>
    /// <param name="debug">Prints debug logs to stderr.</param>
    /// <returns>A `Task&lt;PiaResults&gt;` containing standard output and standard error results.</returns>
    public async Task<PiaResults> BackgroundDisable(bool debug = false)
    {
        return await _commandRunner.Run(
                _commandLineWrapper.Execute, 
                Command.Background,
                DaemonAction.None,
                "disable",
                _piaCtlOptions,
                debug)
            .ConfigureAwait(false);
    }
    
    // Set
    
    /// <summary>
    /// Sets whether to allow LAN traffic. This is an `async` method.
    /// </summary>
    /// <param name="value">Whether or not to allow LAN traffic.</param>
    /// <param name="debug">Prints debug logs to stderr.</param>
    /// <returns>A `Task&lt;PiaResults&gt;` containing standard output and standard error results.</returns>
    public async Task<PiaResults> SetAllowLan(bool value, bool debug = false)
    {
        return await _commandRunner.Run(
                _commandLineWrapper.Execute, 
                Command.Set,
                DaemonAction.AllowLan,
                value,
                _piaCtlOptions,
                debug)
            .ConfigureAwait(false);
    }
    
    /// <summary>
    /// Sets whether to enable or disable debug logging. This is an `async` method.
    /// </summary>
    /// <param name="value">Whether or not to enable debug logging.</param>
    /// <param name="debug">Prints debug logs to stderr.</param>
    /// <returns>A `Task&lt;PiaResults&gt;` containing standard output and standard error results.</returns>
    public async Task<PiaResults> SetDebugLogging(bool value, bool debug = false)
    {
        return await _commandRunner.Run(
                _commandLineWrapper.Execute, 
                Command.Set,
                DaemonAction.DebugLogging,
                value,
                _piaCtlOptions,
                debug)
            .ConfigureAwait(false);
    }
    
    /// <summary>
    /// Sets the VPN protocol. This is an `async` method.
    /// </summary>
    /// <param name="value">The VPN protocol to use. Must be one of "openvpn" or "wireguard".</param>
    /// <param name="debug">Prints debug logs to stderr.</param>
    /// <returns>A `Task&lt;PiaResults&gt;` containing standard output and standard error results.</returns>
    public async Task<PiaResults> SetProtocol(string value, bool debug = false)
    {
        return await _commandRunner.Run(
                _commandLineWrapper.Execute, 
                Command.Set,
                DaemonAction.Protocol,
                value,
                _piaCtlOptions,
                debug)
            .ConfigureAwait(false);
    }
    
    /// <summary>
    /// Sets the VPN region. This is an `async` method.
    /// </summary>
    /// <param name="value">A valid region or "auto". Run the method `GetRegions()` for a list of regions.</param>
    /// <param name="debug">Prints debug logs to stderr.</param>
    /// <returns>A `Task&lt;PiaResults&gt;` containing standard output and standard error results.</returns>
    public async Task<PiaResults> SetRegion(string value, bool debug = false)
    {
        return await _commandRunner.Run(
                _commandLineWrapper.Execute, 
                Command.Set, 
                DaemonAction.Region, 
                value, 
                _piaCtlOptions, 
                debug)
            .ConfigureAwait(false);
    }
    
    /// <summary>
    /// Sets whether to request a forwarded port on the next connection attempt. This is an `async` method.
    /// </summary>
    /// <param name="value">Whether or not to request port forwarding.</param>
    /// <param name="debug">Prints debug logs to stderr.</param>
    /// <returns>A `Task&lt;PiaResults&gt;` containing standard output and standard error results.</returns>
    public async Task<PiaResults> SetRequestPortForward(bool value, bool debug = false)
    {
        return await _commandRunner.Run(
                _commandLineWrapper.Execute, 
                Command.Set,
                DaemonAction.RequestPortForward,
                value,
                _piaCtlOptions,
                debug)
            .ConfigureAwait(false);
    }
    
    //Get
    
    /// <summary>
    /// Gets whether allows LAN traffic. This is an `async` method.
    /// </summary>
    /// <param name="debug">Prints debug logs to stderr.</param>
    /// <returns>A `Task&lt;PiaResults&gt;` containing standard output and standard error results.</returns>
    public async Task<PiaResults> GetAllowLan(bool debug = false)
    {
        return await _commandRunner.Run(
                _commandLineWrapper.Execute, 
                Command.Get, 
                DaemonAction.AllowLan, 
                _piaCtlOptions, 
                debug)
            .ConfigureAwait(false);
    }
    
    /// <summary>
    /// Gets the current VPN connection state. This is an `async` method.
    /// </summary>
    /// <param name="debug">Prints debug logs to stderr.</param>
    /// <returns>A `Task&lt;PiaResults&gt;` containing standard output and standard error results.</returns>
    public async Task<PiaResults> GetConnectionState(bool debug = false)
    {
        return await _commandRunner.Run(
                _commandLineWrapper.Execute, 
                Command.Get, 
                DaemonAction.ConnectionState,
                _piaCtlOptions, 
                debug)
            .ConfigureAwait(false);
    }
    
    /// <summary>
    /// Gets the current state of the debug logging setting. This is an `async` method.
    /// </summary>
    /// <param name="debug">Prints debug logs to stderr.</param>
    /// <returns>A `Task&lt;PiaResults&gt;` containing standard output and standard error results.</returns>
    public async Task<PiaResults> GetDebugLogging(bool debug = false)
    {
        return await _commandRunner.Run(
                _commandLineWrapper.Execute, 
                Command.Get, 
                DaemonAction.DebugLogging, 
                _piaCtlOptions, 
                debug)
            .ConfigureAwait(false);
    }
    
    /// <summary>
    /// Gets the forward port number, if available, or the status of the request to forward a port. This is an `async` method.
    /// </summary>
    /// <param name="debug">Prints debug logs to stderr.</param>
    /// <returns>A `Task&lt;PiaResults&gt;` containing standard output and standard error results.</returns>
    public async Task<PiaResults> GetPortForward(bool debug = false)
    {
        return await _commandRunner.Run(
                _commandLineWrapper.Execute, 
                Command.Get, 
                DaemonAction.PortForward, 
                _piaCtlOptions, 
                debug)
            .ConfigureAwait(false);
    }
    
    /// <summary>
    /// Gets the current VPN connection protocol. This is an `async` method.
    /// </summary>
    /// <param name="debug">Prints debug logs to stderr.</param>
    /// <returns>A `Task&lt;PiaResults&gt;` containing standard output and standard error results.</returns>
    public async Task<PiaResults> GetProtocol(bool debug = false)
    {
        return await _commandRunner.Run(
                _commandLineWrapper.Execute, 
                Command.Get, 
                DaemonAction.Protocol, 
                _piaCtlOptions, 
                debug)
            .ConfigureAwait(false);
    }
    
    /// <summary>
    /// Gets the current public IP address. This is an `async` method.
    /// </summary>
    /// <param name="debug">Prints debug logs to stderr.</param>
    /// <returns>A `Task&lt;PiaResults&gt;` containing standard output and standard error results.</returns>
    public async Task<PiaResults> GetPubIp(bool debug = false)
    {
        return await _commandRunner.Run(
                _commandLineWrapper.Execute, 
                Command.Get, 
                DaemonAction.PubIp, 
                _piaCtlOptions, 
                debug)
            .ConfigureAwait(false);
    }
    
    /// <summary>
    /// Gets the currently selected region (or "auto"). This is an `async` method.
    /// </summary>
    /// <param name="debug">Prints debug logs to stderr.</param>
    /// <returns>A `Task&lt;PiaResults&gt;` containing standard output and standard error results.</returns>
    public async Task<PiaResults> GetRegion(bool debug = false)
    {
        return await _commandRunner.Run(
                _commandLineWrapper.Execute, 
                Command.Get, 
                DaemonAction.Region, 
                _piaCtlOptions, 
                debug)
            .ConfigureAwait(false);
    }
    
    /// <summary>
    /// Lists all available regions. This is an `async` method.
    /// </summary>
    /// <param name="debug">Prints debug logs to stderr.</param>
    /// <returns>A `Task&lt;PiaResults&gt;` containing standard output and standard error results.</returns>
    public async Task<PiaResults> GetRegions(bool debug = false)
    {
        return await _commandRunner.Run(
                _commandLineWrapper.Execute, 
                Command.Get, 
                DaemonAction.Regions, 
                _piaCtlOptions, 
                debug)
            .ConfigureAwait(false);
    }
    
    /// <summary>
    /// Gets whether a forwarded port will be requested on the next connection attempt. This is an `async` method.
    /// </summary>
    /// <param name="debug">Prints debug logs to stderr.</param>
    /// <returns>A `Task&lt;PiaResults&gt;` containing standard output and standard error results.</returns>
    public async Task<PiaResults> GetRequestPortForward(bool debug = false)
    {
        return await _commandRunner.Run(
                _commandLineWrapper.Execute, 
                Command.Get, 
                DaemonAction.RequestPortForward, 
                _piaCtlOptions, 
                debug)
            .ConfigureAwait(false);
    }
    
    /// <summary>
    /// Gets the current VPN IP address. This is an `async` method.
    /// </summary>
    /// <param name="debug">Prints debug logs to stderr.</param>
    /// <returns>A `Task&lt;PiaResults&gt;` containing standard output and standard error results.</returns>
    public async Task<PiaResults> GetVpnIp(bool debug = false)
    {
        return await _commandRunner.Run(
                _commandLineWrapper.Execute,
                Command.Get, 
                DaemonAction.VpnIp, 
                _piaCtlOptions, 
                debug)
            .ConfigureAwait(false);
    }
    
    //Monitor
    
    /// <summary>
    /// Monitors whether LAN traffic is being allowed. This is an `async` method.
    /// </summary>
    /// <param name="timeout">A (non-negative) integer number of seconds to run the monitor operation.</param>
    /// <param name="debug">Prints debug logs to stderr.</param>
    /// <returns>A `Task&lt;PiaResults&gt;` containing standard output and standard error results.</returns>
    public async Task<PiaResults> MonitorAllowLan(uint timeout, bool debug = false)
    {
        return await _commandRunner.Run(
                _commandLineWrapper.ExecuteTimed, 
                Command.Monitor,
                DaemonAction.AllowLan,
                timeout,
                _piaCtlOptions,
                debug)
            .ConfigureAwait(false);
    }
    
    /// <summary>
    /// Monitors the VPN connection state. This is an `async` method.
    /// </summary>
    /// <param name="timeout">A (non-negative) integer number of seconds to run the monitor operation.</param>
    /// <param name="debug">Prints debug logs to stderr.</param>
    /// <returns>A `Task&lt;PiaResults&gt;` containing standard output and standard error results.</returns>
    public async Task<PiaResults> MonitorConnectionState(uint timeout, bool debug = false)
    {
        return await _commandRunner.Run(
                _commandLineWrapper.ExecuteTimed, 
                Command.Monitor,
                DaemonAction.ConnectionState,
                timeout,
                _piaCtlOptions,
                debug)
            .ConfigureAwait(false);
    }
    
    /// <summary>
    /// Monitors the state of the debug logging setting. This is an `async` method.
    /// </summary>
    /// <param name="timeout">A (non-negative) integer number of seconds to run the monitor operation.</param>
    /// <param name="debug">Prints debug logs to stderr.</param>
    /// <returns>A `Task&lt;PiaResults&gt;` containing standard output and standard error results.</returns>
    public async Task<PiaResults> MonitorDebugLogging(uint timeout, bool debug = false)
    {
        return await _commandRunner.Run(
                _commandLineWrapper.ExecuteTimed, 
                Command.Monitor,
                DaemonAction.DebugLogging,
                timeout,
                _piaCtlOptions,
                debug)
            .ConfigureAwait(false);
    }
    
    /// <summary>
    /// Monitors the forwarded port number, if available, or the status of the request to forward a port. This is an `async` method.
    /// </summary>
    /// <param name="timeout">A (non-negative) integer number of seconds to run the monitor operation.</param>
    /// <param name="debug">Prints debug logs to stderr.</param>
    /// <returns>A `Task&lt;PiaResults&gt;` containing standard output and standard error results.</returns>
    public async Task<PiaResults> MonitorPortForward(uint timeout, bool debug = false)
    {
        return await _commandRunner.Run(
                _commandLineWrapper.ExecuteTimed, 
                Command.Monitor,
                DaemonAction.PortForward,
                timeout,
                _piaCtlOptions,
                debug)
            .ConfigureAwait(false);
    }
    
    /// <summary>
    /// Monitors the VPN connection protocol. This is an `async` method.
    /// </summary>
    /// <param name="timeout">A (non-negative) integer number of seconds to run the monitor operation.</param>
    /// <param name="debug">Prints debug logs to stderr.</param>
    /// <returns>A `Task&lt;PiaResults&gt;` containing standard output and standard error results.</returns>
    public async Task<PiaResults> MonitorProtocol(uint timeout, bool debug = false)
    {
        return await _commandRunner.Run(
                _commandLineWrapper.ExecuteTimed, 
                Command.Monitor,
                DaemonAction.Protocol,
                timeout,
                _piaCtlOptions,
                debug)
            .ConfigureAwait(false);
    }
    
    /// <summary>
    /// Monitors the public IP address. This is an `async` method.
    /// </summary>
    /// <param name="timeout">A (non-negative) integer number of seconds to run the monitor operation.</param>
    /// <param name="debug">Prints debug logs to stderr.</param>
    /// <returns>A `Task&lt;PiaResults&gt;` containing standard output and standard error results.</returns>
    public async Task<PiaResults> MonitorPubIp(uint timeout, bool debug = false)
    {
        return await _commandRunner.Run(
                _commandLineWrapper.ExecuteTimed, 
                Command.Monitor,
                DaemonAction.PubIp,
                timeout,
                _piaCtlOptions,
                debug)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Monitors the currently selected region. This is an `async` method.
    /// </summary>
    /// <param name="timeout">A (non-negative) integer number of seconds to run the monitor operation.</param>
    /// <param name="debug">Prints debug logs to stderr.</param>
    /// <returns>A `Task&lt;PiaResults&gt;` containing standard output and standard error results.</returns>
    public async Task<PiaResults> MonitorRegion(uint timeout, bool debug = false)
    {
        return await _commandRunner.Run(
                _commandLineWrapper.ExecuteTimed, 
                Command.Monitor,
                DaemonAction.Region,
                timeout,
                _piaCtlOptions,
                debug)
            .ConfigureAwait(false);
    }
    
    /// <summary>
    /// Monitors whether a forwarded port will be requested on the next connection attempt. This is an `async` method.
    /// </summary>
    /// <param name="timeout">A (non-negative) integer number of seconds to run the monitor operation.</param>
    /// <param name="debug">Prints debug logs to stderr.</param>
    /// <returns>A `Task&lt;PiaResults&gt;` containing standard output and standard error results.</returns>
    public async Task<PiaResults> MonitorRequestPortForward(uint timeout, bool debug = false)
    {
        return await _commandRunner.Run(
                _commandLineWrapper.ExecuteTimed,
                Command.Monitor,
                DaemonAction.RequestPortForward,
                timeout,
                _piaCtlOptions,
                debug)
            .ConfigureAwait(false);
    }
    
    /// <summary>
    /// Monitors the VPN IP address. This is an `async` method.
    /// </summary>
    /// <param name="timeout">A (non-negative) integer number of seconds to run the monitor operation.</param>
    /// <param name="debug">Prints debug logs to stderr.</param>
    /// <returns>A `Task&lt;PiaResults&gt;` containing standard output and standard error results.</returns>
    public async Task<PiaResults> MonitorVpnIp(uint timeout, bool debug = false)
    {
        return await _commandRunner.Run(
                _commandLineWrapper.ExecuteTimed, 
                Command.Monitor,
                DaemonAction.VpnIp,
                timeout,
                _piaCtlOptions,
                debug)
            .ConfigureAwait(false);
    }
}