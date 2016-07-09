using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public GameObject player;
	void Start () {
		

	}

	// Update is called once per frame
	void Update () {
		if(player == null)return;
		else{
			this.transform.position = player.transform.position + (new Vector3 (8,8,8));
			this.transform.LookAt (player.transform);
		}
	}
}
