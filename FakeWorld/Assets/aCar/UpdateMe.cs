using UnityEngine;
using System.Collections;
using UnityEngine.Experimental.Networking;

public class UpdateMe : MonoBehaviour {


	float lastUpdatedTime;

	// Use this for initialization
	void Start () {
		//StartCoroutine (sendMine ());
		lastUpdatedTime = Time.time;
	}


	
	// Update is called once per frame
	void Update () {
		if (Time.time - lastUpdatedTime > 0.05F) {
			lastUpdatedTime = Time.time;
			Me player = this.gameObject.GetComponent<Me> () as Me;
			CarControl playerControl = player.aCar.GetComponent<CarControl> () as CarControl;
			Profile p = new Profile (player.aCar.transform.position, playerControl.steering, playerControl.motor, player.aCar.transform.rotation);
			string update = JsonUtility.ToJson(new UpdateInfo(p,player.ID));
			Utility.sendJSON (Global.rootUrl +  "/send",update);
		}
	}
}
