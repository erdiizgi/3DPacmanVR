using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public HeroController Hero;
    public Maze Maze;
    public int CreatedPills;


    // Use this for initialization
    void Start()
    {
        Maze.ReloadMap();
    }

    // Update is called once per frame
    void Update()
    {
        if (Hero.Score == CreatedPills)
            SceneManager.LoadScene("Win");
    }
}
