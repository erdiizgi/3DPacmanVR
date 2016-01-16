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
        Destroy(gameObject);
        Debug.Log("Trigger");

        var pc = other.GetComponent<HeroController>();
        if (pc == null)
            return;

        lvlControl.LevelControllerObject.FailLevel();
    }


}
