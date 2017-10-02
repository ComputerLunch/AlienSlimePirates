
using UnityEngine;




public class ASP_Damageable : MonoBehaviour
{
    protected enum DamageMethod
    {
        damagedByCollision,
        damagedByProximity,
        damagedByProximityAndCollision
    }

    protected enum DamageSourceTag
    {
        Player,
        Enemy,
        Everything
    }

    [SerializeField]
    protected DamageMethod damageMethod;

    [SerializeField]
    protected DamageSourceTag damageSource;

    [SerializeField]
    protected float CheckForProximityDamageInterval = 1;

    [SerializeField]
    protected GameObject particlesObject;

    protected ParticleSystem particles;

    [SerializeField]
    protected int VictoryPointValueWhenKilled = 50;

    [SerializeField]
    protected int hitPoints = 100;
    // Use this for initialization
    protected int damageReceived = 0;


    public int HitPoints
    {
        get
        {
            return hitPoints;
        }
    }


    protected virtual void Start()
    {
        if (damageMethod == DamageMethod.damagedByProximity || damageMethod == DamageMethod.damagedByProximityAndCollision)
        {
            ASP_GameManager.Instance.RegisterNewProximityDamagableObject(this);
            InvokeRepeating("CheckForProximityDamage", 0, CheckForProximityDamageInterval);
        }

    }

    protected void OnCollisionEnter(Collision coll)
    {

        //all damage inflicting things that can activaet damage via collider need three things:
        // 1. A matching  Tag foir the correct damage source (or an Everything DamageSourceTag
        // 2. A damagedByCollision or damagedByProximityAndCollision damageMethod
        // 3. an attached ASP_WeaponDamage script


        if ((damageSource == DamageSourceTag.Everything || coll.gameObject.CompareTag(damageSource.ToString())) && (damageMethod == DamageMethod.damagedByCollision || damageMethod == DamageMethod.damagedByProximityAndCollision))
        {
            //all damage inflicting objects shoudl have an ASP_WeaponDamage script
            ASP_WeaponDamage damageScript = coll.gameObject.GetComponent<ASP_WeaponDamage>();

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

                    print("Proximity Damage Detected");
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
        ASP_GameManager.Instance.IncrementScore(VictoryPointValueWhenKilled);
        ASP_GameManager.Instance.UnRegisterNewProximityDamagableObject(this);
        Destroy(gameObject);
    }





}
