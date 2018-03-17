using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class control : MonoBehaviour {

	// ufo project code
	/*
	public float speed;             //Floating point variable to store the player's movement speed.

	private Rigidbody2D rb2d;       //Store a reference to the Rigidbody2D component required to use 2D Physics.

	// Use this for initialization
	void Start()
	{
		//Get and store a reference to the Rigidbody2D component so that we can access it.
		rb2d = GetComponent<Rigidbody2D> ();
	}

	//FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
	void FixedUpdate()
	{
		//Store the current horizontal input in the float moveHorizontal.
		float moveHorizontal = Input.GetAxis ("Horizontal");

		//Store the current vertical input in the float moveVertical.
		float moveVertical = Input.GetAxis ("Vertical");

		//Use the two store floats to create a new Vector2 variable movement.
		Vector2 movement = new Vector2 (moveHorizontal, moveVertical);

		//Call the AddForce function of our Rigidbody2D rb2d supplying movement multiplied by speed to move our player.
		rb2d.AddForce (movement * speed);
	}
	*/

	//actual
	public bool moving = false;

	//set speed in editor
	public float speed;

	//for the weapon
	public WeaponController theGun;
	public WeaponController thePan;

	//Animation Controller
	private Animator playerAnimator;

	/// <summary>
	///  weapon status
	// 0 - no weapon
	// 1 - gun
	// 2 - melee
	public int weaponStatus = 0;

	public bool getAllWeapon = false;

	public int diaryCount = 0;

	public void SetDiary(int d)
	{
		diaryCount += d;
        if (diaryCount == 4)
        {
            all_notes_sound.Play();
        }
        pickup_sound.Play();
        door_open_sound.Play();
    }

    //sounds
    public AudioSource[] sounds;
    public AudioSource footstep_sound;
    public bool itemPickedUp = false;
    public AudioSource pickup_sound;
    public AudioSource watergun_sound;
    public bool isFireballDead = false;
    public AudioSource fireball_death_sound;
	public bool isClownDead = false;
    public AudioSource clown_death_sound;
    public AudioSource frying_pan_sound;
    public bool isFireballDamaged = false;
    public AudioSource fireball_damage_sound;
    public bool isClownDamaged = false;
    public AudioSource clown_damage_sound;
    public bool isPlayerDamaged = false;
    public AudioSource player_damaged_sound;
    public bool isDoorOpened = false;
    public AudioSource door_open_sound;
    public bool isPlayerDead = false;
    public bool winCondition = false;
    public AudioSource all_notes_sound;

    void Start()
	{
		playerAnimator = GetComponent<Animator> ();
        sounds = GetComponents<AudioSource>();
        footstep_sound = sounds[0];
        pickup_sound = sounds[1];
        watergun_sound = sounds[2];
        fireball_death_sound = sounds[3];
        clown_death_sound = sounds[4];
        frying_pan_sound = sounds[5];
        fireball_damage_sound = sounds[6];
        clown_damage_sound = sounds[7];
        player_damaged_sound = sounds[8];
        door_open_sound = sounds[9];
        all_notes_sound = sounds[10];
    }

	void Update()
	{
		movement();
		switch_Weapon ();
		check_Weapon ();
        check_if_damaged();
        check_win_condition();
    }

	void movement()
	{
		if (Input.GetKey(KeyCode.W)) 
		{
			transform.Translate(Vector3.up * speed * Time.deltaTime, Space.World);
			moving = true;
			playerAnimator.SetBool ("isWalking", true);
		}

		if (Input.GetKey(KeyCode.S)) 
		{
			transform.Translate(Vector3.down * speed * Time.deltaTime, Space.World);
			moving = true;
			playerAnimator.SetBool ("isWalking", true);
		}

		if (Input.GetKey(KeyCode.A)) 
		{
			transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);
			moving = true;
			playerAnimator.SetBool ("isWalking", true);

		}

		if (Input.GetKey(KeyCode.D)) 
		{
			transform.Translate(Vector3.right * speed * Time.deltaTime, Space.World);
			moving = true;
			playerAnimator.SetBool ("isWalking", true);

		}

		if (Input.GetKey(KeyCode.W) != true && Input.GetKey(KeyCode.S) != true &&
		    Input.GetKey(KeyCode.A) != true && Input.GetKey(KeyCode.D) != true) 
		{
			moving = false;
			playerAnimator.SetBool ("isWalking", false);
		
		}

        if (moving == true)
        {
            // footstep sound
            footstep_sound.Play();
        }

        if (itemPickedUp == true)
        {
            // item pickup sound
            pickup_sound.Play();
            itemPickedUp = false;
        }

        if (isPlayerDead == true)
        {
            isPlayerDead = false;
            Destroy(GameObject.Find("Bedroom_Music"));
            Destroy(GameObject.Find("Corridor_Music"));
            Destroy(GameObject.Find("Kitchen_Music"));
            Destroy(GameObject.Find("LivingRoom_Music"));
            Destroy(GameObject.Find("Backyard_Music"));
            Destroy(GameObject.Find("BossRoom_Music"));
        }
    }

	//===============================================================================
	public void setNoWeapon()
	{
		weaponStatus = 0;
	}
		
	public void setRangeWeapon()
	{
		weaponStatus = 1;
		playerAnimator.SetBool ("holdWatergun", true);

        // item pickup sound
        pickup_sound.Play();
    }

	public void setMeleeWeapon()
	{
		weaponStatus = 2;
        // item pickup sound
        pickup_sound.Play();
    }


	//===============================================================================

	void check_Weapon()
	{
		switch(weaponStatus)
		{
			case 1:
				rangeWeaponDamage();
				break;
			case 2:
				meleeWeaponDamage ();
				break;

			default:
				Debug.Log ("no weapon selected");
				break;
		}


	}

	//================================================================================
	// Weapon damage for range and melee
	//================================================================================
	//shoot every x second(reset)
	// timer to countdown

	public float timer;
	public float reset;

	void rangeWeaponDamage()
	{
		
		//reset = timer;
		timer -= Time.deltaTime;


		if (Input.GetMouseButtonDown (0)) {
			if (timer < 0) {
				theGun.isFiring = true;
                //water gun sound
                watergun_sound.Play();
                playerAnimator.SetTrigger ("isShooting");	//display shooting animation
                //Debug.Log ("Firing");
                timer =reset;
			}
		} 
			
		if (Input.GetMouseButtonUp (0)) {
			theGun.isFiring = false;
			//Debug.Log ("Stop Firing");

		}

        if (isFireballDamaged == true)
        {
            //fireball damaged sound
            fireball_damage_sound.Play();
            isFireballDamaged = false;
        }

        if (isFireballDead == true)
        {
            //fireball death sound
            fireball_death_sound.Play();
            isFireballDead = false;
        }

        //end "shooting" animation
    }

	//======================================================================
	void meleeWeaponDamage()
	{

		//reset = timer;
		timer -= Time.deltaTime;


		if (Input.GetMouseButtonDown (0)) 
		{
			if (timer < 0) {
				thePan.isStabbing = true;
                //frying pan sound
                frying_pan_sound.Play();
                playerAnimator.SetTrigger ("isSwinging"); //display swinging animation
				//Debug.Log ("Stab");
				timer=reset;
			}
		}

        if (isClownDamaged == true)
        {
            //clown damaged sound
            clown_damage_sound.Play();
            isClownDamaged = false;
        }

        if (isClownDead == true)
        {
            //clown death sound
            clown_death_sound.Play();
            isClownDead = false;
        }

        //if (Input.GetMouseButton (0)) {
        //	theGun.isFiring = false;
        //}

        if (Input.GetMouseButtonUp (0)) {
			thePan.isStabbing = false;
			//Debug.Log ("Idle");

		}

	}

	//======================================================================
	void switch_Weapon()
	{
		if (Input.GetKeyUp (KeyCode. Space)) 
		{
			//Debug.Log ("Change Weapon");
			if (weaponStatus == 1 && getAllWeapon == true) {
				setMeleeWeapon ();
				//Swap watergun sprite with fryingpan sprite
				playerAnimator.SetBool ("holdWatergun", false);
				playerAnimator.SetBool ("holdFryingPan", true);
			} else if (weaponStatus == 2 && getAllWeapon == true) {
				setRangeWeapon ();
				//Swap fryingpan sprite with watergun sprite 
				playerAnimator.SetBool ("holdFryingPan", false);
				playerAnimator.SetBool ("holdWatergun", true);
			} else if (weaponStatus == 1 && getAllWeapon == false) {
				setRangeWeapon ();
			}
			else
				setNoWeapon ();
		}

	}

    void check_if_damaged()
    {
        if (isPlayerDamaged == true)
        {
            //player damaged sound
            player_damaged_sound.Play();
            isPlayerDamaged = false;
        }
    }

    void check_win_condition()
    {
        if (winCondition == true)
        {
            //play final dialogue sound
            Destroy(GameObject.Find("BossRoom_Music"));
        }
    }

}//end of script

