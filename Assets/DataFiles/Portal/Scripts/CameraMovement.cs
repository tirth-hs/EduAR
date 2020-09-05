using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

	public int speed;


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	
	float moveCam = Input.GetAxis ("Vertical") * speed * Time.deltaTime;

		transform.Translate (0, 0, moveCam);

		float rotateCam = 0;

		if (Input.GetKey (KeyCode.LeftArrow)) {
		
			rotateCam = rotateCam - 1;

		}

		if (Input.GetKey (KeyCode.RightArrow)) {
		
			rotateCam = rotateCam + 1;

		}

		transform.Rotate (0, rotateCam, 0);
	}


}


