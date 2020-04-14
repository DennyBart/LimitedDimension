using UnityEngine;
using System.Collections;

public class TextDisplay : MonoBehaviour {
	
	CharController2D char2D;
	CharController3D1 char3D1;
	public SignTextDisplay signDisplay;
	
	private bool messageActive = false;
	public bool inSignZone = false;
	
	
	// Use this for initialization
	void Start () {
		char2D = GameObject.Find("Player").GetComponent<CharController2D>();//"OBJECT NAME" <CLASS NMAE>
		char3D1 = GameObject.Find("Player").GetComponent<CharController3D1>();//"OBJECT NAME" <CLASS NMAE>
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Fire1") && inSignZone){
			displaySign();
		}
	}
	
	void OnTriggerEnter(Collider collision) {
		if(collision.tag == "Player"){
			inSignZone = true;
		}
	}
	
	void OnTriggerExit(Collider collision) {
		if(collision.tag == "Player"){
			inSignZone = false;
		}
	}
	
	void displaySign(){
		if(!messageActive){					// 
			signDisplay.textEnable();		// Display Text
			char2D.messageMode = true;		// Stop Player from moving in 2D
			char3D1.messageMode = true;		// Stop Player from moving in 3D
			messageActive = true;			// Notify that message on screen
			print ("MESSAGE");				// Send MEssage TO SCREEN
		}else if(messageActive){			// Reset for next call
			signDisplay.textDisable();
			char2D.messageMode = false;
			char3D1.messageMode = false;
			messageActive = false;
			print ("MESSAGE REMOVED");		//REMOVE MESSAGE FROM SCREEN
		}	
	}
	
}
