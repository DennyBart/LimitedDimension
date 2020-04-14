/*
 * Displays the sign 
 */

using UnityEngine;
using System.Collections;

public class SignCalls : MonoBehaviour {
	
	CharController2D char2D;
	CharController3D1 char3D1;
	
	// Use this for initialization
	void Start () {
		char2D = GameObject.Find("Player").GetComponent<CharController2D>();		//"OBJECT NAME" <CLASS NAME>
		char3D1 = GameObject.Find("Player").GetComponent<CharController3D1>();		//"OBJECT NAME" <CLASS NAME>
	}
	
	public void setMessageMode(bool mode){
		char2D = gameObject.GetComponent<CharController2D>();						//<CLASS NAME>
		//Check if the player is in the air
		if(char2D.gravity > 0.0f){
			print ("true");
		}
	}
}
