

using System;
using UnityEngine;

public enum LogTypes
{
    Log, Warning, Error, Other
}

public static class ErrorLogs
{
    public static void LogErrorInConsole(string log, LogTypes lType)
    {
        switch (lType)
        {
            case LogTypes.Log:
                Debug.Log(log);
                break;
            case LogTypes.Warning:
                Debug.LogWarning(log);
                break;
            case LogTypes.Error:
                Debug.LogError(log);
                break;
            default:
                throw new Exception($"Unhandled Log Type {lType} in Assets/Scripts/ErrorHandling/ErrorLogs");
                break;
        }
    }
}
