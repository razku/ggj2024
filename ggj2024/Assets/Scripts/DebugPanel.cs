using UnityEngine;
using System.Collections.Generic;

public class DebugPanel : MonoBehaviour
{
    private static DebugPanel instance;

    private Dictionary<string, object> debugValues = new Dictionary<string, object>();

    public static DebugPanel Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<DebugPanel>();

                if (instance == null)
                {
                    GameObject obj = new GameObject("DebugPanel");
                    instance = obj.AddComponent<DebugPanel>();
                }
            }
            return instance;
        }
    }

    public void SetDebugValue(string key, ref object value)
    {
        debugValues[key] = value;
    }

    public void RemoveDebugValue(string key)
    {
        if (debugValues.ContainsKey(key))
        {
            debugValues.Remove(key);
        }
    }

    void OnGUI()
    {
        GUILayout.BeginArea(new Rect(10, 10, 200, 200));

        foreach (var entry in debugValues)
        {
            GUILayout.Label(entry.Key + ": " + entry.Value.ToString());
        }

        GUILayout.EndArea();
    }
}
