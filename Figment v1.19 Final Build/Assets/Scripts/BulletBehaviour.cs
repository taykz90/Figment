using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour {

	public float speed;

	public GameObject bu;

	public float distance = 0.8f;


	// Use this for initialization
	void Start () {
		
	}

	//char face right, so the projectile should also be in x-direction
	// Update is called once per frame
	void Update ()
	{
		transform.Translate (Vector3.right * speed * Time.deltaTime);

		//destroy clone object after x sec
		Destroy (GameObject.Find("Bullet(Clone)"),1);

		/*
		if (bu = GameObject.Find ("Bullet(Clone)")) {
			if (Vector3.Distance (transform.position, bu.transform.position) > (distance * distance)) {
				Destroy (bu);
			}

		
		}*/
	}

	public EnemyHealthManager e;

	//Clown_EnemyHealthManager clown;

	private void OnCollisionEnter2D(Collision2D col)
	{

		// if hits anything with tag "Environment", destroy the instance of the bullet
		if (col.transform.tag == "Environment") 
		{
			//Debug.Log ("hit");
			Destroy (this.gameObject);

		}

		if (col.transform.tag == "Enemy") 
		{
			//Debug.Log ("Enemy Hit");
			e=col.gameObject.GetComponent<EnemyHealthManager>();
			e.Water_HurtEnemy (1);

			Destroy (this.gameObject);

		}

		if (col.transform.tag == "ClownEnemy") 
		{
			//Debug.Log ("Enemy Hit");
			//clown=col.gameObject.GetComponent<Clown_EnemyHealthManager>();
	
			Destroy (this.gameObject);

		}
	}


}//end of script
