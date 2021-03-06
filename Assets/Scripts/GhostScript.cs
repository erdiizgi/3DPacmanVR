﻿using UnityEngine;
using System.Collections.Generic;

public class GhostScript : MonoBehaviour
{
    private GameController lvlControl;

    public float speed;

    Vector3 directionVector;
    Vector3 targetPosition;

    List<string> availableDirections; // Pájo, nedívej se

    float floatyFloat;

    // Use this for initialization
    void Start()
    {
        directionVector = new Vector3(0f, 0f, 0f);
        targetPosition = transform.position;

        availableDirections = new List<string>();

        floatyFloat = 0f;

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

        floatyFloat += Time.fixedDeltaTime;
        float floatySin = 0.7f + 0.2f * Mathf.Sin(floatyFloat * 4.0f);

        transform.position = new Vector3(transform.position.x, floatySin, transform.position.z);
        targetPosition = new Vector3(targetPosition.x, floatySin, targetPosition.z);
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

        if(collider.gameObject.name == "L" || collider.gameObject.name == "R" || collider.gameObject.name == "U" || collider.gameObject.name == "D")
        {
            if(!availableDirections.Contains(collider.gameObject.name))
                availableDirections.Add(collider.gameObject.name);
        }

        Debug.Log("Enter " + collider.gameObject.name + " X: " + transform.position.x + " Z: " + transform.position.z);
    }

    void OnTriggerExit(Collider collider)
    {
   //     Debug.Log("Exit " + collider.gameObject.name + " X: " + transform.position.x + " Z: " + transform.position.z);
        if (availableDirections.Contains(collider.gameObject.name))
            availableDirections.Remove(collider.gameObject.name);
    }

    void DecideNewDirection()
    {
        List<Vector3> availableDirectionVectors = new List<Vector3>();

        if (availableDirections.Contains("L"))
        {
            availableDirectionVectors.Add(new Vector3(-1f, 0f, 0f));
            Debug.Log("L");
        }
        if (availableDirections.Contains("R"))
        {
            availableDirectionVectors.Add(new Vector3(1f, 0f, 0f));
            Debug.Log("R");
        }
        if (availableDirections.Contains("U"))
        {
            availableDirectionVectors.Add(new Vector3(0f, 0f, 1f));
            Debug.Log("U");
        }
        if (availableDirections.Contains("D"))
        {
            availableDirectionVectors.Add(new Vector3(0f, 0f, -1f));
            Debug.Log("D");
        }

        if (availableDirections.Count > 0)
        {
            if (availableDirectionVectors.Contains(directionVector) && Random.Range(0, 16) <= 12)
            {
                // keep going same direction
                Debug.Log("sd");
            }
            else if (availableDirectionVectors.Contains(-1f * directionVector) && availableDirectionVectors.Count > 1 && Random.Range(0, 16) <= 8)
            {
                // don't turn around
                availableDirectionVectors.Remove(-1f * directionVector);
                directionVector = availableDirectionVectors[Random.Range(0, availableDirectionVectors.Count)];
                Debug.Log("dta");
            }
            else
            {
                directionVector = availableDirectionVectors[Random.Range(0, availableDirectionVectors.Count)];
                Debug.Log("rnd");
            }
            targetPosition = transform.position + 2f * directionVector; // TODO: replace 2f with map's Maze script's Tile Size parameter (which is currently set to 2f)
            Debug.Log("New direction - dX: " + directionVector.x + " dZ: " + directionVector.z);
        }

    }
}
