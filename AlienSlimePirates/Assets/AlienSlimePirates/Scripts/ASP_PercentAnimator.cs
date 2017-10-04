using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class ASP_PercentAnimator : MonoBehaviour
{
    private Text percentText;
    private int currentValue = 100;
    private int targetValue = 100;
    [SerializeField]
    private float PercentUpdateTick = 0.01f;

    void Start()
    {
        percentText = GetComponent<Text>();
        InvokeRepeating("CountDownPercent", 0f, PercentUpdateTick);
    }
    //
    // Update is called once per frame
    public void UpdatePercent(int newNumber)
    {
        targetValue = newNumber;
    }
    void CountDownPercent()
    {
        if (currentValue != targetValue)
        {
            currentValue--;
            if (currentValue >= 0)
            {
                percentText.text = currentValue.ToString() + "%";
            }
            else
            {
                percentText.text = "0%";
            }

        }


    }

}
