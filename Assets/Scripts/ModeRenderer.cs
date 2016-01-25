using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ModeRenderer : MonoBehaviour
{

    public string Text;

    private Text text;

    // Use this for initialization
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = string.Format("{0}: {1}", Text, GameModeController.Instance.GetCurrent.Name);
    }
}
