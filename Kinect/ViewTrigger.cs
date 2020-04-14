/*
 * This triggers events when this trigger zone detects the camera entering the area
 * It notifies the game that the player is standing in a certain area
 */


using UnityEngine;
using System.Collections;

public class ViewTrigger : MonoBehaviour {
	
	public bool triggerSet = false;					//Trigger the floor for the kinect trigger
	
	void OnTriggerEnter(Collider collision) {
		if(collision.tag == "Cam3D2"){				//If this object collides with a Cam3D2 TAG
			triggerSet = true;						//Notify that the objects is in the zone
		}
	}
	
	void OnTriggerExit(Collider collision) {
		if(collision.tag == "Cam3D2"){				//Remove the trigger
			triggerSet = false;						//
		}
	}
	
}
