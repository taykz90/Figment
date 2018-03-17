using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier_Script : MonoBehaviour {

	public GameObject barrier;

	public GameObject self;

	Collider2D c;

	void OnTriggerExit2D (Collider2D collider)
	{
		c = collider.gameObject.GetComponent<Collider2D> ();
		//transform.Translate (0.3f,0.0f,0.0f);

		if (c.gameObject.CompareTag ("Player")) 
		{
			Debug.Log ("Barrier Engage");
			barrier.gameObject.transform.Translate (3.5f, 0.0f, 0.0f);

			//Disable the trigger collider
			self.SetActive (false);
		}

		/*
		else
		if(c.gameObject.CompareTag("GameController"))
		{
			Debug.Log ("Bullet Detected");
		//c.theGun.isFiring = false;
		}
		*/


	}


}//end of script
