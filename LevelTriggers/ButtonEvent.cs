/*
 * The script is used in the water button puzzle
 * It removes the Kill / Respawn floors when the button is activated.
 */

using UnityEngine;
using System.Collections;

public class ButtonEvent : MonoBehaviour {
	
	public bool inZone = false;
	
	GameObject tempKFloor1;
	GameObject tempKFloor2;
	GameObject tempWater;
	
	// Use this for initialization
	void Start () {
		tempKFloor1 = GameObject.Find("TempKFloor1");	// Respawn floor
		tempKFloor2 = GameObject.Find("TempKFloor2");	// Respawn floor
		tempWater = GameObject.Find("TempWater");		// Water texture object
		renderer.material.color = Color.red;			// Change button material colour to red
	}
	
	// Update is called once per frame
	void Update () {
		if(inZone){										// If the player is in the button zone
			if(Input.GetButton("Fire1")){				// Detect button is pressed
				renderer.material.color = Color.green;	// Change material colour to green
				DestroyObject(tempKFloor1);				// Destroy Object
				DestroyObject(tempKFloor2);				// Destroy Object
				DestroyObject(tempWater);				// Destroy Object
			}
		}
	}
	
	void OnTriggerEnter(Collider collision) {
		if(collision.tag == "Player"){					//Detect if player in zone
			inZone = true;								//
		}
	}
	
	void OnTriggerExit(Collider collision) {
		if(collision.tag == "Player"){					//Detect if player is not in zone
			inZone = false;
		}
	}
	
}
