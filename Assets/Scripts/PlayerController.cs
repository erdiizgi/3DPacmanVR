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

        var currentMode = GameModeController.Instance.GetCurrent;

        var fw = 0f;
        if (!currentMode.CharacterCanStop)
        {
            fw = 1;
        }
        else
        {
            fw = Input.GetAxis(currentMode.IsDPadAlowed ? "X360_D_Pad_Y" : "Vertical");
        }
        var forward = camera.transform.forward * fw;
		forward.y = 0;
		forward.Normalize ();


        var rt = Input.GetAxis(currentMode.IsDPadAlowed ? "X360_D_Pad_X" : "Horizontal");
        var right = camera.transform.right * rt;
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
