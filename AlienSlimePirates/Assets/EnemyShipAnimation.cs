using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShipAnimation : MonoBehaviour {

	public float amplitudeX = 0f;
	public float amplitudeY = 5.0f;
	public float omegaX = 0f;
	public float omegaY = 1.0f;
	public float index;
	public void Update(){
		index += Time.deltaTime;
		float x = amplitudeX*Mathf.Cos (omegaX*index);
		float y = Mathf.Abs (amplitudeY*Mathf.Sin (omegaY*index));
		float z = transform.localPosition.z;
		transform.localPosition= new Vector3(x,y,z);
	}
}
