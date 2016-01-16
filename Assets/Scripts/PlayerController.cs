using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public float MoveSpeed;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


        var moveVector = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * MoveSpeed;
        transform.Translate(moveVector);

        transform.Rotate(Vector3.up, Input.GetAxis("Mouse X"));
        transform.Rotate(Vector3.up, Input.GetAxis("RightStick"));
    }


    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("enter");
        foreach (ContactPoint contact in collision.contacts)
        {
            Debug.DrawRay(contact.point, contact.normal, Color.white);
        }

    }

    void OnCollisionExit(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            Debug.DrawRay(contact.point, contact.normal, Color.white);
        }

    }
}
