using UnityEngine;
using System.Collections;

public class ControlMatch : MonoBehaviour {
	
	public bool startClock = false;
	public float time = 0.0f;
	public float timeCountDown = 0.0f;
	public float matchTimeLimit = 60.0f;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(startClock){
			matchClock();
		}
	}
	
	
	public void matchClock(){
		if(time == 0.0){
			time = Time.time;
		}
		timeCountDown = Time.time - time;
		
		if(timeCountDown > matchTimeLimit){
			time = 0.0f;
			timeCountDown = 0.0f;
			//drop bridge;
		}
	}
	
}
