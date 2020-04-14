/*
 * Pulls the texture to display on the screen
 */

using UnityEngine;
using System.Collections;

public class SignTextDisplay : MonoBehaviour {
	
	void Start(){
		guiTexture.enabled = false;
	}
	
	// Use this for initialization
	public void textDisable () {
		guiTexture.enabled = false;
	}
	
	// Update is called once per frame
	public void textEnable () {
		guiTexture.enabled = true;
	}
}
