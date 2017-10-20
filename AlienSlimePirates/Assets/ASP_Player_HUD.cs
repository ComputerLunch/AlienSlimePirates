using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ASP_Player_HUD : MonoBehaviour {

	[SerializeField]
	private Text currentScoreLabel;
	[SerializeField]
	private Text currentScoreOutput;

	[SerializeField]
	private Image playerDamageImage;
	[SerializeField]
	private Image playerHealthImage;
	[SerializeField]
	private float playerDamage_zero;
	[SerializeField]
	private float playerDamage_Max;


	[SerializeField]
	private Image coreDamageImage;
	[SerializeField]
	private Image coreHealthImage;
	[SerializeField]
	private float coreDamage_zero;
	[SerializeField]
	private float coreDamage_Max;
	// Use this for initialization
	void Start () {
		//currentScoreLabel.enabled = true;
		//currentScoreOutput.enabled = true;
		playerHealthImage.gameObject.SetActive (true);
		playerDamageImage.gameObject.SetActive (true);
		playerDamageImage.rectTransform.localPosition = new Vector3 (playerDamageImage.transform.localPosition.x, playerDamage_zero, playerDamageImage.transform.localPosition.z);
		coreHealthImage.gameObject.SetActive (true);
		coreDamageImage.gameObject.SetActive (true);
		coreDamageImage.rectTransform.localPosition = new Vector3 (coreDamageImage.transform.localPosition.x, coreDamage_zero, coreDamageImage.transform.localPosition.z);

	}
	
	// Update is called once per frame
	public void PlayerDamaged(float damagePercent){

		//print ("PlayerDamaged "+ damagePercent );
		float difference = playerDamage_zero - playerDamage_Max;
		float newY = playerDamage_zero - difference * damagePercent;
		//print ("newY " + newY);
		playerDamageImage.transform.localPosition =  new Vector3 (playerDamageImage.transform.position.x,newY, playerDamageImage.transform.position.z);

	}

	public void CoreDamaged(float damagePercent){

		print ("CoreDamaged "+ damagePercent );
		float difference = coreDamage_zero - coreDamage_Max;
		float newY = coreDamage_zero - difference * damagePercent;
		//print ("newY " + newY);
		coreDamageImage.transform.localPosition =  new Vector3 (coreDamageImage.transform.localPosition.x,newY, coreDamageImage.transform.localPosition.z);

	}

	public void SetNewScore(string newScore)
	{
		currentScoreOutput.text = newScore;
	}

}
