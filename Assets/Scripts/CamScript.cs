using UnityEngine;
using System.Collections;
using UnityEngine.VR;

public class CamScript : MonoBehaviour {

	private GameObject character;

	public Vector3 translation;
	public Vector3 rotation;
	public GameObject cameraKeeper;

	public Vector3 forward;

	public float hRot;
    public float StickMultiplier;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if(Input.GetKeyDown(KeyCode.R))
		{
			OVRManager.display.RecenterPose ();
		}

		if(Input.GetKey(KeyCode.Alpha1))
		{
			this.rotation.x -= 0.2f;
		}

		if(Input.GetKey(KeyCode.Alpha2))
		{
			this.rotation.x += 0.2f;	
		}

		if(Input.GetKey(KeyCode.Alpha3))
		{
			this.rotation.y -= 0.2f;	
		}

		if(Input.GetKey(KeyCode.Alpha4))
		{
			this.rotation.y += 0.2f;	
		}

		if(Input.GetKey(KeyCode.Alpha5))
		{
			this.rotation.z -= 0.2f;	
		}

		if(Input.GetKey(KeyCode.Alpha6))
		{
			this.rotation.z += 0.2f;	
		}


		if (character == null) {
			character = GameObject.Find ("Character(Clone)");
		}
		if (character == null) {
			return;
		}

		Vector3 target = Quaternion.AngleAxis(hRot, Vector3.up) * translation;


		gameObject.transform.position = character.transform.position + target;
		//this.cameraKeeper.transform.position = character.transform.position + target;
		gameObject.transform.eulerAngles = rotation;
		//this.cameraKeeper.transform.eulerAngles = rotation;
		hRot += Input.GetAxis ("Mouse X") + Input.GetAxis("RightStick") * StickMultiplier;

		//gameObject.transform.LookAt (character.transform.position);
		//gameObject.transform.eulerAngles += rotation;
		//this.cameraKeeper.transform.eulerAngles += rotation;

		this.forward = gameObject.transform.forward;

		this.rotation.y = hRot;
	}
}
