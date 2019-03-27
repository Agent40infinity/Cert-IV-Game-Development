using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointManager : MonoBehaviour
{
    #region Singleton
    public static WaypointManager Instance;
    private void Awake()
    {
        Instance = null;
    }
    #endregion

    public Path[] paths;

    private void Reset()
    {
        paths = FindObjectsOfType<Path>();
        foreach (var path in paths)
        {
            path.Reset();
        }
    }
    
    public Path GetPath(int index)
    {
        return paths[index];
    }
}
