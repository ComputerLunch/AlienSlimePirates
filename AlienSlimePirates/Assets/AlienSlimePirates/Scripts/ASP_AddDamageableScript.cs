using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ASP_AddDamageableScript : MonoBehaviour
{

    [SerializeField]
    protected DamageMethod damageMethod;

    [SerializeField]
    protected DamageSourceTag damageSource;

    [SerializeField]
    protected float proximityDamageInterval = 1;

    [SerializeField]
    protected int victoryPointValueWhenKilled = 50;

    [SerializeField]
    protected int hitPoints = 100;
    // Use this for initialization


    [SerializeField]
    protected GameObject particlesObject;

    GameObject VRTK_PlayerBody;
    // Use this for initialization


    // Update is called once per frame
    void Update()
    {
        if (VRTK_PlayerBody == null)
        {
            VRTK_PlayerBody = GameObject.Find("[VRTK][AUTOGEN][BodyColliderContainer]");
            if (VRTK_PlayerBody != null)
            {
                ASP_Damageable newScript = VRTK_PlayerBody.AddComponent(typeof(ASP_Damageable)) as ASP_Damageable;
                newScript.Setup(damageMethod, damageSource, hitPoints, proximityDamageInterval, victoryPointValueWhenKilled, particlesObject);
                this.enabled = false;
            }
        }
    }
}
