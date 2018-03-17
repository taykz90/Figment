using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss_Level_Trigger : MonoBehaviour {

    Collider2D p;
    public PlayerHealthManager playerHealth;
    public control weaponsAvailable;
    public string nextGameLevel;

	control diary;

    void OnTriggerEnter2D (Collider2D col)
	{
		p = col.gameObject.GetComponent<Collider2D>();
		diary = col.gameObject.GetComponent<control> ();


        if (p.gameObject.CompareTag("Player"))
        {
			//If all diary is collected...load level
			if (diary.diaryCount == 4) 
			{
				PlayerPrefs.SetInt ("PlayerCurrentHealth", playerHealth.currentHealth);
				//PlayerPrefs.SetInt("PlayerCurrentWeapons", Convert.ToInt32(weaponsAvailable.getAllWeapon));
				int i = weaponsAvailable.getAllWeapon ? 1 : 0;
				PlayerPrefs.SetInt ("PlayerCurrentWeapons", i);
				SceneManager.LoadScene (nextGameLevel);
			}
        }
    }
}
