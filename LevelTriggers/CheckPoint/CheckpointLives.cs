/*
 * As the player moves through the game checkpoints are triggered
 * Once the player runs out of lives the player will respawn at the X Y Z
 */

using UnityEngine;
using System.Collections;

public class CheckpointLives: MonoBehaviour {
	
	public int lives = 3;
	CharController2D char2D;
	
	private float currentCheckpointX;
	private float currentCheckpointY;
	private float currentCheckpointZ;
	
	// Use this for initialization
	void Start () {
		char2D = GameObject.Find("Player").GetComponent<CharController2D>();//"OBJECT NAME" <CLASS NMAE>
	}
	
	// Update is called once per frame
	void Update () {
		guiText.text = "Lives : " + lives.ToString();											// Display the text on screen
		if(lives == 0){
			char2D.respawn(currentCheckpointX, currentCheckpointY, currentCheckpointZ, false);	//Respawn character at X Y Z
			lives = 3;																			//Reset lives
		}
	}
	
	public void setCurrentCheckpoint(float x, float y, float z){
		currentCheckpointX = x;
		currentCheckpointY = y;
		currentCheckpointZ = z;
	}
}
