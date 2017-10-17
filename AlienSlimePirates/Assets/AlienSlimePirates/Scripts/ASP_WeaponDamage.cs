using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ASP_WeaponDamage : MonoBehaviour {

	public AudioClip damageSoundEffect;

	[SerializeField]
	private int damageInflicted = 10;
	// Use this for initialization

	public int DamageInflicted
	{
		get
		{
			if (damageSoundEffect) {
				AudioSource audios = gameObject.GetComponent<AudioSource> ();
				if (audios) {
					audios.clip = damageSoundEffect;
					audios.Play ();
				}
			}
			return damageInflicted;
		}
	}
}
