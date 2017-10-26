using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ASP_AdjustPlayerPhysics : MonoBehaviour {
	private Vector3 startPosition;

	private int killAllVelocityFlag = 0;
	private bool softLandingFlag = false;
	[SerializeField]
	private Transform LiftLandingTarget;
	[SerializeField]
	private float softLandingTime = 1;
	private float startTime = 0;
	// Use this for initialization
	public void KillAllPlayerVelocity () {
		//print ("*** KillAllPlayerVelocity***");
		killAllVelocityFlag = 2;
		softLandingFlag = false;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (killAllVelocityFlag>0) {
			//print ("KillAllPlayerVelocity");
			//killAllVelocityFlag = false;
			killAllVelocityFlag--;
			Rigidbody[] RBs = GetComponentsInChildren<Rigidbody> () as Rigidbody[];
			for (int i = 0; i < RBs.Length; i++) {
				//print ("  RB " + i + ": " + RBs [i].gameObject.name); 
				RBs [i].velocity = Vector3.zero;
				startPosition = transform.position;
				startTime = Time.time;
				softLandingFlag = true;
			}
		}
		if (softLandingFlag) {
			float t = (Time.time - startTime) / softLandingTime;
			transform.position = Vector3.Lerp (startPosition, LiftLandingTarget.position, t);

			if (t >= 1) {

				//print ("*** Kill flag***");
				softLandingFlag = false;
			}
		}
	}
}
