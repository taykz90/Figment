using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthManager : MonoBehaviour {

    public control e;

	public int maxHealth;
	public int currentHealth;

	private Animator playerHealthAnimator;
	public AnimationClip playerDeathAnimation;

	private int deathCounter = 0;	//to ensure death animation only runs once

    // UI TESTING HERE
    private int maxHeartAmount = 5;
    public int startHearts = 3;
    private int healthPerHeart = 2;

    public Image[] healthContainers;
    public Sprite[] healthSprites;

    // Use this for initialization
    void Start() {
        currentHealth = startHearts * healthPerHeart;
        maxHealth = maxHeartAmount * healthPerHeart;
        CheckHealthAmount();
        //currentHealth = maxHealth;
		playerHealthAnimator = GetComponent<Animator> ();
	}

	// Update is called once per frame
	void Update() {

		if (currentHealth <= 0 && deathCounter <= 1)
		{
			//Animation for death scene
			playerHealthAnimator.SetBool("isDead", true);
            // restart lvl
            e.isPlayerDead = true;
            Destroy(gameObject);
            deathCounter++;
		}
	}

	public void HurtPlayer(int damageTaken)
	{
		//hurt animation
		currentHealth -= damageTaken;
		playerHealthAnimator.SetTrigger ("isHurt");
        e.isPlayerDamaged = true;

        currentHealth = Mathf.Clamp(currentHealth, 0, startHearts * healthPerHeart);
        UpdateHearts();
    }

    // UI TESTING HERE
    public void CheckHealthAmount()
    {
        for (int i = 0; i < maxHeartAmount; i++)
        {
            if (startHearts <= i)
            {
                healthContainers[i].enabled = false;
            }
            else
            {
                healthContainers[i].enabled = true;
            }
        }
        UpdateHearts();
    }

    void UpdateHearts()
    {
        bool empty = false;
        int i = 0;

        foreach (Image image in healthContainers)
        {
            if (empty)
            {
                image.sprite = healthSprites[0];
            }
            else
            {
                i++;
                if (currentHealth >= i * healthPerHeart)
                {
                    image.sprite = healthSprites[healthSprites.Length - 1];
                }
                else
                {
                    int currentHeartHealth = (int)(healthPerHeart - (healthPerHeart * i - currentHealth));
                    int healthPerImage = healthPerHeart / (healthSprites.Length - 1);
                    int imageIndex = currentHeartHealth / healthPerImage;
                    image.sprite = healthSprites[imageIndex];
                    empty = true;
                }
            }
        }
    }

    public void AddHeartContainer()
    {
        startHearts++;
        startHearts = Mathf.Clamp(currentHealth, 0, maxHeartAmount);

        // HP regens to full when container increases
        //currentHealth = startHearts * healthPerHeart;
        //maxHealth = maxHeartAmount * healthPerHeart;

        CheckHealthAmount();
    }
   
}//end of script
