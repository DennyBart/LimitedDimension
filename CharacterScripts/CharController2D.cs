/*
 * 
 */

using UnityEngine;
using System.Collections;

[RequireComponent (typeof(CharacterController))]//Adds CharacterController automatically

public class CharController2D : MonoBehaviour {
    
	public float speed = 6.0F;				//Movement Speed
    public float jumpSpeed = 8.0F;			//Jump Speed
    public float gravity = 20.0F;			//Gravity pull on the character
	public float time = 0.0f;				//Used as an indicator if time is set in respawn(). Also used to store the call time of the method. Time is taken from time.Time(This stores the time ince the start of the game)
	public float timeCountDown = 0.0f;		//Stores the time from the start of the timer start in respawn()
	
	public float yPos = 0;					//Stores player Y position
	
	public bool stopMovement = false;		//Stops the player from moving
	public bool pushingObject = false;		//Activated when player pushing a box
	public bool messageMode = false;		//Activated when the player in Message mode
	
	public CameraListener camListen;		//
	public CharAnimRot charAnimRotation;	//
	
    public Vector3 moveDirection = Vector3.zero;
	
    
	public void defaultRotation(){
		transform.Rotate(0f, 0f, 0f);
	}
	
	public void movement() {
		
		if(messageMode){//Stops all character movement input if the player is in messageMode
			moveDirection = new Vector3(0, 0, 0);
		}
		
		transform.localEulerAngles = new Vector3(0,0,0);//Set angle to X 0, Y 0, Z 0
		
        CharacterController controller = GetComponent<CharacterController>();//Gets reference for CharacterController
		
		// If character is on the ground and not stopMovement mode and not in Message mode
		if (controller.isGrounded && !stopMovement && !messageMode) {
			//Move on the X axis the Horizontal controller input
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
			//Check if player is pushing RIGHT and not pushing an object
			if(Input.GetAxis("Horizontal") > 0 && !pushingObject){
				//play Animation
				charAnimRotation.walk2DR();
				charAnimRotation.playingAnim("Run");
			//Check if player is pushing LEFT and not pushing an object
			}else if(Input.GetAxis("Horizontal") < 0 && !pushingObject){
				//play Animation
				charAnimRotation.walk2DL();
				charAnimRotation.playingAnim("Run");
			}else{
				//No input - play idle Animation
				charAnimRotation.playingAnim("Idle");
			}
			
			//Store changes to direction/movement
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            
			//Jump from grounded position
        	if (Input.GetButtonDown("Jump")){
				//Move up on the Y axis
				moveDirection.y = jumpSpeed;	
			}
        }
        
		
		if(!controller.isGrounded && !stopMovement && !messageMode){
			//play animation
			charAnimRotation.playingAnim("Jump");
			moveDirection.x = Input.GetAxis ("Horizontal");	//Move the player horizontal while in the air
			moveDirection.x *= speed;						//Adjust speed
		}
			
        moveDirection.y -= gravity * Time.deltaTime; //applies a pull to the ground
		
		//apply movement
        controller.Move(moveDirection * Time.deltaTime); //
		transform.position = new Vector3(transform.position.x, transform.position.y, 0);
		//Store yPos for comparison of last yPos
		yPos = transform.position.y;
		
    }
	
	//Triggers a respawn (Moves the player to a certain pint in the map)
	//Input X Y Z and T/F - bool to implement a timer or not
	public void respawn(float X, float Y, float Z, bool timer){
		if(timer){												//Timer Mode
			stopMovement = true;								//Stop Movement of player
			if(time == 0.0){									//Check if time is 0
				time = Time.time;								//Store time that theis statment is called
			}
			timeCountDown = Time.time - time;					//Stores the time since the method has started
		
			if(timeCountDown > 0.5){							//0.5 is the cut off for the timer
				if(camListen.getCurrentCamera() != 0){			//Check if the camera isnt in 2D mode
					camListen.currentCamera = 0;				//set to 2D mode
				}
				transform.position = new Vector3(X, Y, Z);		//Move player the X Y Z
				time = 0.0f;									//Reset time
				timeCountDown = 0.0f;							//Reset timeCountDown
				stopMovement = false;							//Allow for movement
			}
		}else{
			transform.position = new Vector3(X, Y, Z);			//Move player wihtout implementing a timer
		}
	}
	
	//Set if player is pushing an object
	public void setPushing(bool pushing){
		pushingObject = pushing;
	}
	
	//@Return X access
	public float getCurrentXAxis(){
		return transform.position.x;
	}
	
	//@Return Y access
	public float getCurrentYAxis(){
		return yPos;
	}
	
	//@Return Z access
	public float getCurrentZAxis(){
		return transform.position.z;
	}
	
	//@Return messageMode boolean
	public bool getMessageMode(){
		return messageMode;	
	}
	
	//Set the character X axis to defined position
	public void setCurrentX(float setX){
		transform.position = new Vector3(setX, transform.position.y, transform.position.z);
		
	}
}