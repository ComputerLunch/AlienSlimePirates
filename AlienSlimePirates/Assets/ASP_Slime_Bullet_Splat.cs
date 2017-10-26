using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ASP_Slime_Bullet_Splat : MonoBehaviour {
	[SerializeField]
	private GameObject SplatEffect;
	// Use this for initialization

	

	void OnDestroy () {
		Instantiate(SplatEffect, transform);
	}
}
