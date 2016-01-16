using UnityEngine;
using System.Collections;

public class BoostPillScript : MonoBehaviour
{
    private GameController lvlControl;

    void Start()
    {
        lvlControl = FindObjectOfType<GameController>();
    }

    void OnTriggerEnter(Collider other)
    {

        var pc = other.GetComponent<HeroController>();
        if (pc == null)
            return;

        Debug.Log("Trigger");
        Destroy(gameObject);

        lvlControl.LevelControllerObject.FailLevel();
    }


}
