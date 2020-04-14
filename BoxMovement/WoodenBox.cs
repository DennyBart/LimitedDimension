/*
 * This moves the box along the X axis within the game.
 * It is triggered by the charactering colliding with the box and then enabling the pushing
 * It handles left and right pushing aswell as speeds.
 */

using UnityEngine;
using System.Collections;

public class WoodenBox : MonoBehaviour {

	CameraListener CamListen;
	CharAnimRot charAnimRotation;
	
	public float woodBoxPushSpeed  = 2.0f ;			//Pull speed
	public float woodBoxPullSpeed  = 20.0f ;		//Push Speed
	
	public string collider = null;					//This holds collider info(LeftPush or RightPush)
	public bool moving = false;						//Boolean true when moving
	
	CameraListener camListen;						//Call CameraListen
	
	void Start(){
		camListen = GameObject.Find("CameraListener").GetComponent<CameraListener>();//"OBJECT NAME" <CLASS NMAE>
		charAnimRotation = GameObject.Find("Barr").GetComponent<CharAnimRot>();//"OBJECT NAME" <CLASS NMAE>
	}
	
	void Update(){
		if(Input.GetAxis("Horizontal") == 0){		//If not moving the character it resets string collider and the sets the box to not moving
			resetVariables();						//Call resetVariables()
		}
		if(moving){									//If box is moving
			moveBox();
		}else{
			resetVariables();
		}
	}
	
	public void setMoveBox(string collider1, bool moving1){
		collider = collider1;						//Set the collider (leftPushCollider OR rightPushCollider)
		moving = moving1;							//Boolean if the box is currently moving
	}
	
	public void resetVariables(){
		collider = null;							//Set the collider to null
		moving = false;								//Boolean to set box not moving
	}
	
	
	public void stopMoving(){
		moving = false;								//Boolean to set box not moving
	}
	
	// Use this for initialization
	public void moveBox(){
		int currentCam = camListen.getCurrentCamera();	//Get the current camera mode (1 = 2D - 2 = 3D - 3 = 3D Kinect)
		
		//Check that the Fire1 Buton is pressed the current camera is 2D mode and the collider is set to push RIGHT
		if(Input.GetButton("Fire1") && currentCam == 0 && collider == "rightPushCollider"){
			charAnimRotation.playingAnim("PushWalk");		//Play animation
			if(Input.GetAxis ("Horizontal") < 0){			//If controller is pushed LEFT
				//Move this Object X by the Push Speed and the Time.deltaTime (Time in seconds to complete the last frame)
				this.transform.position = new Vector3(this.transform.position.x - (woodBoxPushSpeed * Time.deltaTime / 2), this.transform.position.y, this.transform.position.z);
			}
			if(Input.GetAxis ("Horizontal") > 0){			//If controller is pushed RIGHT
				charAnimRotation.playingAnim("PushWalk");	//Play animation
				//Move this Object X by the Push Speed and the Time.deltaTime (Time in seconds to complete the last frame)
				this.transform.position = new Vector3(this.transform.position.x + (Input.GetAxis ("Horizontal") * Time.deltaTime * woodBoxPullSpeed), this.transform.position.y, this.transform.position.z);
			}
		//Check that the Fire1 Buton is pressed the current camera is 2D mode and the collider is set to push Left
		}else if(Input.GetButton("Fire1") && currentCam == 0 && collider == "leftPushCollider"){
			if(Input.GetAxis ("Horizontal") > 0){			//If controller is pushed LEFT
				//Move this Object X by the Push Speed and the Time.deltaTime (Time in seconds to complete the last frame)
				this.transform.position = new Vector3(this.transform.position.x + (woodBoxPushSpeed * Time.deltaTime / 2), this.transform.position.y, this.transform.position.z);
			}
			if(Input.GetAxis ("Horizontal") < 0){		//If controller is pushed RIGHT
				//Move this Object X by the Push Speed and the Time.deltaTime (Time in seconds to complete the last frame)
				this.transform.position = new Vector3(this.transform.position.x + (Input.GetAxis ("Horizontal") * Time.deltaTime * woodBoxPullSpeed), this.transform.position.y, this.transform.position.z);
			}
		}
	}
	
}
