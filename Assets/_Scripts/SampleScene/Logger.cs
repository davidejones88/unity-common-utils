using UnityEngine;
using UnityToolBox.Utils;

public class Logger : Singleton<Logger>
{
    public void LogMessage()
    {
        Debug.Log("Singleton log message");
    }
}
