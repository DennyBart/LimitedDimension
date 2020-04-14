/*
 * This script controls the Z size of the box depending on the camera view
 * 2D - This increases the size of the box so that it can be moved in the 2D view (The box need to be out to a certain Z point for it to be accessed by the Character)
 * 3D - This decreases the size of the box so it can be interacted with in the 3D view.
 * 
 */

using UnityEngine;
using System.Collections;

public class Box2D3D : MonoBehaviour {
	
	CameraListener camListen;				//Get current camera view
	public float zSizeIn2D = 1.0f;			//This is usually a large size so the box can be moved in 2D space
	public float zSizeIn3D = 1.0f;			//Usually give 1.0 by default to give the box a square shape
	
	// Update is called once per frame
	
	void Start(){
		camListen =  GameObject.Find("CameraListener").GetComponent<CameraListener>();//"OBJECT NAME" <CLASS NMAE>
	}
	
	void Update() {
		if(camListen.getCurrentCamera() == 0){						//Check if the current camera mode is in 2D (0)
			transform.localScale = new Vector3(1, 1, zSizeIn2D);	//Scale to predefined 2D size
		}else{
			transform.localScale = new Vector3(1, 1, zSizeIn3D);	//Scale to predefined 3D size
		}
	}
	
}