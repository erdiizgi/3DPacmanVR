using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public float MoveSpeed;

    private bool hasColision;
    private Rigidbody rBody;

    private float torqueForce;

    public float MaxTorqueForce;
    public float TorqueForceCoolDown;

    // Use this for initialization
    void Start()
    {
        rBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {



    }

    void FixedUpdate()
    {
        var forward = transform.forward * Input.GetAxis("Vertical");
        var right = transform.right * Input.GetAxis("Horizontal");
        rBody.velocity = (forward + right) * MoveSpeed;
        rBody.angularVelocity = Vector3.up * 10 * Input.GetAxis("Mouse X");

    }


    void OnCollisionEnter(Collision collision)
    {
        hasColision = true;

    }

    void OnCollisionExit(Collision collision)
    {
        hasColision = false;

    }
}
