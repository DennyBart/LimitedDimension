//This script is called when a player collides and needs to respawn. The script is added to the trigger object and the respawn location is added using public variables.


using UnityEngine;
using System.Collections;

public class KillFloor : MonoBehaviour {
	
	public float respawnLocationX = 0.0f;
	public float respawnLocationY = 0.0f;
	public float respawnLocationZ = 0.0f;
	
	CharController2D char2D;
	
	void Start(){
		char2D = GameObject.Find("Player").GetComponent<CharController2D>();	//"OBJECT NAME" <CLASS NMAE>
	}
	
	void OnTriggerStay(Collider trigger) {
		if(trigger.tag == "player"){											//If the player is in the trigger zone
			// Move the player to the X Y Z position on the map - True uses a time limit
			char2D.respawn(respawnLocationX, respawnLocationY, respawnLocationZ, true);
		}
		
	}
	
	public void forceReset(){													
		// Forcefully move the player to the X, Y, Z on the map - True uses a time limit
		char2D.respawn(respawnLocationX, respawnLocationY, respawnLocationZ, true);
	}
}
