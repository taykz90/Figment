using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clown_EnemyHealthManager : MonoBehaviour {

    public control d;

	public int maxHealth;
	public int currentHealth;

	private Animator clownAnimator;
	public AnimationClip clownDeathAnimation;


	//===================================================================

	private int deathCounter = 0;	//to ensure death animation only runs once

	// Use this for initialization
	void Start() {
		currentHealth = maxHealth;
		clownAnimator = GetComponent<Animator> ();
	}

	// Update is called once per frame
	void Update() {

		//Check if enemy is dead
		if (currentHealth <= 0 && deathCounter <= 1)
		{
			clownAnimator.Play(clownDeathAnimation.name); //play Fire_Death animation on death
            d.isClownDead = true;
			Destroy(gameObject, 1.0f);  //dies after 1.0f seconds so that death animation can play
			deathCounter++;
		}
	}
		
	public void Melee_HurtEnemy(int damageTaken)
	{
		currentHealth -= damageTaken;
		clownAnimator.SetTrigger ("isHurt");
        d.isClownDamaged = true;
    }
}
