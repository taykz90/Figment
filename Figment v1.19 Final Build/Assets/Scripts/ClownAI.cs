using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClownAI : MonoBehaviour {

	public Transform[] patrolPoints;
	public float speed;
	Transform currentPatrolPoint;
	int currentPatrolIndex;
	public Transform targetPlayer;
	public float chaseRange;

	private float touch = 1f;

	bool hasDetected = false;

	// Use this for initialization
	void Start () {
		currentPatrolIndex = 0;
		currentPatrolPoint = patrolPoints[currentPatrolIndex];
	}

	// Update is called once per frame
	void Update () {
		// Get the distance to target and check if it is within chaseRange
		float distanceToTarget = Vector3.Distance(transform.position, targetPlayer.position);
		if (distanceToTarget < chaseRange)
		{
			hasDetected = true;
		}

		// Patrol while player has not been detected, chase player when detected
		if (hasDetected == false)
		{
			Patrol();
		} else
		{
			ChasePlayer();
		}
	}

	void Patrol()
	{
		// Enemy Patrol Code
		transform.Translate(Vector3.up * Time.deltaTime * speed);
		// Check to see if we have reached the patrol point
		if (Vector3.Distance(transform.position, currentPatrolPoint.position) <= touch)
		{
			Debug.Log("Check entered");
			// We have reached the patrol point, getting the next one
			// Check to see if we have any more patrol points, if not go back to beginning
			if (currentPatrolIndex + 1 < patrolPoints.Length)
			{
				currentPatrolIndex++;
			}
			else
			{
				currentPatrolIndex = 0;
			}
			currentPatrolPoint = patrolPoints[currentPatrolIndex];
		}
		// Turn to face current patrol point
		// Finding direction Vector that points to patrolPoint
		Vector3 patrolPointDir = currentPatrolPoint.position - transform.position;
		//Figure out the rotation in degrees that we need to turn towards
		float angle = Mathf.Atan2(patrolPointDir.y, patrolPointDir.x) * Mathf.Rad2Deg-90f;
		// Make the rotation that we need to face patrolPoint
		Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
		// Apply the rotation to the transform
		// The float values denotes the turn speed, can consider making it public
		transform.rotation = Quaternion.RotateTowards(transform.rotation, q, 90f);
	}

	void ChasePlayer()
	{
		// Chasing Player Code
		// Start chasing the target, turn and move towards target
		Vector3 targetDir = targetPlayer.position - transform.position;
		float angle1 = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg - 90f;
		Quaternion q1 = Quaternion.AngleAxis(angle1, Vector3.forward);
		transform.rotation = Quaternion.RotateTowards(transform.rotation, q1, 180);
		transform.Translate(Vector3.up * Time.deltaTime * speed);


	}

	PlayerHealthManager p;

	Collision2D c;
	//public GameObject bullet;

	private void OnCollisionEnter2D(Collision2D col)
	{
		//bullet = col.gameObject.GetComponent<GameObject> ();

		if (col.transform.tag == "Player") 
		{
			p = col.gameObject.GetComponent<PlayerHealthManager> ();
			p.HurtPlayer (1);
			Debug.Log("Hit Player");

			//Animation of the player getting hurt

		}
			
	}

	/*
	public Collider2D c;
	void OnColliderEnter2D(Collider2D col)
	{
		c = col.gameObject.GetComponent<Collider2D> ();

		if (c.gameObject.CompareTag ("GameController")) {
			Debug.Log ("Bullet Caught");

		}
	}
	*/
}
