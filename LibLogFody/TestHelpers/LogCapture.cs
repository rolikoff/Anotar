using System;
using System.Collections.Generic;
using LibLogAssembly.Logging;
using Scalpel;

[Remove]
public class LogCapture : ILogProvider, ILog
{
    public List<string> Errors = new List<string>();
    public List<string> Fatals = new List<string>();
    public List<string> Debugs = new List<string>();
    public List<string> Traces = new List<string>();
    public List<string> Informations = new List<string>();
    public List<string> Warns = new List<string>();
    public ILog GetLogger(string name)
    {
        return this;
    }

    public bool Log(LogLevel logLevel, Func<string> messageFunc)
    {
        if (messageFunc == null)
        {
            return true;
        }
        var message = messageFunc();
        if (logLevel == LogLevel.Fatal)
        {
            Fatals.Add(message);
        }
        if (logLevel == LogLevel.Error)
        {
            Errors.Add(message);
        }
        if (logLevel == LogLevel.Warn)
        {
            Warns.Add(message);
        }
        if (logLevel == LogLevel.Info)
        {
            Informations.Add(message);
        }
        if (logLevel == LogLevel.Debug)
        {
            Debugs.Add(message);
        }
        if (logLevel == LogLevel.Trace)
        {
            Traces.Add(message);
        }
        return true;   
    }

    public void Log<TException>(LogLevel logLevel, Func<string> messageFunc, TException exception) where TException : Exception
    {
        Log(logLevel, messageFunc);
    }

    public void Clear()
    {


        Fatals.Clear();
        Errors.Clear();
        Traces.Clear();
        Debugs.Clear();
        Informations.Clear();
        Warns.Clear();
    }
}