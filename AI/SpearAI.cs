using UnityEngine;
using System.Collections;

public class SpearAI : TrackPlayer {				//Inheriters TrackPlayer to find the position of the player
	

	public int moveSpeed;							//Speed of the spear
	public int rotationSpeed;						//Rotation speed of the spear
	public int hitCount = 3;						//
	public int gateHitCount = 0;					//
	
	public float minHeight = 0.0f;					//If arrow passes over this limit it respawns
	
	public float spearDefaultX = 0.0f;				//Holds the default hiding location of the spear
	public float spearDefaultY = 0.0f;				//Holds the default hiding location of the spear
	public float spearDefaultZ = 0.0f;				//Holds the default hiding location of the spear
	
	public float offSetY = 0.5f;					//Variable to allow the arrow to target of the center
	public float offSetX = 1.5f;					//Variable to allow the arrow to target of the center
	public float offSetZ = 1.5f;					//Variable to allow the arrow to target of the center
	public float xLimit = 0.0f;						//If arrow passes over this limit it respawns
	
	public float playerRespawnX = 0.0f;				//Position of the players respawn location
	public float playerRespawnY = 0.0f;				//Position of the players respawn location
	public float playerRespawnZ = 0.0f;				//Position of the players respawn location
	
	//public bool resetPLayer = false;
	
	private Transform spearTransform;					//Chaches the transformation
	
	public CletusAnim cletusAnimation;				//
	
	CharController2D char2D;
	InvisWall invisWall;
	BossScene1 bossScene1;
	CheckpointLives checkLives;
	
	void Awake(){									//This happens before anything else 
		spearTransform = transform;					//Pulls the current transform - useful for caching the transform
	}
	
	
	void Start(){
		checkLives =  GameObject.Find("Lives").GetComponent<CheckpointLives>();	//Find and assign the Script associated with the game object
		char2D = GameObject.Find("Player").GetComponent<CharController2D>();	//Find and assign the Script associated with the game object
		invisWall = GameObject.Find("BossWall").GetComponent<InvisWall>();		//Find and assign the Script associated with the game object
		bossScene1 = GameObject.Find("BossTrigger").GetComponent<BossScene1>();	//Find and assign the Script associated with the game object
		hitCount = checkLives.lives;
	}
	
	
	public void Update () {
		checkLives.lives = hitCount; 
		if(inAir){																//If the Object is currently in the Air
			if(spearTransform.position.y < minHeight){								//Check if current Y position is below the limit Y
				inAir = false;													//Set inAir to false
				hideSpear();													//Calls on resetting the Spear's location
				cletusAnimation.pickUpObject();									//Call on pickUpObject
			}else{
				if(spearTransform.position.y < targetLocation.y){					//If the spear is less than the the target location it dives towards the ground
					targetLocation *= -2;										//Sets loation to under the Y limit.
				}
				
				///Find current target rotation (X,Y,Z)
				//Slerp : Spherically interpolates between two vectors. (Unity API)
				spearTransform.rotation = Quaternion.Slerp(spearTransform.rotation, Quaternion.LookRotation(targetLocation - spearTransform.position), rotationSpeed * Time.deltaTime);
				//Finds rotation
				spearTransform.position += spearTransform.forward * moveSpeed * Time.deltaTime;
			}
			if(spearTransform.position.x < xLimit){								//Spear current loation is 
				inAir = false;													//Not in air
				//Call on health damage
				hideSpear();													//Hide spear
				cletusAnimation.pickUpObject();									//Run animation to pick up another object
			}
			
		}
	}
	
	public void OnTriggerEnter(Collider collision) {
		if(collision.tag == "Player"){							//If collision with Player TAG
			inAir = false;										//Object not in the air anymore
			hideSpear();										//Hide spear
			cletusAnimation.pickUpObject();						//Run animation to pick up another object
			hitCount--;											//Increas the counter for 
			if(hitCount < 0){									//Count limit hit
				hitCount = 3;									//Reset hitcount
				checkLives.lives = 3;
				resetEvents();									//Reset level to trigger same events when the player gets to the area
			}
		}if(collision.tag == "Ground"){							//If the spear has hit the ground Tag
			//Put the arrow into the ground
			inAir = false;										//Not in the air any more
			hideSpear();										//Hide spear
			cletusAnimation.pickUpObject();						//Run animation to pick up another object
		}
	}
	
	void hideSpear(){
		transform.eulerAngles = new Vector3(0, 270, 0);
		spearTransform.position = new Vector3(spearDefaultX, spearDefaultY + offSetY, spearDefaultZ);	//Set spear to Default location plus offset to allow for change in loaction spawning
		
	}
	
	void pickupSpear(){
		spearTransform.position = new Vector3(spearDefaultX + offSetX, spearDefaultY + offSetY, spearDefaultZ);		//Set spear to Default location plus offset to allow for change in loaction spawning
	}
	
	public void resetPosition(){
		if(cameraListen.currentCamera == 0){			//Check that the camer ais in 2D view
			spearTransform.position = new Vector3(spearDefaultX + offSetX, spearDefaultY + offSetY, targetLocation.z);	//Set spear to Default location plus offset to allow for change in loaction spawning
		}else{
			spearTransform.position = new Vector3(spearDefaultX, spearDefaultY, spearDefaultZ);	//Set spear to Default location
		}
	}
	
	void resetEvents(){
		char2D.respawn(playerRespawnX, playerRespawnY, playerRespawnX, false);			//Set players location to X, Y, Z and do not use a delay timer(FALSE)
		invisWall.setWall(true);														//Set invisible wall to true so the player can pass through
		//cletusAnimation.idleAnimation();
		bossScene1.resetBattle();														//Reset the messaging script
		char2D.messageMode = false;														//Pulls character out of message mode if it is enabled
	}
	
}