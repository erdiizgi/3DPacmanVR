using UnityEngine;
using System.Collections;

public class PillScript : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        Debug.Log("Trigger");

        var pc = other.GetComponent<HeroController>();
        if (pc == null)
            return;

        pc.Score++;
    }

    void OnTriggerExit(Collider other)
    {

    }

}
