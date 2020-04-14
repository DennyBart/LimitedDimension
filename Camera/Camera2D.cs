using UnityEngine;
using System.Collections;

public class Camera2D : MonoBehaviour {
	
	public Transform cameraTarget;							//The camera view follows this target - Can be assigned to follow the player or a certain area for some game modes
	public Transform originalTransform;						//Stores the original camera target (Set to player Target by default)
	
	public float zoom2DInRate = 0.01f;						//The rate that the camera size will reduce by
	public float zoom2DOutRate = 0.02f;						//The rate that the camera size will increase by
	public float max2DZoomIn = 5.0f;						//The min size of the camera
	public float max2DZoomOut = 7.0f;						//The max size of the camera
	public float stationaryZoomOut = 0.0f;					//Max size of camera in Battle Mode or set modes (Used when zooming is not needed)
	
	public bool battle = false;								//Currently in a battle area
	public bool waterfall = false;							//Currently at the waterfall area
	
	public void Start(){
		originalTransform = cameraTarget;					//Backup of the original player target
	}
	
	// Use this for initialization
	public void camera2D () {
		transform.position = cameraTarget.position;
		if(battle){												//battle mode enabled
			if(camera.orthographicSize < stationaryZoomOut){	//Orthographic Size is at the max Zoom Out
			camera.orthographicSize += zoom2DInRate;			//Enlarge the Orthographic Size (Zoom out effect)
			}
			if(camera.orthographicSize > stationaryZoomOut){	//Check if the camer is over the MIN size
				camera.orthographicSize = stationaryZoomOut;	//Set to max size
			}
		}else if(Input.GetAxis ("Vertical") == 0 && Input.GetAxis ("Horizontal") == 0){		//If controller not moving
			if(camera.orthographicSize > max2DZoomIn){			//Check if caera size is larger than MIN size
				camera.orthographicSize -= zoom2DInRate;		//Reduce camera size by rate (Zoom In Effect)
			}
		}else if(camera.orthographicSize < max2DZoomOut){		//If the camera is smaller than MAX size
			camera.orthographicSize += zoom2DOutRate;			//This give the effect of zooming out in the game by enlarging the viewing orthographic scale (Allows for more to be viewed in the view)
		}
	}
	
	
	//Enables a battle mode that doesnt move the camera and dsiables zoom
	public void setBattle(bool battleStart){
		battle = battleStart;								//Set the battle mode boolean
	}
	
	//The camera Target is changed for certain moments in the game such as Battle Mode
	public void setTarget(Transform target, float zoomOut){
		cameraTarget = target;								//Change the camera target
		stationaryZoomOut = zoomOut;						//Set the camera zoom to a set value
		battle = true;										//Enable battle mode
	}
	
	//Used to reset values for the camera and set back to follow player
	public void resetTarget(){
		battle = false;										//Dsiable Battle Mode
		cameraTarget = originalTransform;					//Set the camera target back to tracking the player
	}
	
}
