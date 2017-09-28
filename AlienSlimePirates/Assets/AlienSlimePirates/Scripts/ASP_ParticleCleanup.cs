using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ASP_ParticleCleanup : MonoBehaviour {

	private float startTime;
	[SerializeField]
	private float minimumDelay = 2;

	private ParticleSystem particles;
	// Use this for initialization
	void Start () {
		startTime = Time.time;
		particles = GetComponent<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () {
		if (startTime + minimumDelay < Time.time && particles.particleCount <=0){
			Destroy(gameObject);
		}
	}
}
