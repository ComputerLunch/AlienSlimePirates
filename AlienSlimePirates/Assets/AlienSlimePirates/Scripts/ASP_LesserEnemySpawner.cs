using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ASP_LesserEnemySpawner : MonoBehaviour, ISpawner {
	public  float enemySpawnDelay = 55 ;
	public  int enemyCount = 0 ;
	public  int maxEnemy = 10;
	public GameObject enemySlime;

	// Use this for initialization
		
	void Start () {
		//enemyCount = 0;
		//maxEnemy = 10;
		//Invoke ("SpawnEnemy", enemySpawnDelay);
		ASP_GameManager.Instance.RegisterLevelEnemies(maxEnemy);
		ASP_GameManager.Instance.RegisterSpawner(this);
	}
	public void StartSpawning () {
		Invoke ("SpawnEnemy", enemySpawnDelay);
	}
	void SpawnEnemy(){

		if (enemyCount < maxEnemy) {
			Instantiate (enemySlime, gameObject.transform.position, Quaternion.identity);
			enemyCount++;
			Invoke ("SpawnEnemy", Random.Range(30f,60f));
		}
	}

}
