using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class MazeReseter : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        var maze = FindObjectOfType<Maze>();
        maze.ReloadMap();
    }

    
}
