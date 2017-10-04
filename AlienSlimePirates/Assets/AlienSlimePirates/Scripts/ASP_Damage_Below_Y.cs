using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ASP_Damageable))]
public class ASP_Damage_Below_Y : MonoBehaviour
{
    [SerializeField]
    private float minYAllowable = -5;
    [SerializeField]
    private int damageAmount = 1000;
    private ASP_Damageable damageScript;

    void Start()
    {
        damageScript = GetComponent<ASP_Damageable>();
    }

    void Update()
    {
        if (transform.position.y < minYAllowable)
        {
            damageScript.AutoDamage(damageAmount);
        }
    }
}
