using UnityEngine;
using System.Collections;

public class FollowPlayer : TrackPlayer {
	
	private Transform myTransform;
	public bool attacking = false;
	public float moveSpeed = 0.0f;
	public float originalPosition = 0.0f;
	
	GameObject follower;			//
	
	public float storedPositionX = 0.0f;
	
	// Use this for initialization
	void Start () {
		follower = transform.parent.gameObject;	//Gets the parent Object Transform
	}
	
	// Update is called once per frame
	void Update () {
		if(attacking){				//Boolean triggeres attack()
			attack ();				//Calls Method to attact the player
		}
	}
	
	public void OnTriggerStay(Collider collision) {
		if(collision.tag == "Player"){				//Collision iwth Player tag name
			findPlayer();							//Call findPlayer from inherited TrackPlayer method
			storedPositionX = targetLocation.x;		//set target location x to StredPosition (Only X is needed as the object only moves in the X space)
			attacking = true;						//Set this to trigger Update() Call
		}
		if(collision.tag == "Limit"){
			print (collision);						
		}
	}
	
	void attack(){
		//This stops the object from moving too much - 1 is used to not make the stop point exact and make it easier to stop
		if(follower.transform.position.x < storedPositionX + 1 && follower.transform.position.x > storedPositionX + 1){
			attacking = false;	//Update() call will stop
		}
		
		if(attacking){
			/*This moves the object to the Left and Right
			 * The location of the player is compared to the objects location. If the object X location is less than the Target's Location (storedPositionX)
			 * the object moves left. If it is larger the object moves Right
			 */
			if(follower.transform.position.x < storedPositionX){
				follower.transform.position = new Vector3(follower.transform.position.x + moveSpeed * Time.deltaTime, follower.transform.position.y, follower.transform.position.z);
				if(follower.transform.position.x > storedPositionX){		//When moveing left and the object position is now more than it meas the position has moved over the target location
					attacking = false;										//and has not Found or Hit the Target
				}
			}else if(follower.transform.position.x > storedPositionX){
				follower.transform.position = new Vector3(follower.transform.position.x - moveSpeed * Time.deltaTime, follower.transform.position.y, follower.transform.position.z);
				if(follower.transform.position.x < storedPositionX){
					attacking = false;
				}
			}
		}
		
		
		
	}
	
	
	
}
