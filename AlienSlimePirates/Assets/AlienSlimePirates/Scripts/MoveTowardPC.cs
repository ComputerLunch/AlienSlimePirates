using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveTowardPC : MonoBehaviour {

	public Transform targetCore;
	public Transform targetPlayer;
	public float playerDist;
	public float speed;

	private NavMeshAgent agent;

	void Start()
	{
		agent = gameObject.GetComponent<NavMeshAgent> ();
	}

	void Update() {

		float step = speed * Time.deltaTime;

		targetPlayer = GameObject.FindWithTag ("Player").transform; //position of player
		targetCore = GameObject.FindWithTag ("Core").transform; //position of core

		playerDist = Vector3.Distance (targetPlayer.position, transform.position);

		if (playerDist < 10f) {
			agent.SetDestination (targetPlayer.position);
			//transform.position = Vector3.MoveTowards (transform.position, targetPlayer.position, step);
			
		} else {
			agent.SetDestination (targetCore.position);
			//transform.position = Vector3.MoveTowards (transform.position, targetCore.position, step);
		}
	}
}
