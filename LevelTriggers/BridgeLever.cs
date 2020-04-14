using UnityEngine;
using System.Collections;

public class BridgeLever : MonoBehaviour {
	
	GameObject bridge2;
	GameObject invisFloorBridge1;
	private bool buttonActive;
	
	// Use this for initialization
	void Start () {
		renderer.material.color = Color.red;						//Change color of material
		bridge2 = GameObject.Find("bridge2.1");						//"OBJECT NAME" <CLASS NMAE>
		invisFloorBridge1 = GameObject.Find("invisFloorBridge1");	//"OBJECT NAME" <CLASS NMAE>
	}
	
	void OnTriggerStay(Collider collision) {
		if(Input.GetButton("Fire1") && !buttonActive){				//Detect button press while character is in this area
			renderer.material.color = Color.green;					//Change color of the material to green
			buttonActive = true;									//This prevents the button from being pressed multiple times
			//Moves the floor area to the defined area
			invisFloorBridge1.transform.position = new Vector3(invisFloorBridge1.transform.position.x, invisFloorBridge1.transform.position.y + 10, invisFloorBridge1.transform.position.z);
			bridge2.animation.Play ("Default Take");				//playAnimation
		}
	}
}
