using UnityEngine;
using System.Collections;


public class Utility{
	public static WWW sendJSON(string url, string json){
		var form = new WWWForm();
		form.AddField( "data", json );
		WWW www = new WWW(url,form);
		return www;
	}

	public static WWW visitUrl(string url){
		WWW www = new WWW (url);
		return www;
	}
}

