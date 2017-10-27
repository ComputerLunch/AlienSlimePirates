using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShipAnimation : MonoBehaviour {

	float amplitudeX = 0f;
	float amplitudeY = 5.0f;
	float omegaX = 0f;
	float omegaY = 1.0f;
	float index;
	public void Update(){
		index += Time.deltaTime;
		float x = amplitudeX*Mathf.Cos (omegaX*index);
		float y = Mathf.Abs (amplitudeY*Mathf.Sin (omegaY*index));
		transform.localPosition= new Vector3(x,y,0);
	}
}
