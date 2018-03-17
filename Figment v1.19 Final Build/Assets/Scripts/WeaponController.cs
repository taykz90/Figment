using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour {

	public bool isFiring;
	public bool isStabbing;

	public BulletBehaviour bullet;
	public float bulletSpeed;

	public float timeBetweenShots;
	public float shotCounter;

	public Transform firePoint;

	BulletBehaviour newBullet;
	// Use this for initialization


	public Clown_EnemyHealthManager ce;


	void Start () {
		
	}

	// Update is called once per frame
	void Update ()
	{
		
		if (isFiring) {
			shotCounter -= Time.deltaTime;

			if (shotCounter < 0) {
				shotCounter = timeBetweenShots;
				// create new instance of the object with ALL the attributes of Bulletbehaviour
				newBullet = Instantiate (bullet, firePoint.position, firePoint.rotation) as BulletBehaviour;
				newBullet.speed = bulletSpeed;

			}

		}

		//offset of the raycast
		// position in x and y + offset direction and value

		else
		if (isStabbing) {
			//Startpoint of the raycast
			Vector2 pos = this.transform.position + transform.right * 1.0f;
			shotCounter -= Time.deltaTime;

			if (shotCounter < 0) {
				shotCounter = timeBetweenShots;
				Debug.Log ("melee mode");
			
				//RaycastHit2D (start point,direcction,distance)
				RaycastHit2D ray = Physics2D.Raycast (pos, new Vector2 (transform.right.x, transform.right.y),2.0f);
					Debug.DrawRay (pos, new Vector2 (transform.right.x, transform.right.y), Color.green);

				//Animation for melee attack here

				if (ray.collider != null) {
					if (ray.collider.gameObject.tag == "ClownEnemy") {
						
						//if object hit is less than X away from this object
						//if (ray.distance <= 10) 
						//{
							Debug.Log ("Enemy hit by melee");
							ce = ray.collider.gameObject.GetComponent<Clown_EnemyHealthManager> ();
							ce.Melee_HurtEnemy (1);
						//}

					}
				}
			
			}

	
		} else {
			shotCounter = 0;

		}
	
	}



}//end of script
