using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LesserEnemyBehavior: MonoBehaviour {

	public Transform targetCore;
	public Transform targetPlayer;
	public float speed;

	public GameObject enemyBullet;
	public Rigidbody enemyBulletRB;
	public Transform enemyShotSpawn;
	public float enemyFireRate;
	public float enemyBulletSpeed;

	private float playerDist;
	private float coreDist;
	private float enemyNextFire;

	private NavMeshAgent agent;

	void Start()
	{
		agent = gameObject.GetComponent<NavMeshAgent> ();
	}

	void Update() {

		float step = speed * Time.deltaTime;

		targetPlayer = GameObject.FindWithTag ("Player").transform; //position of player
		targetCore = GameObject.FindWithTag ("Core").transform; //position of core

		playerDist = Vector3.Distance (targetPlayer.position, transform.position);
		coreDist = Vector3.Distance (targetCore.position, transform.position);

		if (playerDist > 15f || coreDist > 15f) {
			//agent.SetDestination (targetPlayer.position);
			transform.position = Vector3.MoveTowards (transform.position, targetPlayer.position, step);
		}

		if (Time.time > enemyNextFire) {
			
			enemyNextFire = Time.time + enemyFireRate;
			GameObject bullet = Instantiate (enemyBullet, enemyShotSpawn.position, enemyShotSpawn.rotation);
			enemyBulletRB = bullet.GetComponent<Rigidbody> ();
			enemyBulletRB.AddForce ((targetCore.position - transform.position).normalized * enemyBulletSpeed);
			Destroy (bullet, 2f);

		}


	}
}
