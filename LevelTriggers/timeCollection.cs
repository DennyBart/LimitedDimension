/*
 * This adds time to the players 3D time limit and then destroys the gameObject on collision
 */

using UnityEngine;
using System.Collections;

public class timeCollection : MonoBehaviour {
	
	public float extraTime = 2.0f;
	CameraListener camListen;
	public Transform TimeParticle;

	// Use this for initialization
	void Start () {
		camListen = GameObject.Find("CameraListener").GetComponent<CameraListener>();	//"OBJECT NAME" <CLASS NMAE>
	}
	
	void OnTriggerEnter(Collider collision) {
		if(collision.tag == "Player"){
			camListen.updateTime(extraTime);				//Update players time limit for 3D
			DestroyObject(transform.parent.gameObject);		//Destroy parent of the object
			//Play Partical
			Instantiate(TimeParticle, transform.position, transform.rotation);
		}
	}
}
