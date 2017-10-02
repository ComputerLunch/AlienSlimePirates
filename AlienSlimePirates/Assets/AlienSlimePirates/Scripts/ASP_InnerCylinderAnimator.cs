using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ASP_InnerCylinderAnimator : MonoBehaviour
{

    // Use this for initialization



    private float currentValue = 1;
    private float targetValue = 1;
    [SerializeField]
    private float ScaleAmountPerTick = 0.01f;

    //
    // Update is called once per frame
    public void UpdateValue(float newNumber)
    {
        targetValue = newNumber;
   
    }
    void Update()
    {

        if (currentValue > targetValue)
        {
            currentValue -= ScaleAmountPerTick * Time.deltaTime;
         
            if (currentValue > 0)
            {
                transform.localScale = new Vector3(1, currentValue, 1);
            }
            else
            {
                currentValue = 0;
                targetValue = 0;
                transform.localScale = new Vector3(1, 0, 1);
            }

        }


    }

}
