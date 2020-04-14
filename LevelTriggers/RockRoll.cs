/*
 * This triggers the Rock in the game to start to roll down the hill
 * Also resets the rock location
 */


using UnityEngine;
using System.Collections;

public class RockRoll : MonoBehaviour {
	
	private float defaultX = 0.0f;
	private float defaultY = 0.0f;
	private float defaultZ = 0.0f;
	
	public bool test = false;

	
	// Use this for initialization
	void Start () {
		defaultX = transform.position.x;
		defaultY = transform.position.y;
		defaultZ = transform.position.z;
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	
	public void startRolling(){
		rigidbody.useGravity = true;
	}
	
	public void resetRock(){
		transform.position = new Vector3(defaultX, defaultY, defaultZ);//Resets rock to default location
	}
	
}
