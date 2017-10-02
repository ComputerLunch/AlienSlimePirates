
using UnityEngine;
using UnityEngine.UI;

// ASP_Core_Damageable is a specialized version of ASP_Damageable just for the core
public class ASP_Core_Damageable : ASP_Damageable
{

    //Text output of current damage
    [SerializeField]
    private ASP_PercentAnimator damagePercentText;
 [SerializeField]
    private ASP_InnerCylinderAnimator innerCylinder;

    protected override void Start()
    {
        //call base method of ASP_Core_Damageable
        base.Start();
        damagePercentText.UpdatePercent( 100);
    }


    protected override void CauseDamage(int damage)
    {
        damageReceived += damage;
        if (damageReceived >= hitPoints)
        {
			//destroyed
           	innerCylinder.UpdateValue(0);
            damagePercentText.UpdatePercent (0);
			ASP_GameManager.Instance.GameOver();
        }
        else
        {
			float newPercentage = 1-((float)damageReceived / (float)hitPoints);
			innerCylinder.UpdateValue(newPercentage);
            damagePercentText.UpdatePercent (System.Convert.ToInt32( newPercentage*100));
        }
    }
}
