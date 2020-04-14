//

using UnityEngine;
using System.Collections;

public class BossScene1 : MonoBehaviour {
	
	private bool messageActive = false;
	private bool scenePlayer = false;
	public bool testReset = false;
	
	public CletusAnim cletusAnim;
	CharController2D char2D;
	CharController3D1 char3D1;
	public InvisWall invisibleWall;

	// Use this for initialization
	void Start () {
		char2D = GameObject.Find("Player").GetComponent<CharController2D>();//"OBJECT NAME" <CLASS NMAE>
		char3D1 = GameObject.Find("Player").GetComponent<CharController3D1>();//"OBJECT NAME" <CLASS NMAE>
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	void OnTriggerStay(Collider collision) {
		if(collision.tag == "Player" && !messageActive && !scenePlayer){
			cletusAnim.setBattleCam(true);		//Set Camera to Zoom Out (Battle Mode)
			char2D.messageMode = true;			//Stops the player from moving in 2D
			char3D1.messageMode = true;			//Stops the player from moving in 3D
			messageActive = true;				//Bool for message current showing
			print ("MESSAGE");					//Send Message TO SCREEN
			cletusAnim.playerTrigger();
		}else if(collision.tag == "Player" && Input.GetButtonDown("Fire1") && messageActive){
			cletusAnim.throwObject();
			invisibleWall.setWall(false);		//Sets wall behind character to not passible
			char2D.messageMode = false;
			char3D1.messageMode = false;
			messageActive = false;
			scenePlayer = true;
			print ("MESSAGE REMOVED");//REMOVE MESSAGE FROM SCREEN
		}
		
	}
	
	// If the player need to respawn this is called to reset all setting and re-trigger the event when the players passes
	public void resetBattle(){
		cletusAnim.setBattleCam(false);
		messageActive = false;
		scenePlayer = false;
		cletusAnim.resetCharPos();
	}
	
}
