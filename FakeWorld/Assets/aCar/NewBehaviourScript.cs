using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {

	// Use this for initialization
	GameObject car;
	public GameObject carBody;
	public GameObject aWheel;

	void Start () {
		car = new GameObject();
		Rigidbody rr =  car.AddComponent<Rigidbody> () as Rigidbody;
		//rr.useGravity = false;

		carBody = Instantiate (carBody);
		carBody.transform.parent = car.transform;
		carBody.transform.localPosition = Vector3.zero;


		GameObject carEntity = new GameObject ();

		carEntity.transform.parent = car.transform;
		carEntity.name = "carEntity";
		carEntity.transform.localPosition = Vector3.zero;

		for (int i = 0; i < 2; i++) {
			Transform t = carBody.transform.GetChild (i) as Transform;
			BoxCollider x = carEntity.AddComponent<BoxCollider> () as BoxCollider;
			x.center = t.localPosition;
			x.size = t.localScale;
		}

		for (int i = 2; i < 6; i++) {
			Transform t = carBody.transform.GetChild (i) as Transform;
			GameObject x = Instantiate (aWheel);
			x.transform.parent = carEntity.transform;
			x.transform.position = t.localPosition;
			WheelCollider actual = x.GetComponent<WheelCollider> () as WheelCollider;
			actual.radius = t.localScale.x / 2;
			actual.suspensionDistance = 0.05F;
		}



	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
