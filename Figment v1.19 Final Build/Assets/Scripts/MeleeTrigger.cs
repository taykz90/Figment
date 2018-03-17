using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeTrigger : MonoBehaviour {

	control weaponControl;

	//Collider2D bullet_c;
	//public WeaponController gun;
	public GameObject bu;

	//public GameObject bullet_c;
	Collider2D c;

	void OnTriggerStay2D (Collider2D col)
	{
		//c = col.gameObject.GetComponent<control> ();
		//bullet_c = col.gameObject.GetComponent<Collider2D> ();
		/*
			c.getAllWeapon = true;


			bu.gameObject.SetActive(false);
		+/
	*/
		c = col.gameObject.GetComponent<Collider2D> ();
		weaponControl = col.gameObject.GetComponent<control> ();

		if (c.gameObject.CompareTag ("Player")) 
		{
			//c.gameObject.SetActive (false);
			weaponControl.getAllWeapon=true;
            weaponControl.itemPickedUp = true;
			bu.gameObject.SetActive(false);
		}

	}



}//end of script
