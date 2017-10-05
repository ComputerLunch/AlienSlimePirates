using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

	public static int enemyCount;
	public static int maxEnemy;
	public GameObject enemySlime;

	// Use this for initialization
		
	void Start () {
		enemyCount = 0;
		maxEnemy = 10;
		Invoke ("SpawnEnemy", 1f);
	}

	void SpawnEnemy(){

		if (enemyCount < maxEnemy) {
			Instantiate (enemySlime, gameObject.transform.position, Quaternion.identity);
			enemyCount++;
			Invoke ("SpawnEnemy", Random.Range(5f,15f));
		}
	}

}
