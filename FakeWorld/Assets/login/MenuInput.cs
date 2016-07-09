using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuInput : MonoBehaviour {

	public GameObject address;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void test(){

		InputField input = address.GetComponent<InputField> ();

		Global.rootUrl = input.text + ":3000";

		SceneManager.LoadScene ("MainScene");

	}
}
