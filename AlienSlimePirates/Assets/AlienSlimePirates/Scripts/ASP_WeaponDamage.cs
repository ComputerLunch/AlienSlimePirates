using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ASP_WeaponDamage : MonoBehaviour {


	[SerializeField]
	private int damageInflicted = 10;
	// Use this for initialization

	public int DamageInflicted
	{
		get
		{
			return damageInflicted;
		}
	}
}
