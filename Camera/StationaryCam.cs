/*
 * When the player enters a Trigger zone the 2D camera is enabled - Boss mode in Demo
 * 
 */

using UnityEngine;
using System.Collections;

public class StationaryCam : MonoBehaviour {
	
	GameObject CameraTarget2D;															//
	Camera2D cam2D;																		//
	CameraListener camListen;															//
	
	public float maxStationaryZoom = 7.0f;												//
	
	private bool switchCam = false;														//

	// Use this for initialization
	void Start () {
		CameraTarget2D = GameObject.Find("CameraTarget2D");
		cam2D = GameObject.Find("cam2D").GetComponent<Camera2D>();						//"OBJECT NAME" <CLASS NMAE>
		camListen = GameObject.Find("CameraListener").GetComponent<CameraListener>();	//"OBJECT NAME" <CLASS NMAE>
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	
	void OnTriggerEnter(Collider collision) {
		if(collision.tag == "Player"){								//If player enters the Stationary Camera Zone
			cam2D.setTarget(this.transform, maxStationaryZoom);		//Change target for 2D camera to definded camera Target
			if(!switchCam){											//Switch camera to 2D
				camListen.currentCamera = 0;						//Set current camera to 2D mode
				switchCam = true;									//Camera is set to 2D
			}
		}
	}
	
	void OnTriggerExit(Collider collision) {
		if(collision.tag == "Player"){								//If player enters the Stationary Camera Zone
			cam2D.resetTarget();									//Removes the camera target to Original camera
		}
		
	}
}
