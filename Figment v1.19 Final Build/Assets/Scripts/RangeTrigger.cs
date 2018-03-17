using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeTrigger : MonoBehaviour {

	control c;

	public GameObject bu;

	void OnTriggerStay2D (Collider2D col)
	{
		c = col.gameObject.GetComponent<control> ();
		c.setRangeWeapon();
        c.itemPickedUp = true;
		//Debug.Log (c.weaponStatus);
		// Animate from no weapon to holding a weapon

		//diable use of gun while in the collider 
		//c.theGun.isFiring = false;

		//Disable the sprite gameObject
		bu.gameObject.SetActive(false);
	}




}//end of script
