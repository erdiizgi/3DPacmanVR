using UnityEngine;
using System.Collections;

public class CamScript : MonoBehaviour {

	private GameObject character;

	public Vector3 translation;
	public Vector3 rotation;

	public float hRot;
    public float StickMultiplier;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (character == null) {
			character = GameObject.Find ("Character(Clone)");
		}
		if (character == null) {
			return;
		}

		Vector3 target = Quaternion.AngleAxis(hRot, Vector3.up) * translation;

		gameObject.transform.position = character.transform.position + target;
		gameObject.transform.eulerAngles = rotation;

		hRot += Input.GetAxis ("Mouse X") + Input.GetAxis("RightStick") * StickMultiplier;

		gameObject.transform.LookAt (character.transform.position);
		gameObject.transform.eulerAngles += rotation;


	}
}
