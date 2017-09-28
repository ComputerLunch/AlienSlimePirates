using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ASP_ProximityDamage : MonoBehaviour {
	

	[SerializeField]
	private float damageRadius = 2;

	public float DamageRadius
	{
		get
		{
			return damageRadius;
		}
	}

	[SerializeField]
	private int damageInflicted = 2;

	public int DamageInflicted
	{
		get
		{
			return damageInflicted;
		}
	}

	[SerializeField]
	private bool showDamageGizmo = false;



	// Use this for initialization
	void Start () {
		
			ASP_GameManager.Instance.RegisterNewProximityDamageObject (this);


	}
	
	void OnDestroy(){
			ASP_GameManager.Instance.UnRegisterNewProximityDamageObject (this);
	}


	void OnDrawGizmos(){
		if (showDamageGizmo) {
			Gizmos.color = Color.red;
			Gizmos.DrawWireSphere (transform.position, damageRadius);
		}
	}


}
