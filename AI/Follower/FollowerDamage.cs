/*
 * If a player collides with this object it will decrement a life and wait the set time to decrement another if the collision happens again
 * 
 */

using UnityEngine;
using System.Collections;

public class FollowerDamage : MonoBehaviour {

	CheckpointLives checkpoint;							//
	private bool startTimer = false;					//
	public float time = 0.0f;							///Used as an indicator if time is set in timer(). Also used to store the call time of the method. Time is taken from time.Time(This stores the time ince the start of the game)
	public float timeCountDown = 0.0f;					//Stores the time from the start of the timer start in timer()
	
	void Start(){
		checkpoint = GameObject.Find("Lives").GetComponent<CheckpointLives>();//Find and assign the Script associated with the game object
	}
	
	// Update is called once per frame
	void Update () {
		if(startTimer){			//Check if timer is started
			timer ();			//Run timer method
		}
	}
	
	
	public void OnTriggerEnter(Collider collision) {
		if(collision.tag == "Player" && !startTimer){		//If this object collides with the tag "Player" and the timer is not currently running
			checkpoint.lives -= 1;							//Remove a life from the players lives
			startTimer = true;								//Start the timer
		}
	}
	
	
	void timer(){
		if(time == 0.0){							//Check if time is 0
			time = Time.time;						//save the current gameplay time to time
		}
		timeCountDown = Time.time - time;			//Subtract the current gameplay time from the first gameplay time stored when this method is called (This give the time in seconds that this method has been called)
		
		if(timeCountDown > 3.0){					//Check if the time that this method is running is over 3 seconds
			startTimer = false;						//Set to false to stop this method being read from the Update()
			time = 0.0f;							//Reset time for the next call of this method
			timeCountDown = 0.0f;					//Reset stored time that this method has ran for
		}
	}

}
