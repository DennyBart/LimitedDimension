using UnityEngine;
using System.Collections;

public class WallRotation : MonoBehaviour {
	
	HeadMonitor headMonitor;
	public float xModifier = 0.0f;
	public float zModifier = 0.0f;
	public float zMinLimit = 0.0f;
	public float zMaxLimit = 0.0f;
	
	// Use this for initialization
	void Start () {
		headMonitor = GameObject.Find("03_Head").GetComponent<HeadMonitor>();//"OBJECT NAME" <CLASS NMAE>
	}
	
	// Update is called once per frame
	void Update () {
		float moveX = headMonitor.movementX * xModifier;
		transform.eulerAngles = new Vector3(0, moveX, 90);
		float transformZ = transform.position.z + headMonitor.movementX * zModifier;
		if(transformZ >= zMaxLimit){
			transformZ = zMaxLimit;
		}else if(transformZ <= zMinLimit){
			transformZ = zMinLimit;
		}
		
		transform.position = new Vector3(transform.position.x, transform.position.y, transformZ);
	}
}
