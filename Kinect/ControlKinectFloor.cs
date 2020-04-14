/*
 * 
 * 
 * 
 */

using UnityEngine;
using System.Collections;

public class ControlKinectFloor : MonoBehaviour {
	
	public float hiddenPositionY = 0.0f;	//Location of object when hidden
	public float showPositionY = 0.0f;		//Location of object when activated
	public bool enableFloor = true;			//Used to test and setup activated position
	
	public ViewTrigger view1;				//References the sibling trigger location in the
	public ViewTrigger view2;				//References the sibling trigger location in the
	
	
	// Use this for initialization
	void Start () {
		transform.position = new Vector3(transform.position.x, hiddenPositionY, transform.position.z);	//Set position of object to hidden on startup
	}
	
	// Update is called once per frame
	void Update () {
		if(view1.triggerSet == true || view2.triggerSet == true || enableFloor){		//check if each trigger is activated or the manual enableFloor boolean is triggerd.
			showFloor();
		}else{
			hideFloor();
		}
	}
	
	public void showFloor(){
		transform.position = new Vector3(transform.position.x, showPositionY, transform.position.z);	//Move to activated position
	}
	
	public void hideFloor(){
		transform.position = new Vector3(transform.position.x, hiddenPositionY, transform.position.z);	//Move to hidden position
	}
}
