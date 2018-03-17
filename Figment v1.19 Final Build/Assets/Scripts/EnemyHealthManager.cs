using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour {

    public int maxHealth;
    public int currentHealth;

	private Animator fireAnimator;
	public AnimationClip fireDeathAnimation;

	//===================================================================
    public control c;

    private int deathCounter = 0;	//to ensure death animation only runs once

    // Use this for initialization
    void Start() {
        currentHealth = maxHealth;
		fireAnimator = GetComponent<Animator> ();
    }

    // Update is called once per frame
    void Update() {

		//Check if enemy is dead
		if (currentHealth <= 0 && deathCounter <= 1)
		{
			fireAnimator.Play(fireDeathAnimation.name); //play Fire_Death animation on death
            c.isFireballDead = true;
            Destroy(gameObject, 1.0f);  //dies after 1.0f seconds so that death animation can play
			deathCounter++;
		}
    }

    public void Water_HurtEnemy(int damageTaken)
    {
        currentHealth -= damageTaken;
		fireAnimator.SetTrigger ("isHurt");
        c.isFireballDamaged = true;
    }
		
}
