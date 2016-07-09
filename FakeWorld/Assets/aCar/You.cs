using UnityEngine;
using System.Collections;

public class You : MonoBehaviour {

	public int myID;

	float lastUpdateTime;

	WWW connection;

	ArrayList players;

	// Use this for initialization

	void Awake(){
		players = new ArrayList ();
		myID = -10;
	}

	void Start () {
		lastUpdateTime = Time.time;
	}

	// Update is called once per frame
	void Update () {
		if (myID < 0)
			return;
		if (connection != null) {
			if (connection.isDone) {
				OthersInfo info = JsonUtility.FromJson<OthersInfo> (connection.text);
				lastUpdateTime = Time.time;
				processData (info.players);
				connection.Dispose ();
				connection = null;
			}
		} else {
				
			if(Time.time - lastUpdateTime > 0.05F)connection = Utility.visitUrl (Global.rootUrl + "/fetch");

		}
	}

	void processData(UpdateInfo[] A){
		
		Debug.Log (A.Length);
		for (int i = 0; i < A.Length; i++) {
			bool found = false;
			UpdateInfo someInfo = A [i];
			for (int j = 0; j < players.Count; j++) {
				SomePlayer p = (SomePlayer)players [j];
				if (p.ID == someInfo.ID) {
					found = true;
					CarControl theControl = p.car.GetComponent<CarControl> ();
					Transform app = p.car.transform.GetChild (0);
					Transform body = p.car.transform.GetChild (1);

			//		float timeDiff = Time.time - theControl.lastUpdated;


					Vector3 desPos = new Vector3 (someInfo.profile.xPos, someInfo.profile.yPos, someInfo.profile.zPos);
					Quaternion desRot = new Quaternion (someInfo.profile.xRot, someInfo.profile.yRot, someInfo.profile.zRot, someInfo.profile.wRot);

//					theControl.desV = (desPos - app.position) / timeDiff;
//					theControl.desBodyV = (desPos - body.position) / timeDiff;

					Quaternion relative = Quaternion.Inverse (app.rotation) * desRot;
					float angleInDegrees;
					Vector3 rotationAxis;
					relative.ToAngleAxis (out angleInDegrees, out rotationAxis);
//					theControl.desRotAxis = rotationAxis;
//					theControl.desRotV = angleInDegrees / timeDiff;

					relative = Quaternion.Inverse (body.rotation) * desRot;
					relative.ToAngleAxis (out angleInDegrees, out rotationAxis);

				//	theControl.desBodyAV = rotationAxis * angleInDegrees * Mathf.Deg2Rad / timeDiff;


				//	theControl.lastUpdated = Time.time;
					break;
				}
			}
			if (!found && someInfo.ID!=myID) {
				SomePlayer x = new SomePlayer ();
				x.ID = someInfo.ID;
				x.car = Instantiate ((GameObject)Resources.Load ("cars/CarV"));
				x.car.transform.position = new Vector3 (someInfo.profile.xPos, someInfo.profile.yPos, someInfo.profile.zPos);
				x.car.transform.rotation = new Quaternion (someInfo.profile.xRot, someInfo.profile.yRot, someInfo.profile.zRot, someInfo.profile.wRot);
				CarControl theControl = x.car.GetComponent<CarControl> ();
			//	theControl.automated = true;
				players.Add (x);

			}
		}
	}


}

public class SomePlayer{
	public GameObject car;
	public int ID;
}
