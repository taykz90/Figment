using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_orbit : MonoBehaviour {

	//public GameObject boss;
	public Transform target;

	public float orbitDistance = 10.0f;

	public float orbitDegreePerSec = 180.0f;

	public Vector3 relativeDistance = Vector3.zero;

	//public float speed;

	// Use this for initialization
	void Start () {


			relativeDistance = transform.position - target.position;

	}
	
	// Update is called once per frame
	//void Update () {
		//orbitAround ();
	//}

	void orbitAround()
	{
			// orbit at any specific point
			//transform.position = target.position + relativeDistance;

			//orbit at a fixed distance
			transform.position = target.position + (transform.position - target.position).normalized * orbitDistance;
			transform.RotateAround (target.position, Vector3.forward, orbitDegreePerSec * Time.deltaTime);
			relativeDistance = transform.position - target.position;


	}
	void FixedUpdate()
	{
		orbitAround ();

	}

	PlayerHealthManager p;

	private void OnCollisionEnter2D(Collision2D col)
	{
		if (col.transform.tag == "Player") 
		{
			p = col.gameObject.GetComponent<PlayerHealthManager> ();
			p.HurtPlayer (1);
			Debug.Log("Hit Player");

			//Animation of the player getting hurt

		}
	}
}
