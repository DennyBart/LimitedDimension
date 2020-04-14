/*
 * This script is used to call on the animation for the AI Enemy character. This script is specifically for the cletus model's animations as it calls on the animation name.
 *
 */

using UnityEngine;
using System.Collections;

public class CletusAnim : MonoBehaviour {
	
	public SpearAI spear;					//Create instance
	public Camera2D cam2D;					//Create instance
	public SignTextDisplay signDisplay;		//Create instance
	
	//public bool matchStarted = false;		
	
	public float time = 0.0f;				//Used as an indicator if time is set in waitForThrow(). Also used to store the call time of the method. Time is taken from time.Time(This stores the time ince the start of the game)
	public float timeCountDown = 0.0f;		//Stores the time from the start of the timer start in waitForThrow()
	
	public bool waitingToThrow = false;		//Boolean set to start timer and run waitForThrow()
	//public bool resetChar = true;			
	
	public float defaultResetX = 0.0f;		//Set to original position of the character location
	public float defaultResetY = 0.0f;		//Set to original position of the character location
	public float defaultResetZ = 0.0f;		//Set to original position of the character location
	
	//public int randomTime = 0;				
	
	// Use this for initialization
	void Start () {
		animation["pickUpWeapon"].speed = 0.5f;		//Set speed of pickUpWeapon animation  to 0.5
		defaultResetX = transform.position.x;		//Set to original position of the character location
		defaultResetY = transform.position.y;		//Set to original position of the character location
		defaultResetZ = transform.position.z;		//Set to original position of the character location
	}
	
	// Update is called once per frame
	void Update () {
		if(waitingToThrow){							//
			waitForThrow ();						//
		}
	}
	
	//public void idleWait(){							
	//	charIdle ();								
	//}
	
	public void waitForThrow(){						//Pauses the player animation after throwing an object.
		if(time == 0.0){							//Check if time is 0
			time = Time.time;						//save the current gameplay time to time
			waitingToThrow = true;					//set boolean to trigger the update calling this method again
			//randomTime = Random.
		}
		timeCountDown = Time.time - time;			//Subtract the current gameplay time from the first gameplay time stored when this method is called (This give the time in seconds that this method has been called)
		//print (timeCountDown);
		if(timeCountDown > 2){						//Check if the time that this method is running is over 2 seconds
			throwObject();							//Call throwObject() animation
			time = 0.0f;							//Reset time for the next call of this method
			timeCountDown = 0.0f;					//Reset stored time that this method has ran for
			waitingToThrow = false;					//Change boolean to stop Update() from running this method
		}
	}
	
	public void playerTrigger(){
		animation.Play ("scriptJumpCletus");		//Call on animation
		signDisplay.textEnable();					//Display message
	}
	
	public void setBattleCam(bool setCamera){		//Enable Battle Cam - This zooms the 2D camera out and doesnt follow the player
		cam2D.setBattle(setCamera);
	}
	
	//void charIdle(){
		
	//}
	
	public void charTalk(){							
		animation.Play ("Talk");					//Call on animation
	}
	
	public void idleAnimation(){
		animation.Play ("idleMain");				//Call on animation
	}

	public void throwObject(){
		signDisplay.textDisable();					//Disable the text on screen (This runs even if there is nothing on the screen)
		animation.Play ("throw");					//Call on animation
		spear.findPlayer();							//Call on Spear AI to find the player location
	}
	
	public void pickUpObject(){
		animation.Play ("pickUpWeapon");			//Call on animation
	}
	
	public void resetSpearPos(){
		spear.resetPosition();						//CAll spear AI to reset Spear Location on the map
	}
	
	public void resetCharPos(){
		transform.position = new Vector3(defaultResetX, defaultResetY, defaultResetZ);	//Reset Models position to the defaults stored on startup
		waitingToThrow = false;															//Disable waitingToThrow
		animation.Play ("idleMainCletus");												//Call on animation
	}
	
}
