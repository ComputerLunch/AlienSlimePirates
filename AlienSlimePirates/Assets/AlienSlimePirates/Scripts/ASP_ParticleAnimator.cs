using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(ParticleSystem))]
public class ASP_ParticleAnimator : MonoBehaviour
{
    private ParticleSystem particles;
    private float maxLifetime;
   // private float currentValue = 1;
    private float targetValue = 1;
   // [SerializeField]
    //private float ScaleAmountPerTick = 0.01f;


    void Start()
    {
        particles = GetComponent<ParticleSystem>();
        var main = particles.main;
        maxLifetime = main.startLifetime.constant;
 
    }

    public void UpdateValue(float newNumber)
    {

        targetValue = newNumber;

    }
    void Update()
    {
       // if (currentValue > targetValue)
      // {
            //currentValue -= ScaleAmountPerTick * Time.deltaTime;

			//currentValue = targetValue;
			//print("currentValue " + currentValue);
            var main = particles.main;

            if (targetValue > 0)
            {
                main.startLifetime = targetValue * maxLifetime;

            }
            else
            {
               // currentValue = 0;
                targetValue = 0;
                main.startLifetime = 0;
                particles.Stop();
            }
      //  }
    }
}
