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
}
