using UnityEngine;
using System.Collections;

public class MyInput : MonoBehaviour {

	// Use this for initialization

	public GameObject player;

	void Start () {
		
	}
	
	// Update is called once per frame

	void FixedUpdate(){


	}

	void Update () {
		if (player == null)
			return;
		else {
			
			CarControl c = player.GetComponent<CarControl> ();

			int steering = -1, motor = -1, brake = -1;

			if (Input.touchSupported) {

				foreach (Touch touch in Input.touches) {
					if (touch.position.x < 300) {
						//c.steering = -40;
					} else if (touch.position.x > 400) {
						//c.steering = 40;
					} else {
						//c.motor = 300;
					}
				}

			} else {

				if (Input.GetKey ("up")) {
					//c.motor = 3000000;
					motor = 3000;
				} else {
					//c.motor = 0;
					motor = 0;
				}
				if (Input.GetKey ("down")) {
					//c.brake = 300;
					brake = 300;
				} else {
					//c.brake = 0;
					brake = 0;
				}

				if (Input.GetKey ("left")) {
					//c.steering = -50;
					steering = -50;
				} else if (Input.GetKey ("right")) {
					//c.steering = 50;
					steering = 50;
				} else {
					//c.steering = 0;
					steering = 0;
				}
			}
			c.CmdUpdate (steering, motor, brake);
		}
	}
}
