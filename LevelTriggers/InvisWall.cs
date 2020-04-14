/*
 * This script is used to stop a player from passing over a certain object.
 * This is useful in the boss scene so the player cannot move off the screen.
 */

using UnityEngine;
using System.Collections;

public class InvisWall : MonoBehaviour {

	// Use this for initialization
	void Start () {
		collider.isTrigger = true;	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void setWall(bool invisibleWall){
		collider.isTrigger = invisibleWall;			//Enable or disable the isTrigger - Make the object a trigger ot not
	}
}
