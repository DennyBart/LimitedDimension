/*
 * This trigger location start the spawn for the Rock and changes the camer to 3D1
 * When the player leaves the trigger zone the camera moves to 2D
 */

using UnityEngine;
using System.Collections;

public class WaterfallTrigger : MonoBehaviour {
	
	public bool triggered = false;//Prevent the 3D1 camera triggering after being triggered once
	RockRoll getRock;
	CameraListener camListen;
	float time = 0.0f;
	float timeCountDown = 0.0f;
	
	// Use this for initialization
	void Start () {
		getRock = gameObject.GetComponentInChildren<RockRoll>();
		camListen = GameObject.Find("CameraListener").GetComponent<CameraListener>();	//"OBJECT NAME" <CLASS NAME>
	}
	
	void OnTriggerEnter(Collider collision) {
		if(collision.tag == "Player"){				// Collision with player
			getRock.startRolling();					// Start the rock movement
			if(!triggered){							// Change camera
				camListen.currentCamera = 1;		// Change camera to 3D1 to prevent the bug that stretches the rock once its created off screen
				triggered = true;					// Stops the camera from re triggering
			}
		}
	}
	
	void OnTriggerExit(){
		camListen.currentCamera = 0;				// When the player exits the area the camera changes to 2D
	}
}
