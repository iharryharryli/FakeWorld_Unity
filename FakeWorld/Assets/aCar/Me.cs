using UnityEngine;
using System.Collections;

public class Me : MonoBehaviour {

	public GameObject aCar;
	public GameObject controller;
	public GameObject playerManagerObj;

	public int ID;

	// Use this for initialization

	IEnumerator login(){
		WWW www = Utility.visitUrl (Global.rootUrl + "/login");
		yield return new WaitForSeconds(1);
		if (www.isDone) {
			LoginInfo myInfo = JsonUtility.FromJson<LoginInfo> (www.text);
			if (myInfo != null && myInfo.success) {
				ID = myInfo.ID;
				this.gameObject.AddComponent<UpdateMe> ();
				initOthers ();
			}
		}
	}

	void initOthers(){
		playerManagerObj = Instantiate (playerManagerObj);
		You playerManager = playerManagerObj.GetComponent<You> ();
		playerManager.myID = ID;
	}

	void Awake(){
		ID = 0;
	}

	void Start () {
		
		aCar =  Instantiate (aCar);
		aCar.name = "MyCar";
		aCar.transform.parent = this.transform;
		controller = Instantiate (controller);
		StartCoroutine (login ());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
