using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ASP_SlimeBulletDestroy : MonoBehaviour {
	[SerializeField]
	private GameObject SplatEffect;

	void OnCollisionEnter (Collision coll) {
		if (!coll.gameObject.CompareTag("Enemy")){
				GameObject splat = 	Instantiate(SplatEffect, transform.position, transform.rotation);
				ParticleSystem splatter = splat.GetComponent<ParticleSystem>();
				splatter.Play();
				Destroy(gameObject);
			}
	}
	
	
}
