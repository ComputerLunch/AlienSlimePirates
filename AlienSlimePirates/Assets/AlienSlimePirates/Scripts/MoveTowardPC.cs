using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardPC : MonoBehaviour {

	public Transform target;
	public float speed;

	void Start()
	{

	}

	void Update() {

		target = GameObject.FindWithTag("Player").transform; 

		float step = speed * Time.deltaTime;
		transform.position = Vector3.MoveTowards(transform.position, target.position, step);
	}
}
