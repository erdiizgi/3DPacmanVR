using UnityEngine;

public class GameController : MonoBehaviour
{

    public HeroController Hero;
    public Maze Maze;

	// Use this for initialization
	void Start ()
	{
	    Maze.ReloadMap();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
