using UnityEngine;
using System.Collections;

public class PillScript : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {

        var pc = other.GetComponent<HeroController>();
        if (pc == null)
            return;

        Destroy(gameObject);


        pc.Score++;
    }



}
