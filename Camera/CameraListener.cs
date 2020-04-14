using UnityEngine;
using System.Collections;

public class CameraListener : MonoBehaviour {
	
	public int currentCamera = 0; // 3 Different camera 0 - 2
	public Camera cam2D;
	public Camera cam3D1;
	public Camera cam3D2;

	public float startTime = 0.0f;
	public float playerTime = 10.0f;		//Stores the amount of time the player has for 3D view
	public float maxGraceTime = 5.0f;		//Once the player is under this limit the time will increase to this value slowly
	public float timeAdjuster = 0.02f;		//If player time left under "maxGraceTime" this is addes each Update call to incrase playerTime slowly
	public float tempPlayerTime = 0.0f;
	public float view3DTime = 0.0f;			//Stores the current time in 3D view
	private int intTime = 0;
	
	CharController2D movement2D;
	CharController3D1 movement3D1;
	CharController3D2 movement3D2;
	
	GameObject timerView3d;
	//public PushPull movingObject;

	public Camera3D1 camera3D1;
	public Camera2D camera2D;
	
	// Set default camera on Startup
	void Start () {
		movement2D =  GameObject.Find("Player").GetComponent<CharController2D>();//"OBJECT NAME" <CLASS NMAE>
		movement3D1 = GameObject.Find("Player").GetComponent<CharController3D1>();//"OBJECT NAME" <CLASS NMAE>
		movement3D2 =  GameObject.Find("Player").GetComponent<CharController3D2>();//"OBJECT NAME" <CLASS NMAE>
		timerView3d =  GameObject.Find("TimerView3d");//"OBJECT NAME" <CLASS NMAE>
		intTime = (int)playerTime;
		timerView3d.guiText.text = "3DTimer : " + intTime.ToString();
		
		cam2D.camera.enabled = true;
		cam3D1.camera.enabled = false;
		cam3D2.camera.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.JoystickButton6)){
			Application.LoadLevel("menu1.0");
		}
		if(playerTime < maxGraceTime){			//Check if player is below 5 seconds of time if so it increases the time slowly
			updateTime(timeAdjuster);	//pass timeAdjuster to the added to current time left
		}
		
		//bool test = movingObject.getHoldingState();
		if (Input.GetKeyDown(KeyCode.JoystickButton2) || Input.GetKeyDown("c")){// 
			currentCamera = 0;
		}
		if (Input.GetKeyDown(KeyCode.JoystickButton5) || Input.GetKeyDown("v")){// 
           	currentCamera = 1;
		}
		if (Input.GetKeyDown(KeyCode.JoystickButton4) || Input.GetKeyDown("b")){// 
			currentCamera = 2;
		}
		if(playerTime < 0.9 && currentCamera == 1){								//Check if timer is at 0 ad the current camera is set to 1
			currentCamera = 0;
		}
		
		setCurrentCamera(currentCamera);
	}
	
	
	public int getCurrentCamera(){//Returns the current camera number
			return currentCamera;
	}
	
	
	public void setCurrentCamera(int cameraNumber){//Changes the camer and control style
		
		if (cameraNumber == 0) {
			
			startTime = 0;					//Resets "startTime" so once camera 1 is activated the timer will be reset
			cam2D.camera.enabled = true;
			cam3D1.camera.enabled = false;
			cam3D2.camera.enabled = false;
			movement2D.movement();
			camera2D.camera2D();
			camera3D1.camera3D1Set = false;
		}
		else if (cameraNumber == 1) {
			cam2D.camera.enabled = false;
			cam3D1.camera.enabled = true;
			cam3D2.camera.enabled = false;
			movement3D1.movement3D1();
			timer3D();
			camera3D1.camera1();
		}
		else if (cameraNumber == 2) {
			startTime = 0;					//Resets "startTime" so once camera 1 is activated the timer will be reset
			cam2D.camera.enabled = false;
			cam3D1.camera.enabled = false;
			cam3D2.camera.enabled = true;
			movement3D2.resetRotation();
			movement3D2.movement3D2();
			camera3D1.camera1();
			
			//print ("Kinect");
		}
	}
	
	void timer3D(){
		if(startTime == 0.0){		//"startTime" is used to store the seconds since the method is activated by subtractnig the current time since game start from the time the method is activated. "startTime" then stores the seconds since activation.
			startTime = Time.time;
			tempPlayerTime = playerTime;
		}
		view3DTime = Time.time - startTime;
		playerTime = tempPlayerTime - view3DTime;
		
		intTime = (int)playerTime;
		
		timerView3d.guiText.text = "3DTimer : " + intTime.ToString();
		if(playerTime <= 0){
			currentCamera = 0;
		}
	}
	
	public void updateTime(float modTime){
		playerTime += modTime;
		intTime = (int)playerTime;
		timerView3d.guiText.text = "3DTimer : " + intTime.ToString();
	}
	
}
