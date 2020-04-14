/*
 * Stores the location of the checkpoint to the checkpoint controller
 * Assign this to an object that saves a checkpoint when the player passes through
 */

using UnityEngine;
using System.Collections;

//Problem with inheritance CHECK

public class CheckTrigger : MonoBehaviour {
	
	CheckpointLives checkpoint;
	
	void Start(){
		checkpoint = GameObject.Find("Lives").GetComponent<CheckpointLives>();		//"OBJECT NAME" <CLASS NMAE>
	}
	
	public void OnTriggerEnter(Collider collision) {
		if(collision.tag == "Player"){												// Player tag in checkpoint
			checkpoint.setCurrentCheckpoint(this.transform.position.x,this.transform.position.y ,this.transform.position.z);
		}
	}
	
}
