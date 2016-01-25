using UnityEngine;
using System.Collections;

public class PillScript : MonoBehaviour
{


    void OnTriggerEnter(Collider other)
    {

        var pc = other.GetComponent<HeroController>();
        if (pc == null)
            return;


        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;
        GetComponent<AudioSource>().Play();
        Destroy(gameObject,1f);


        pc.Score++;
    }



}
