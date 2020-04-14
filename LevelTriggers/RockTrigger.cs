/*
 * This triggers the rock to drop when the players enthers the object
 */

using UnityEngine;
using System.Collections;

public class RockTrigger : MonoBehaviour {
	
	public float respawnLocationX = 0.0f;	// Stores the location of the rock for respawn
	public float respawnLocationY = 0.0f;	// Stores the location of the rock for respawn
	public float respawnLocationZ = 0.0f;	// Stores the location of the rock for respawn
	
	RockRoll getRock;
	CameraListener camListen;
	
	// Use this for initialization
	void Start () {
		getRock = transform.parent.GetComponent<RockRoll>();		// Set this object ot the parent of the Object
		camListen = GameObject.Find("CameraListener").GetComponent<CameraListener>();//"OBJECT NAME" <CLASS NMAE>
	}

	void OnTriggerEnter(Collider collision) {
		// Player collision
		if(collision.tag == "Player"){
			
			//Kill player - reset location and trigger
			collision.transform.position = new Vector3(respawnLocationX, respawnLocationY, respawnLocationZ);
			camListen.currentCamera = 0;
		}
		//This resets the Rock position when it collides with the kill floor
		if(collision.tag == "KillFloor"){
			getRock.resetRock();
		}
		
		
	}
	
}
