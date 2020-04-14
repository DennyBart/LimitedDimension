/*
 * This script isusually inherited to find the players position on the map and return the X, Y, Z location.
 * 
 */

using UnityEngine;
using System.Collections;

public class TrackPlayer : MonoBehaviour {
	
	//public CharController2D charControl;
	public Transform target;						//stores the current target info
	public Vector3 targetLocation = Vector3.zero;	//Stores location of target
	public CharController2D charControl;		//Instance created to get the players position from the 2D
	public CameraListener cameraListen;
	
	public float targetOffSetX = 0.0f;					//Variable to allow the arrow to target of the center
	public float targetOffSetY = 0.0f;					//Variable to allow the arrow to target of the center
	public float targetOffSetZ = 0.0f;					//Variable to allow the arrow to target of the center
	
	public bool inAir = false;							//Detects if AI is not Grounded
	
	// Use this for initialization
	void Start () {
		charControl = GameObject.Find("Player").GetComponent<CharController2D>();			//Find and assign the Script associated with the game object
		cameraListen = GameObject.Find("CameraListener").GetComponent<CameraListener>();	//Find and assign the Script associated with the game object
	}
	
	
	public void findPlayer () {
		GameObject player = GameObject.FindGameObjectWithTag("PlayerTarget");	//Find Object with PlayerTarget tag in the game scene
		target = player.transform;												//Store to target Transform
		
		//Find current target position (X,Y,Z) and apply off Sets
		//BUG FOUND : When calling "target.transform.position.y" the value passed would decrease and sometime snap back to actual value
		//Used public variable to store Y in charController2D and called using getCurrentYAxis().
		targetLocation = new Vector3(target.transform.position.x + targetOffSetX, charControl.getCurrentYAxis() + targetOffSetY, target.transform.position.z + targetOffSetZ);
		inAir = true;		//Object is moving so it is in the Air
	}
	
}
