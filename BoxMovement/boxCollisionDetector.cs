using UnityEngine;
using System.Collections;

public class boxCollisionDetector : MonoBehaviour {

	public bool hitTrigger = false;		//
	public bool leftTrigger= false;		//Indicate if Object moving left - IF FALSE MOVING RIGHT
	public bool woodenBox = false;		//
	
	public WoodenBox woodeBox;			//
	//public Transform playerTarget;
	
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	void OnTriggerEnter(Collider collision) {
		if(collision.tag == "Player"){							//Collision with Player Tag
			if(leftTrigger){									//Object Moving Left
				woodeBox.setMoveBox("leftPushCollider", true);	//Send Move box to the left notification and bool confirms moving
			}else{
				woodeBox.setMoveBox("rightPushCollider", true);	//Send Move box to the left notification and bool confirms moving
			}
		}
	}
	
	void OnTriggerExit(Collider collision) {
		if(collision.tag == "Player"){							//When the Player Tag Object moves from this object it sends a request to stop moving
			if(leftTrigger){
				woodeBox.setMoveBox("leftPushCollider", false);
			}else{
				woodeBox.setMoveBox("rightPushCollider", false);
			}
		}
	}

}