
using UnityEngine;




public class ASP_Damageable : MonoBehaviour
{
	private enum DamageMethod{
		damagedByCollision,
		damagedByProximity,
		damagedByProximityAndCollision
	}

	private enum DamageSourceTag{
		Player,
		Enemy,
		Everything
	}

	[SerializeField] 
	private DamageMethod damageMethod;

	[SerializeField] 
	private DamageSourceTag damageSource;

	[SerializeField]
	private float CheckForProximityDamageInterval = 1;

	[SerializeField] 
	private GameObject particlesObject;

	private ParticleSystem particles;

	[SerializeField]
	private int VictoryPointValueWhenKilled = 50;

	[SerializeField]
	private int hitPoints = 100;
	// Use this for initialization
	private int damageReceived  = 0;


	public int HitPoints
	{
		get
		{
			return hitPoints;
		}
	}
		

	private void Start()
	{
		if (damageMethod == DamageMethod.damagedByProximity ||  damageMethod == DamageMethod.damagedByProximityAndCollision ){
			ASP_GameManager.Instance.RegisterNewProximityDamagableObject (this);
			InvokeRepeating ("CheckForProximityDamage", 0, CheckForProximityDamageInterval);
		}

	}

	private void OnCollisionEnter(Collision  coll)
    {

		//all damage inflicting things that can activaet damage via collider need three things:
		// 1. A matching  Tag foir the correct damage source (or an Everything DamageSourceTag
		// 2. A damagedByCollision or damagedByProximityAndCollision damageMethod
		// 3. an attached ASP_WeaponDamage script


		if (( damageSource == DamageSourceTag.Everything || coll.gameObject.CompareTag(damageSource.ToString())) && (damageMethod==DamageMethod.damagedByCollision || damageMethod== DamageMethod.damagedByProximityAndCollision))
		{
			//all damage inflicting objects shoudl have an ASP_WeaponDamage script
			ASP_WeaponDamage damageScript = coll.gameObject.GetComponent<ASP_WeaponDamage>();

			if (damageScript != null){
				CauseDamage(damageScript.DamageInflicted);
			} else {
				//but, in case they don't
				//CauseDamage(0);
			}
        }
    }
	// check to see if objects causing proximity damage are nearby
	private void CheckForProximityDamage()
	{	
		ASP_ProximityDamage[] proximityDamageObjects = ASP_GameManager.Instance.GetProximityDamageObjects ();
		for (int i= 0; i < proximityDamageObjects.Length; i++){
			// See if this object can be damaged by this source, i.e. enemys cant damage each other through proximity
			if (   damageSource == DamageSourceTag.Everything ||  proximityDamageObjects[i].gameObject.CompareTag(damageSource.ToString())){
				if (CheckProximity (proximityDamageObjects[i])) {
					CauseDamage (proximityDamageObjects [i].DamageInflicted);

					print ("Proximity Damage Detected");
				}
			}
		}
	}
	private bool CheckProximity(ASP_ProximityDamage damageObject)
	{
		return ((damageObject.gameObject.transform.position - transform.position).magnitude < damageObject.DamageRadius);

	}
    private void CauseDamage(int damage)
    {
		damageReceived += damage;
		if (damageReceived >= hitPoints){
			DestroySelf();
		}
    }
	private void DestroySelf()
	{
		if (particlesObject != null){
			Instantiate(particlesObject, transform.position, transform.rotation);
			//if (Physics.Raycast(transform.position, Vector3.down, 3)){
				
			//}

		}
		ASP_GameManager.Instance.IncrementScore (VictoryPointValueWhenKilled);
		ASP_GameManager.Instance.UnRegisterNewProximityDamagableObject (this);
		Destroy(gameObject);
	}





}
