/*
 * This reads the Kinect head movement and amplifies the movemneet then passes this to the camera object
 * It is used to fine tune the movement of the head
 */

using UnityEngine;
using System.Collections;

public class KinectCameraContoller : MonoBehaviour {
	
	CharController3D1 control3D1;
	CameraListener cameraListener;
	HeadMonitor headMonitor;
	
	public float cameraX 			= 0.0f;			//
	public float cameraY 			= 0.0f;			//
	public float cameraZ 			= 0.0f;			//
	public float rotationAdjust		= 0.0f;			//
	
	private bool cameraInUse = false;				//
	
	public float xMovementModifier 	= 0.0f;			//
	public float yMovementModifier 	= 6.0f;			//
	public float zMovementModifier 	= 0.0f;			//
	
	public Transform target;						//
	
	// Use this for initialization
	void Start () {
	
		control3D1 = GameObject.Find("Player").GetComponent<CharController3D1>();//"OBJECT NAME" <CLASS NMAE>
		cameraListener = GameObject.Find("CameraListener").GetComponent<CameraListener>();//"OBJECT NAME" <CLASS NMAE>
		headMonitor = GameObject.Find("03_Head").GetComponent<HeadMonitor>();//"OBJECT NAME" <CLASS NMAE>
		
		cameraX = control3D1.getCurrentXAxis();//Get original position of the camera when the Kinect view is enable
		cameraY = transform.position.y - yMovementModifier;// Pull current x Axis of the head
		cameraZ = transform.position.z;// Pull current z Axis of the head
	}
	
	// Update is called once per frame
	void Update () {
		
		//Checks if the Kinect camera is enabled and that the default X position of the camera is not set
		if(cameraListener.getCurrentCamera() == 2 && !cameraInUse){
			cameraX = control3D1.getCurrentXAxis();
			cameraInUse = true;	
		}if(cameraListener.getCurrentCamera() != 2){//Checks if the camera has changed - if so it will reset the boolean to trigger the above If statment when Kinect View is enabled
			cameraInUse = false;	
		}
		
		// Increase the movement speed - Can be changed in the inspector while using the Kinect
        var x = cameraX + headMonitor.movementX * xMovementModifier;
		var y = cameraY + headMonitor.movementY * yMovementModifier;
		var z = cameraZ - headMonitor.movementZ * zMovementModifier;
		
		// Move position
		transform.position = new Vector3(x, y, z);
		
		//Apply Rotation
		transform.eulerAngles = new Vector3(0, -headMonitor.movementX * rotationAdjust, 0);
		
	}
	
}
