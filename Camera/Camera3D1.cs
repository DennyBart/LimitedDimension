/*
 * This controls the camera while the player moves
 * It checks if the player is standing on a "slopeGround" or level ground
 * The camera moves differently depending on the ground type
 * The check for slope ground it to prevent the camera going through the floor
 */


using UnityEngine;
using System.Collections;

public class Camera3D1 : MonoBehaviour {

	public CharController3D1 movement3D1;		//Call on movement script for this camera mode
	public CurrentGround curGround;				//A script that monitors what the player is currently standing on
	public Transform cameraTarget;				//This target is used to follow the player as he moves
	
	public float originalY = 0.0f;				//Stores the players original Y value
	public float originalZ = -1.658426f;		//Stores the players original Z value 
	public float centerPlayerVar = 3.3f;		//This is an adjuster to move the camera off the players X axis. Such as placing the camera infrom of the player or behind.
	public float maxZoomY = 1.2f;				//This is the max that the camera will move out on the Y Axis
	public float maxZoomZ = 1.2f;				//This is the max that the camera will move out on the Z Axis
	public float previousY = 0.0f;				//Stores the previousY location for comparison to the next cycle of Y location
	public float zoom3D1OutRate = 0.01f;		//This is the speed of the camera Zooming Out
	public float zoom3D1InRate = 0.13f;			//This is the speed of the camera Zooming In
	
	public bool setOrigDefaults = false;		//Triggers the method to save the current location on first time the method camera1() is ran
	public bool camera3D1Set = false;			//Triggers a if statment to store the Traget position
	
	
	public void camera1(){
		
		//This is called once on the first time the method is ran
		if(setOrigDefaults){
			originalY = transform.position.y;				//Store originalY position
		}
		
		//Called each time this method is called at the start
		if(!camera3D1Set){
			transform.position = cameraTarget.position;		//Move camera to the Target Location
			camera3D1Set= true;								//Set to True so this method will not be called each time this method runs
		}
		
		
		originalY = movement3D1.getCurrentYAxis();										//Store current Y axis to originalY
		float playerXAxis = movement3D1.getPlayerXMovement();							//Get the players X axis
		if(Input.GetAxis ("Vertical") == 0 && Input.GetAxis ("Horizontal") == 0){		//Check that the controller is not being moved
			if(transform.position.y > originalY || transform.position.z < originalZ){	//Check if the camera is currently Not at the original Y and Z location
				zoom3D1In();															//Call zoom in method
			}if(curGround.getCurrentGround() == "slopeGround"){							//If the player is standing on a slope surface Tag
				//Move the camera's X axis back into place
				transform.position = new Vector3(-playerXAxis - centerPlayerVar, transform.position.y, transform.position.z);
			}
		//Character is being moved - Zoom Out
		}else if(transform.position.y < (originalY + maxZoomY) || transform.position.z < (originalZ + maxZoomZ)){
			zoom3D1Out();																//Max zooms not met so camera can zoom out
		}else{
			//If the player is moving the camera is also at max zoom out it holds the current X position
			transform.position = new Vector3(-playerXAxis - centerPlayerVar, transform.position.y, transform.position.z);
		}
		//This checks if the Y axis needs to be zoomed out or is at max zoom (1.5f is a Y offset from the players position)
		if(transform.position.y > movement3D1.getCurrentYAxis() + 1.5f){
			//Move the camera up along the Y axis
			transform.position = new Vector3(-playerXAxis - centerPlayerVar, transform.position.y - zoom3D1OutRate, transform.position.z);
		}else{
			//Camera is at Max Y axis and holds the max Y zoom out position
			transform.position = new Vector3(-playerXAxis - centerPlayerVar, transform.position.y, transform.position.z);
		}
	}
	
	
	//This funtion is split into a call for "slopeGround" and other ground. Camera reacts differently depending on th eground type
	void zoom3D1Out(){
		//Get the players X axis
		float playerXAxis = movement3D1.getPlayerXMovement();
		//Check if the Player is moving on a sloped surface
		if(curGround.getCurrentGround() == "slopeGround"){
			//Check if the camera is less than the max Zoom Out on Y
			if(transform.position.y < (originalY + maxZoomY)){
				//Zoom the camera out on the Y axis
				transform.position = new Vector3(-playerXAxis - centerPlayerVar, transform.position.y + zoom3D1OutRate, transform.position.z);
			//Check if the camera is less than the max Zoom Out on Z
			}if(transform.position.z < (originalZ + maxZoomZ)){
				if(transform.position.z != 0.5f){			//This moves the camer to pos1 on Z to get a better angle when on a slope
					if(transform.position.z < 0.5f){		//Check if the Z is less than 0.5f
					//Zoom Out on Z
						transform.position = new Vector3(-playerXAxis - centerPlayerVar, transform.position.y, transform.position.z + zoom3D1InRate / 2);
					}else if(transform.position.z > 0.5f){
					//Zoom In On Z
						transform.position = new Vector3(-playerXAxis - centerPlayerVar, transform.position.y, transform.position.z - zoom3D1InRate / 2);
					}else{
					//Set camera To Current Z (Zoomed IN or OUT to MAX)
						transform.position = new Vector3(-playerXAxis - centerPlayerVar, transform.position.y, transform.position.z);
					}
				}
			}
		}else{//This is called if player not on "slopeGround"
			//Check if the current Y poition is less than the MAX Y Zoom Out
			if(transform.position.y < (originalY + maxZoomY)){
				//Zoom Out on Y
				transform.position = new Vector3(-playerXAxis - centerPlayerVar, transform.position.y + zoom3D1OutRate, transform.position.z);
			//Check if the current Z poition is less than the MAX Z Zoom Out
			}if(transform.position.z < (originalZ + maxZoomZ)){
				//Zoom in Y
				transform.position = new Vector3(-playerXAxis - centerPlayerVar, transform.position.y, transform.position.z + zoom3D1OutRate);
			}
			//Store previous Y position
			previousY = transform.position.y;
		}
	}
	
		
	void zoom3D1In(){
		//Check if the player on "slopeGround"
		if(curGround.getCurrentGround() == "slopeGround"){
			//Adding 1.5f Bring the camera up so it doesnt cut into the sceene - This is triggered when the player is running down a hill and stops
			if(transform.position.y > originalY + 1.5f){
				//Zoom Out on Y
				transform.position = new Vector3(transform.position.x, transform.position.y - zoom3D1InRate, transform.position.z);
			}
			if(transform.position.y < originalY){
				//Zoom in on Y
				transform.position = new Vector3(transform.position.x, transform.position.y + zoom3D1InRate, transform.position.z);
			}
				//Zoom Out on Z
			if(transform.position.z > originalZ){
				transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - zoom3D1InRate);
			}	
		}else{
			//Not on "slopeGround"
			if(transform.position.y > originalY){
				//Zoom Out on Y
				transform.position = new Vector3(transform.position.x, transform.position.y - zoom3D1InRate, transform.position.z);
			}
			//print (transform.position.z + " > " + originalZ);
			if(transform.position.z > originalZ){
				//Zoom out on Z
				transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - zoom3D1InRate);
			}
			if(transform.position.z < originalZ){
				//Zoom in on Z
				transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + zoom3D1InRate);
			}
		}
		
	}
	
	//Reset this bool that Triggers a if statment to store the Traget position - Usually called on camera Change
	public void setResetBool(bool current){
		camera3D1Set = current;
	}
}
