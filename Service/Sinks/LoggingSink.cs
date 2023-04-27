﻿namespace Tellurian.Trains.ClockPulseApp.Service.Sinks;

public sealed class LoggingSink : IPulseSink, IStatusSink, IControlSink, IAnalogueClockStatus
{
    public LoggingSink(ILogger logger) => Logger = logger ?? throw new ArgumentNullException(nameof(logger));

    private readonly ILogger Logger;
    public Task NegativeVoltageAsync()
    {
        Logger.LogInformation("\x1B[1m\x1B[31mNegative voltage\x1B[39m\x1B[22m");
        return Task.CompletedTask;
    }

    public Task PositiveVoltageAsync()
    {
        Logger.LogInformation("\x1B[1m\x1B[32mPositive voltage\x1B[39m\x1B[22m");
        return Task.CompletedTask;
    }

    public Task ZeroVoltageAsync()
    {
        Logger.LogInformation("\x1B[1m\x1B[36mZero voltage\x1B[39m\x1B[22m");
        return Task.CompletedTask;
    }

    public Task InitializeAsync(TimeOnly analogueTime)
    {
        Logger.LogInformation("Initialized logging sink with analogue time {time:T}.", analogueTime);
        return Task.CompletedTask;
    }

    public Task CleanupAsync()
    {
        Logger.LogInformation("Cleaned up logging sink.");
        return Task.CompletedTask;
    }

    public Task ClockIsStartedAsync()
    {
        Logger.LogInformation("Clock was \x1B[1m\x1B[32mstarted\x1B[39m\x1B[22m.");
        return Task.CompletedTask;
    }
    public Task ClockIsStoppedAsync()
    {
        Logger.LogInformation("Clock was \x1B[1m\x1B[31mstopped\x1B[39m\x1B[22m.");
        return Task.CompletedTask;
    }

    public Task AnalogueClocksAreFastForwardingAsync()
    {
        Logger.LogInformation("Clock was starting fast forwarding.");
        return Task.CompletedTask;
    }

    public Task AnalogueClocksStoppedFastForwardingAsync()
    {
        Logger.LogInformation("Clock was stopping fast forwarding.");
        return Task.CompletedTask;
    }
}
