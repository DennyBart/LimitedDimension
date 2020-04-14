/*
 * This stores the players head location once it is found by the kinect
 */


using UnityEngine;
using System.Collections;


public class HeadMonitor : MonoBehaviour {
	
	
	public float initialX = 0.0f;		//Stores the original position of the player head location
	public float initialY = 0.0f;		//Stores the original position of the player head location
	public float initialZ = 0.0f;		//Stores the original position of the player head location

	public float xAxis = 0.0f;			// Pull current x Axis of the head
	public float yAxis = 0.0f;			// Pull current y Axis of the head
	public float zAxis = 0.0f;			// Pull current z Axis of the head
	
	public float movementX = 0.0f;		//Stores how much of the player has moved from the original location
	public float movementY = 0.0f;		//Stores how much of the player has moved from the original location
	public float movementZ = 0.0f;		//Stores how much of the player has moved from the original location

	public bool foundHeadLoacation = false;		//Set to true when movement is detected
	
	// Update is called once per frame
	void Update () {
		xAxis = transform.position.x;			// Pull current x Axis of the head
		yAxis = transform.position.y;			// Pull current x Axis of the head
		zAxis = transform.position.z;			// Pull current x Axis of the head
		
		//
		if(xAxis != 0.0 && foundHeadLoacation == false){
			initialX = transform.position.x;	// Pull current x Axis of the head
			initialY = transform.position.y;	// Pull current x Axis of the head
			initialZ = transform.position.z;	// Pull current x Axis of the head
			foundHeadLoacation = true;			// Movement found
		}
		
		if(foundHeadLoacation){
			movementX = xAxis - initialX;		// Storeshow much of the player has moved from the original location
			movementY = yAxis - initialY;		// Storeshow much of the player has moved from the original location
			movementZ = zAxis - initialZ;		// Storeshow much of the player has moved from the original location
		}
		
	}
	
	//@RETURN original X value
	public float getInitialX(){
		return initialX;
	}
	
	//@RETURN if the head is found
	public bool foundHead (){
		return 	foundHeadLoacation;
	}
}
