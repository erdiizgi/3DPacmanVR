using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{

    public List<TextAsset> Games;
    private int current = -1;

    void Awake()
    {
        if (Games == null)
            Games = new List<TextAsset>();
    }

    // Use this for initialization
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void LoadNextLevel()
    {
        current++;
        SceneManager.LoadScene(current == Games.Count ? "Win" : "LevelScene");
    }

    public void FailLevel()
    {
        current = 0;
        SceneManager.LoadScene("Fail");
    }

    public TextAsset GetCurrent()
    {
        return Games[current];
    }

    public LevelController SetCurrentZero()
    {
        current = 0;
        return this;
    }
  
}
