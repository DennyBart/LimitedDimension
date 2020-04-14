/*
 * Simplet script to destroy a partical after 5 seconds. In the latest version of Unity particals do not auto destroy.
 */



using UnityEngine;
using System.Collections;

public class DestroyParticle : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Destroy(gameObject, 5);
	}
}
