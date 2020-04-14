using UnityEngine;
using System.Collections;
[RequireComponent (typeof(CharacterController))]//Adds CharacterController

public class CharController3D : MonoBehaviour {
	
	public float jumpMultiplier = 0.0f;			//User for long jump
	public float jumpSpeed = 8.0f;				//Jump speed
	public float moveSpeed = 0.10F;				//speed for movement
	public float rotationSpeed = 0.0F;			//Rotation speed
	public float gravityPull = 20.0f;			//Pull on the character Y axis if in the air
	public float verticalSpeed = 1.0f;			//Speed multiplier for conrtoller Vertical player input
	public float verticalJumpSpeed = 1.0f;		//Jump spped for vertial movement
	public float zLimitMax = 5.5f;				//Limit for player movement on the Z axis - Prevent player from falling off platform
	public float zLimitMin = 0.0f;				//Limit for player movement on the Z axis - Prevent player from falling off platform
	
	public bool jumping = false;				//Indicate if player in air
	public bool messageMode = false;			//
	public Vector3 gravity = Vector3.zero;		//Vector3 Gravity created
	public Quaternion rotation = Quaternion.identity;		//Rotation created
	
	GameObject player;							//
	public GameObject barr;						//Instance of character model
	
	public CharAnimRot charAnimRotation;		//
	
	public Vector3 moveDirection = Vector3.zero;//
	
	public void Start(){
		barr = GameObject.Find("Barr");//"OBJECT NAME"
		charAnimRotation = barr.GetComponent<CharAnimRot>();//"OBJECT NAME" <CLASS NMAE>
		player = GameObject.Find("Player");//"OBJECT NAME" <CLASS NMAE>
	}
	
	//Reset player rotation to XYZ 0, 0, 0
	public void resetRotation(){
		transform.localEulerAngles = new Vector3(0,0,0);
	}
	
	//@RETURN X
	public float getCurrentXAxis(){
		return transform.position.x;
	}
	
	//@RETURN Y
	public float getCurrentYAxis(){
		return transform.position.y;
	}
	
	//@RETURN Z
	public float getCurrentZAxis(){
		return transform.position.z;
	}
	
	//@RETURN negative X
	public float getPlayerXMovement(){
		return -transform.position.x;
	}
	
	//@RETURN Check message mode
	public bool getMessageMode(){
		return messageMode;	
	}
	
}
