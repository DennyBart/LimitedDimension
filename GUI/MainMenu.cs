/*
 * Main mnu script that loads level 1.9 when Start is pressed
 */

using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {
	
	CameraListener camListen;
	
	// Use this for initialization
	void Start () {
		camListen = GameObject.Find("CameraListener").GetComponent<CameraListener>();//"OBJECT NAME" <CLASS NMAE>
	}
	
	// Update is called once per frame
	void Update () {
		camListen.currentCamera = 2;
		if(Input.GetKeyDown(KeyCode.JoystickButton7)){
			Application.LoadLevel("Level1.9");
		}
		if(Input.GetKeyDown(KeyCode.JoystickButton6)){
			print ("Exit");
		}
	}
}
