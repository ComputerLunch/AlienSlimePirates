
using UnityEngine;

public enum DamageMethod
{
	damagedByCollision,
	damagedByProximity,
	damagedByProximityAndCollision
}

public enum DamageSourceTag
{
	WeaponCollisionObject,
	Enemy,
	Everything
}


public class ASP_Damageable : MonoBehaviour
{


	[SerializeField]
	protected DamageMethod damageMethod;

	[SerializeField]
	protected DamageSourceTag damageSource;

	[SerializeField]
	protected float proximityDamageInterval = 1;


	protected ParticleSystem particles;

	[SerializeField]
	protected int victoryPointValueWhenKilled = 50;

	[SerializeField]
	protected int hitPoints = 100;
	// Use this for initialization
	protected int damageReceived = 0;

	[SerializeField]
	protected GameObject particlesObject;

	public int HitPoints
	{
		get
		{
			return hitPoints;
		}
	}

	public void Setup(DamageMethod method, DamageSourceTag source, int hits, float proximityInterval, int pointvalue, GameObject partsObject)
	{
		damageMethod = method;
		damageSource = source;
		hitPoints = hits;
		proximityDamageInterval = proximityInterval;
		victoryPointValueWhenKilled = pointvalue;
		particlesObject = partsObject;
	}



	protected virtual void Start()
	{
		if (damageMethod == DamageMethod.damagedByProximity || damageMethod == DamageMethod.damagedByProximityAndCollision)
		{
			ASP_GameManager.Instance.RegisterNewProximityDamagableObject(this);
			InvokeRepeating("CheckForProximityDamage", 0, proximityDamageInterval);
		}

	}

	protected void OnCollisionEnter(Collision coll)
	{
		//if (CompareTag())
		//all damage inflicting things that can activate damage via collider need three things:
		// 1. A matching  Tag for the correct damage source (or an Everything DamageSourceTag)
		// 2. A damagedByCollision or damagedByProximityAndCollision damageMethod
		// 3. an attached ASP_WeaponDamage script
		//print("DAMAGE!!!!! " + coll.gameObject.tag + ", " + coll.gameObject.name);

		if (gameObject.name == "[VRTK][AUTOGEN][BodyColliderContainer]") {
			print ("Collision!!" + coll.gameObject.name);
		}

		if ((damageSource == DamageSourceTag.Everything || coll.gameObject.CompareTag(damageSource.ToString())) && (damageMethod == DamageMethod.damagedByCollision || damageMethod == DamageMethod.damagedByProximityAndCollision))
		{
			//all damage inflicting objects should have an ASP_WeaponDamage script
			ASP_WeaponDamage damageScript = coll.gameObject.GetComponent<ASP_WeaponDamage>();
			print("damageScript!!!!! " + damageScript);
			if (damageScript != null)
			{

				CauseDamage(damageScript.DamageInflicted);
			}
			else
			{
				//but, in case they don't
				//CauseDamage(0);
			}
		}
	}
	// check to see if objects causing proximity damage are nearby
	protected void CheckForProximityDamage()
	{
		ASP_ProximityDamage[] proximityDamageObjects = ASP_GameManager.Instance.GetProximityDamageObjects();
		for (int i = 0; i < proximityDamageObjects.Length; i++)
		{
			// See if this object can be damaged by this source, i.e. enemys cant damage each other through proximity
			if (damageSource == DamageSourceTag.Everything || proximityDamageObjects[i].gameObject.CompareTag(damageSource.ToString()))
			{
				if (CheckProximity(proximityDamageObjects[i]))
				{
					CauseDamage(proximityDamageObjects[i].DamageInflicted);
				}
			}
		}
	}
	protected bool CheckProximity(ASP_ProximityDamage damageObject)
	{
		return ((damageObject.gameObject.transform.position - transform.position).magnitude < damageObject.DamageRadius);

	}
	protected virtual void CauseDamage(int damage)
	{
		damageReceived += damage;

		print("damageReceived " + damageReceived);
		if (damageReceived >= hitPoints)
		{
			DestroySelf();
		}
	}



	protected void DestroySelf()
	{
		if (particlesObject != null)
		{
			Instantiate(particlesObject, transform.position, transform.rotation);
			//if (Physics.Raycast(transform.position, Vector3.down, 3)){

			//}

		}
		if (gameObject.CompareTag("Enemy"))
		{
			ASP_GameManager.Instance.IncrementScore(victoryPointValueWhenKilled);
			ASP_GameManager.Instance.UnRegisterNewProximityDamagableObject(this);
			ASP_GameManager.Instance.RegisterEnemyDeath();
			Destroy(gameObject);
		}
		else if (gameObject.CompareTag("Player"))
		{
			ASP_GameManager.Instance.GameOver(GameResult.PlayerLossDeath);
		}

	}


	public void AutoDamage(int damage)
	{
		CauseDamage(damage);
	}



}
