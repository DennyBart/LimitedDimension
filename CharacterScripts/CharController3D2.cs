using UnityEngine;
using System.Collections;

public class CharController3D2 : CharController3D {
	
	
	public void movement3D2() {
		
		CharacterController controller = GetComponent<CharacterController>();
		
		if(messageMode){//Stops all character movement input if the player is in messageMode
			moveDirection = new Vector3(0, 0, 0);
		}
		
		//move Player when grounded
		if (controller.isGrounded && !messageMode) {
			charAnimRotation.startWalk3D();
			if(Input.GetAxis("Vertical") != 0){
				if(Input.GetAxis("Vertical") > 0.5f ){
					charAnimRotation.playingAnim("Run");
				}else{
					//Player input is not over half so walk animation is player
					charAnimRotation.playAnimWalk();
				}
			}else if(Input.GetAxis("Horizontal") != 0){
				if(Input.GetAxis("Horizontal") > 0.5f ){
					charAnimRotation.playingAnim("Run");
				}else{
					charAnimRotation.playAnimWalk();
				}
			}else{
				//No input play idel animation
				charAnimRotation.playingAnim("Idle");
			}
				
			
			
			moveDirection = new Vector3(Input.GetAxis ("Horizontal") * verticalSpeed, 0, Input.GetAxis("Vertical") * verticalSpeed);//This is in relation to Negative and Positive Values from Vertical & Horizontal
			moveDirection = transform.TransformDirection(moveDirection);
			moveDirection *= moveSpeed;
            jumping = false;
			
			//if jumping
        	if (Input.GetButtonDown("Jump")){
				charAnimRotation.playingAnim("Jump");
				jumping = true;
				//move on Y axis
                moveDirection.y = jumpSpeed;
			//Long jump activated
			}else if (Input.GetButtonDown("Fire2")){
				charAnimRotation.playingAnim("Jump");
				jumping = true;
                moveDirection.y = jumpSpeed;
				moveDirection.x = moveDirection.x * jumpMultiplier;
				moveDirection.z = moveDirection.z * jumpMultiplier;
			}
        }
		
		
		//While in jump mode
		if(!controller.isGrounded && jumping == true && !messageMode){
			
		}
		
		moveDirection.y -= gravityPull * Time.deltaTime; //Pulls character Y axis to the gound before applying move
		
		
		
		//apply movement
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