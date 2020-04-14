/*
 * This script plays the players animations depending on current camera mode. 
 */

using UnityEngine;
using System.Collections;

public class CharAnimRot : MonoBehaviour {
	
	private bool curently3D = false;
	
	//Pass animation name to method to play that animation
	public void playingAnim (string anim) {
		animation[anim].speed = 1.0f;		//Set speed of the animation
		animation.Play (anim);				//Play animation
	}
	
	//Play Run animation at Half speed for 3D view
	public void playAnimWalk(){
		animation["Run"].speed = 0.5f;
		animation.Play("Run");
	}
	
	//Walking 2D mode to the LEFT
	public void walk2DL(){
		transform.eulerAngles = new Vector3(0, 270, 0);		//Sets rotation
		curently3D = false;									//Confirms that the current view is in 2D
	}
	
	//Walking 2D mode to the RIGHT
	public void walk2DR(){
		transform.eulerAngles = new Vector3(0, 90, 0);		//Sets rotation
		curently3D = false;									//Confirms that the current view is in 2D
	}
	
	//This is a trigger method that changes the Animation for 3D movement
	public void startWalk3D(){
		if(!curently3D){									
			transform.eulerAngles = new Vector3(0, 90, 0);	//Sets rotation
		}
		curently3D = true;									//Sets view to 3D
	}
}
