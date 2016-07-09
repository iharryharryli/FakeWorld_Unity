using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class CarControl : NetworkBehaviour {

	public int steering;
	public  int motor;
	public int brake;



	// Use this for initialization

	void Awake(){
	}

	void Start () {
		if (isLocalPlayer) {
			MyInput input = GameObject.Find ("Input").GetComponent<MyInput>() ;
			input.player = gameObject;
			CameraFollow camera = GameObject.Find ("Camera").GetComponent<CameraFollow> ();
			camera.player = gameObject;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	void FixedUpdate(){

			
			WheelCollider[] X = this.transform.GetComponentsInChildren<WheelCollider> ();
			X [0].steerAngle = steering;
			X [1].steerAngle = steering;
			X [0].motorTorque = motor;
			X [1].motorTorque = motor;
		X [0].brakeTorque = brake;
		X [1].brakeTorque = brake;
			

	}

	[Command]
	public void CmdUpdate(int a, int b, int c){
		if(a!= -1)steering = a;
		if(b!=-1)motor = b;
		if(c!=-1)brake = c;
	}
}
