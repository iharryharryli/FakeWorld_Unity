using UnityEngine;
using System.Collections;

[System.Serializable]
public class LoginInfo{
	public int ID;
	public bool success;
}

[System.Serializable]
public class Profile {
	public float xPos;
	public float yPos;
	public float zPos;
	public int steering;
	public int motor;
	public float xRot;
	public float yRot;
	public float zRot;
	public float wRot;

	public Profile(float x, float y, float z){
		xPos = x;
		yPos = y;
		zPos = z;
	}

	public Profile(Vector3 some, int a, int b, Quaternion ss){
		xPos = some.x;
		yPos = some.y;
		zPos = some.z;
		steering = a;
		motor = b;
		xRot = ss.x;
		yRot = ss.y;
		zRot = ss.z;
		wRot = ss.w;
	}
}

[System.Serializable]
public class UpdateInfo{
	public Profile profile;
	public int ID;

	public UpdateInfo(Profile p, int i){
		profile = p;
		ID = i;
	}
}

[System.Serializable]
public class OthersInfo{
	public UpdateInfo[] players;
}