using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public HeroController Hero;
    public Maze Maze;
    public int CreatedPills;
    public LevelController LevelControllerObject;
    public GameObject LevelControllerPrefab;

    private int oldFire1Value;

    void Awake()
    {
        LevelControllerObject = FindObjectOfType<LevelController>() ??
                                (Instantiate(LevelControllerPrefab).GetComponent<LevelController>().SetCurrentZero());
    }


    // Use this for initialization
    void Start()
    {
        Maze.useLevel = LevelControllerObject.GetCurrent();
        Maze.ReloadMap();
    }

    // Update is called once per frame
    void Update()
    {
        if (Hero.Score == CreatedPills)
            LevelControllerObject.LoadNextLevel();

        var newFire1Val = (int)Input.GetAxis("Fire1");
        if (oldFire1Value == 0 && newFire1Val == 1)
        {
            GameModeController.Instance.SetNextMode();
        }

        oldFire1Value = newFire1Val;
    }
}
