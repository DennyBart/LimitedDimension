using UnityEngine;
using System.Collections;

public class CharController3D1 : CharController3D {
	
	public void movement3D1() {
		
		CharacterController controller = GetComponent<CharacterController>();//Gets reference for CharacterController
		
		if(messageMode){//Stops all character movement input if the player is in messageMode
			moveDirection = new Vector3(0, 0, 0);
		}
		
		//move Player when grounded
		if (controller.isGrounded && !messageMode) {
			charAnimRotation.startWalk3D();
			if(Input.GetAxis("Vertical") != 0){
				if(Input.GetAxis("Vertical") > 0.5f){
					charAnimRotation.playingAnim("Run");
				}else{
					charAnimRotation.playAnimWalk();
				}
			}
			
			//Rotate player on Y axis with player Hozizontal input as movement adjuster
           transform.Rotate(0, Input.GetAxis("Horizontal") * rotationSpeed, 0);//This is in relation to Negative and Positive Values from Vertical & Horizontal
			
			moveDirection = new Vector3(Input.GetAxis ("Vertical") * verticalSpeed, 0, 0);//Move player in the direction with the playet Vertical input
			moveDirection = transform.TransformDirection(moveDirection);	//Save movement
			moveDirection *= moveSpeed;										//Speed adjuster
            jumping = false;												//Not in jumping mode
			
        	if (Input.GetButtonDown("Jump")){
				charAnimRotation.playingAnim("Jump");
				jumping = true;
				//Move on the Y axis
                moveDirection.y = jumpSpeed;
			//Long jump mode
			}else if (Input.GetButtonDown("Fire2")){
				charAnimRotation.playingAnim("Jump");
				jumping = true;
                moveDirection.y = jumpSpeed;
				//Move directions with modifiers applied for fast movement
				moveDirection.x = moveDirection.x * jumpMultiplier;
				moveDirection.z = moveDirection.z * jumpMultiplier;
			}
        }
		
		//In Jump Mode
		if(!controller.isGrounded && jumping == true && !messageMode){
			
		}
		
		moveDirection.y -= gravityPull * Time.deltaTime; //Pulls character Y axis to the gound before applying move
		
		//Apply Movement
		controller.Move(moveDirection * Time.deltaTime);
		
		//Keep Player within the platform limits
		if(transform.position.z > zLimitMax){
			transform.position = new Vector3(transform.position.x, transform.position.y, zLimitMax);	
		}
		if(transform.position.z < zLimitMin){
			transform.position = new Vector3(transform.position.x, transform.position.y, zLimitMin);
		}
	}
	
}