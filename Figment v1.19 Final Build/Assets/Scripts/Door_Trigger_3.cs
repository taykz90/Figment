using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Trigger_3 : MonoBehaviour {
	public GameObject doorRef;

	public GameObject door;

	Collider2D p;


	control diary;


	// Use this for initialization
	void Start () {

		door.GetComponent<GameObject> ();
		door.SetActive (false);

	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D (Collider2D col)
	{
		p = col.gameObject.GetComponent<Collider2D> ();
		diary = col.gameObject.GetComponent<control> ();

		if (p.gameObject.CompareTag ("Player")) 
		{
			//if player enter and diaryCount = 1
			if (diary.diaryCount == 3) 
			{
				//Debug.Log (diary.diaryCount);   
				Debug.Log ("Door unlock");

				//Disable the dorr collider
				doorRef.GetComponent<Collider2D> ().enabled = false;

				//Animation of door
				door.SetActive (true);

			}

		}


	}
}
