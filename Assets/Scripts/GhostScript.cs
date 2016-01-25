using UnityEngine;
using System.Collections.Generic;

public class GhostScript : MonoBehaviour
{
    private GameController lvlControl;

    public float speed;

    Vector3 directionVector;
    Vector3 targetPosition;

    List<string> availableDirections; // Pájo, nedívej se

    // Use this for initialization
    void Start()
    {
        directionVector = new Vector3(0f, 0f, 0f);
        targetPosition = transform.position;

        availableDirections = new List<string>();

        lvlControl = FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if((transform.position - targetPosition).magnitude < speed)
        {
            DecideNewDirection();
        }

        transform.position = transform.position + directionVector * speed;
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.GetComponent<PillScript>() != null)
            return;


        var pc = collider.GetComponent<HeroController>();
        if (pc != null)
        {
            //lvlControl.LevelControllerObject.FailLevel();
            return;
        }

        if(collider.gameObject.name == "L" || collider.gameObject.name == "R" || collider.gameObject.name == "U" || collider.gameObject.name == "D")
        {
            if(!availableDirections.Contains(collider.gameObject.name))
                availableDirections.Add(collider.gameObject.name);
        }

        Debug.Log("Enter " + collider.gameObject.name + " X: " + transform.position.x + " Z: " + transform.position.z);
    }

    void OnTriggerExit(Collider collider)
    {
        Debug.Log("Exit " + collider.gameObject.name + " X: " + transform.position.x + " Z: " + transform.position.z);
        if (availableDirections.Contains(collider.gameObject.name))
            availableDirections.Remove(collider.gameObject.name);
    }

    void DecideNewDirection()
    {
        List<Vector3> availableDirectionVectors = new List<Vector3>();

        if (availableDirections.Contains("L"))
            availableDirectionVectors.Add(new Vector3(-1f, 0f, 0f));
        if (availableDirections.Contains("R"))
            availableDirectionVectors.Add(new Vector3(1f, 0f, 0f));
        if (availableDirections.Contains("U"))
            availableDirectionVectors.Add(new Vector3(0f, 0f, 1f));
        if (availableDirections.Contains("D"))
            availableDirectionVectors.Add(new Vector3(0f, 0f, -1f));

        if (availableDirections.Count > 0)
        {
            if (availableDirectionVectors.Contains(directionVector)) { }
            else {
                directionVector = availableDirectionVectors[Random.Range(0, availableDirectionVectors.Count)];
            }
            targetPosition = transform.position + 2f * directionVector; // TODO: replace 2f with map's Maze script's Tile Size parameter (which is currently set to 2f)
            Debug.Log("New direction - dX: " + directionVector.x + " dZ: " + directionVector.z);
        }

    }
}
