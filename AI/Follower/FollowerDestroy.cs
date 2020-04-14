using UnityEngine;
using System.Collections;

public class FollowerDestroy : MonoBehaviour {
	
	public Transform FollowerParticle;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void OnTriggerEnter(Collider collision) {
		print ("Collision wiht : " + collision);
		if(collision.tag == "player"){
			DestroyObject(transform.parent.gameObject);		//Destroy parent of the object
			Instantiate(FollowerParticle, transform.position, transform.rotation);
		}
	}
	
}
