/*
 * Script monitors the current ground that collides with the object
 */

using UnityEngine;
using System.Collections;

public class CurrentGround : MonoBehaviour {

	//Player player;
	GameObject currentTrigger;
	
	private string curGround = null;
	
	// Store collision to a string
	void OnTriggerEnter(Collider trigger) {
		if(trigger.tag != "player"){
			curGround = trigger.tag;
		}
		
	}
	
	// remove collision string
	void OnTriggerExit(){
		curGround = null;
	}
	
	// @RETURN current ground
	public string getCurrentGround(){
		return curGround;
	}
	
}
