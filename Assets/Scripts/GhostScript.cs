using UnityEngine;
using System.Collections;

public class GhostScript : MonoBehaviour
{
    private GameController lvlControl;

    public float speed;

    Vector3 forward;
    Vector3[] forwards;
    float rotation;
    float[] rotations;

    // Use this for initialization
    void Start()
    {
        forward = new Vector3(1f, 0f, 0f);
        forwards = new[] {
            new Vector3(1f, 0f, 0f),
            new Vector3(0f, 0f, -1f),
            new Vector3(-1f, 0f, 0f),
            new Vector3(0f, 0f, 1f),
        };
        rotation = 0f;
        rotations = new[] {
            0f,
            90f,
            180f,
            360f
        };

        lvlControl = FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = transform.position + forward * speed;
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.GetComponent<PillScript>() != null)
            return;


        var pc = collider.GetComponent<HeroController>();
        if (pc != null)
        {
            lvlControl.LevelControllerObject.FailLevel();
            return;
        }

        Debug.Log("Enter " + collider.gameObject.name + " X: " + transform.position.x + " Z: " + transform.position.z);
        float newRotation = rotation;
        Vector3 newForward = forward;
        while (newRotation == rotation)
        {
            int random = Random.Range(0, rotations.Length);
            newRotation = rotations[random];
            newForward = forwards[random];
        }
        rotation = newRotation;
        forward = newForward;
        transform.rotation = Quaternion.Euler(0f, rotation, 0f);
    }

    void OnTriggerStay(Collider collider)
    {
        Debug.Log("Enter " + collider.gameObject.name + " X: " + transform.position.x + " Z: " + transform.position.z);
    }
}
