using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK.Examples;

public class ASP_AutoStartLightSaber : MonoBehaviour {

	// Use this for initialization
	void Start () {
		LightSaber lightsaber = GetComponent<LightSaber> ();
		lightsaber.StartUsing (lightsaber.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
