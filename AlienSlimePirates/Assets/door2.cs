using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door2 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter(Collider other) {
		GameObject thedoor = GameObject.FindWithTag("SF_Door") as GameObject;
		thedoor.GetComponent<Animation>().Play("open");
	}

	void OnTriggerExit(Collider other)
	{
		GameObject thedoor = GameObject.FindWithTag("SF_Door") as GameObject;
		thedoor.GetComponent<Animation>().Play("close");	}
}
