using UnityEngine;
using System.Collections;

public class PillScript : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);

        var pc = other.GetComponent<HeroController>();
        if (pc == null)
            return;

        pc.Score++;
    }

  

}
