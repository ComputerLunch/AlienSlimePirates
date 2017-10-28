using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ASP_TextSwitch : MonoBehaviour {

	public Transform player;
	
	void Start () {
		//player = GameObject.FindWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
		if (player.position.x >transform.position.x)
		{
			
			transform.rotation= Quaternion.LookRotation(Vector3.left, Vector3.up);
		} else
		{

		
		transform.rotation= Quaternion.LookRotation(Vector3.right, Vector3.up);

		}
	}
}
