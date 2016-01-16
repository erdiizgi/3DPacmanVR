using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public HeroController Hero;
    public Maze Maze;
    public int CreatedPills;
    public LevelController LevelControllerObject;


    // Use this for initialization
    void Start()
    {
        LevelControllerObject = FindObjectOfType<LevelController>();
        Maze.useLevel = LevelControllerObject.GetCurrent();
        Maze.ReloadMap();
    }

    // Update is called once per frame
    void Update()
    {
        if (Hero.Score == CreatedPills)
            LevelControllerObject.LoadNextLevel();
    }
}
