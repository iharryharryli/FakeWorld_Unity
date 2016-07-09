using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class ServerStart : MonoBehaviour {

	// Use this for initialization
	void Start () {
		NetworkManager manager = transform.GetComponent<NetworkManager>();
		manager.StartServer ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
