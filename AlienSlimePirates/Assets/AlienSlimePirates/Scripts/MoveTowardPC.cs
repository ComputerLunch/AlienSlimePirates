using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardPC : MonoBehaviour {

	public Transform targetCore;
	public Transform targetPlayer;
	public float playerDist;
	public float speed;

	void Start()
	{

	}

	void Update() {

		float step = speed * Time.deltaTime;

		targetPlayer = GameObject.FindWithTag ("Player").transform; //position of player
		targetCore = GameObject.FindWithTag ("Core").transform; //position of core

		playerDist = Vector3.Distance (targetPlayer.position, transform.position);

		if (playerDist < 0.1f) {
			transform.position = Vector3.MoveTowards (transform.position, targetPlayer.position, step);
			
		} else {
			transform.position = Vector3.MoveTowards (transform.position, targetCore.position, step);
		}
	}
}
