using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ASP_LesserEnemySpawner : MonoBehaviour {
	public  float enemySpawnDelay = 25 ;
	public  int enemyCount = 0 ;
	public  int maxEnemy = 10;
	public GameObject enemySlime;

	// Use this for initialization
		
	void Start () {
		//enemyCount = 0;
		//maxEnemy = 10;
		Invoke ("SpawnEnemy", enemySpawnDelay);
		ASP_GameManager.Instance.RegisterLevelEnemies(maxEnemy);
	}

	void SpawnEnemy(){

		if (enemyCount < maxEnemy) {
			Instantiate (enemySlime, gameObject.transform.position, Quaternion.identity);
			enemyCount++;
			Invoke ("SpawnEnemy", Random.Range(10f,25f));
		}
	}

}
