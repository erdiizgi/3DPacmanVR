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

	private GameObject camera;

    // Use this for initialization
    void Start()
    {
        rBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
		if (camera == null) {
			camera = GameObject.Find ("CameraManager");
		}


    }

    void FixedUpdate()
    {
		if (camera == null)
			return;
		
        var forward = camera.transform.forward * Input.GetAxis("Vertical");
		forward.y = 0;
		forward.Normalize ();

        var right = camera.transform.right * Input.GetAxis("Horizontal");
		right.y = 0;
		right.Normalize ();

        rBody.velocity = (forward + right) * MoveSpeed;
        //rBody.angularVelocity = Vector3.up * 10 * Input.GetAxis("Mouse X");

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
