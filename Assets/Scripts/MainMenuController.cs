using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public GameObject MenuPanel;
    public GameObject InfoPanel;
    public LevelController lvlController;

    // Use this for initialization
    private void Start()
    {
        setPanels(true);
    }

    // Update is called once per frame
    private void Update()
    {
        if (!InfoPanel.activeSelf)
            return;

        if (Input.anyKey)
            closeAbout();
    }

    private void closeAbout()
    {
        setPanels(true);
    }

    public void StartNewGame()
    {
        lvlController.LoadNextLevel();
    }

    public void About()
    {
        setPanels(false);
    }

    public void Quit()
    {
        Application.Quit();
    }

    private void setPanels(bool act)
    {
        MenuPanel.SetActive(act);
        InfoPanel.SetActive(!act);
    }
}