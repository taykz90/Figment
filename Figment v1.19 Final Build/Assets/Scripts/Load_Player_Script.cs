using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Load_Player_Script : MonoBehaviour {

    public PlayerHealthManager playerHealth;
    public control weaponControl;

    // get all weapon when load new scene
    void Start()
    {
        playerHealth = GetComponent<PlayerHealthManager>();
        weaponControl = GetComponent<control>();

        playerHealth.currentHealth = PlayerPrefs.GetInt("PlayerCurrentHealth");
        playerHealth.CheckHealthAmount();
        //PlayerPrefs.SetInt("PlayerCurrentWeapons", Convert.ToInt32(weaponsAvailable.getAllWeapon));
        int i = PlayerPrefs.GetInt("PlayerCurrentWeapons"); ;
        if (i == 0)
        {
            weaponControl.getAllWeapon = false;
        }
        else if (i == 1)
        {
            weaponControl.getAllWeapon = true;
        }
    }
}
