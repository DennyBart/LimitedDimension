/*
 * This script enable the parallaxing effect
 * 
 * 
 */

using UnityEngine;
using System.Collections;

public class MoveBackground : MonoBehaviour {
	
	public bool moveFoward = true;			//Set to false to move backwards
	public float speed = 30.0f;				//Speed of the Background scrolling - The lower the number the faster the scrolling
	public float lastPos = 0.0f;			//Stores previous mosition of the player (Used to determin movement to the left or right)
	public float currentPosition = 0.0f;	//The current position of the Character
	
	CharController2D CharController;
	
	void Start(){
		CharController = GameObject.Find("Player").GetComponent<CharController2D>();//"OBJECT NAME" <CLASS NMAE>
	}
	
	// Update is called once per frame
	void Update () {
		currentPosition = CharController.getCurrentXAxis();
		if(!moveFoward){						//When player moves foward this layer moves to the left
			if(currentPosition > lastPos){		//Check if player is moving to the right
				transform.position = new Vector3(currentPosition, transform.position.y, transform.position.z);
				//This takes the current X position and devides it to slow down the movement
				renderer.material.mainTextureOffset = new Vector2((transform.position.x/speed), 0);
			}
			if(currentPosition < lastPos){		//Check if player is moving to the left
				transform.position = new Vector3(currentPosition, transform.position.y, transform.position.z);
				//This takes the current X position and devides it to slow down the movement
				renderer.material.mainTextureOffset = new Vector2((transform.position.x/speed), 0);
			}
		}
		if(moveFoward){							//When player moves foward this layer moves to the right
			if(currentPosition > lastPos){		//Check if player is moving to the right
				transform.position = new Vector3(currentPosition, transform.position.y, transform.position.z);
				//This takes the current X position and devides it to slow down the movement
				renderer.material.mainTextureOffset = new Vector2((-transform.position.x/speed), 0);
			}
			if(currentPosition < lastPos){		//Check if player is moving to the left
				transform.position = new Vector3(currentPosition, transform.position.y, transform.position.z);
				//This takes the current X position and devides it to slow down the movement
				renderer.material.mainTextureOffset = new Vector2((-transform.position.x/speed), 0);
			}
		}
		
		lastPos = currentPosition;				//save the current position to lastPos variable. When this method is ran again the last position is known
	}
}
