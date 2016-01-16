using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class MazeReseter : MonoBehaviour
{
    private Maze maze;

    // Use this for initialization
    void Start()
    {
        maze = FindObjectOfType<Maze>();
        maze.ReloadMap();
    }

    void OnDisable()
    {
       maze.ClearMaze();
    }

    void OnEnable()
    {
        if (maze != null)
            maze.ReloadMap();
    }
}
