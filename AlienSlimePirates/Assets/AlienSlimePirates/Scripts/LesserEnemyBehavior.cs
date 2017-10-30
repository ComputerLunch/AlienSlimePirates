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
	public float shootDistanceDelta = 4;
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

			float distanceToPlayer = (targetPlayer.position - transform.position).magnitude +  Random.Range(0, shootDistanceDelta);
			float distanceToCore = (targetCore.position - transform.position).magnitude +  Random.Range(0, shootDistanceDelta);
			enemyNextFire = Time.time + enemyFireRate;
			Quaternion shotDirection;
			Transform  targetTransform;
			if (distanceToPlayer < distanceToCore)
			{
				targetTransform = targetPlayer;
				shotDirection = Quaternion.LookRotation(((targetTransform.position +  new Vector3(0, 1.5f,0) )- transform.position).normalized , Vector3.up);
			} else {
					targetTransform = targetCore;
				 shotDirection = Quaternion.LookRotation((targetTransform.position - transform.position).normalized, Vector3.up);
			}

		
			GameObject bullet = Instantiate (enemyBullet, enemyShotSpawn.position, shotDirection);
			enemyBulletRB = bullet.GetComponent<Rigidbody> ();
			enemyBulletRB.AddForce ((targetTransform.position - transform.position).normalized * enemyBulletSpeed);
			//Destroy (bullet, 2f);

		}


	}
}
