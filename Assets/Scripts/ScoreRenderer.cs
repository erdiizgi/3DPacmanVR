using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreRenderer : MonoBehaviour {

    public string Text;
    public GameController Controller;

    private Text text;

	// Use this for initialization
	void Start () {
        text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        text.text = string.Format("{0}: {1}", Text, Controller.Hero.Score);
	}
}
