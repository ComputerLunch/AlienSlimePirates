using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door2 : MonoBehaviour {
	private GameObject thedoor;
	// Use this for initialization
	void Start () {
		 thedoor = GameObject.FindWithTag("SF_Door") as GameObject;
	}
	
	// Update is called once per frame
	public void open () {
		thedoor.GetComponent<Animation>().Play("open");
	}

	/*
	void OnTriggerEnter(Collider other) {
		GameObject thedoor = GameObject.FindWithTag("SF_Door") as GameObject;
		thedoor.GetComponent<Animation>().Play("open");
	}

	void OnTriggerExit(Collider other)
	{
		GameObject thedoor = GameObject.FindWithTag("SF_Door") as GameObject;
		thedoor.GetComponent<Animation>().Play("close");	}

	*/
}
