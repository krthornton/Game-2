using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Gamekit2D;

public class Player : MonoBehaviour
{
    // init some attributes modifiable in editor
    public bool debug_log;
    public int parLevel;
    public int deaths;
    public GameObject spawnpoint;
    public int gravity_flip_delay;

    // init some private attributes
    System.DateTime last_gravity_flip;
   
   
   
    // function called on start of game
    public void Start()
    {
        // init the last_gravity_flip var
        last_gravity_flip = System.DateTime.Now;

        // set the player's lives count
        UpdateLivesUI();
    }

    // function called every update
    public void Update()
    {
        // check if the player has pressed the gravity key ("E")
        if (Input.GetKeyDown(KeyCode.E))
        {
            // if so, check that the player isn't spamming the gravity key
            System.DateTime now = System.DateTime.Now;
            System.TimeSpan diff = now - last_gravity_flip;
            if (diff.TotalMilliseconds > gravity_flip_delay) {
                // debug
                if (debug_log) Debug.Log("[DEBUG] Gravity flip delay: " + diff.ToString());

                // flip player's sprite
                FlipGravity();
            }
        }
    }

    // function called whenever the player enters a trigger field (like checkpoints)
    public void OnTriggerEnter2D(Collider2D other)
    {
        // check if this is a checkpoint
        if (other.gameObject.CompareTag("Respawn"))
        {
            // check if this checkpoint is already set
            if (spawnpoint != other.gameObject)
            {
                // if not, set new spawnpoint
                spawnpoint = other.gameObject;

                // play the checkpoint sound effect
                other.gameObject.GetComponent<AudioSource>().Play();

                // output to console if DEBUG
                if (debug_log) Debug.Log("[DEBUG] Checkpoint Reached: " + spawnpoint.name);
            }
        }
    }

    public void FlipGravity()
    {
        // update the last_gravity_flip time
        last_gravity_flip = System.DateTime.Now;

        // flip gravity
        GetComponent<Rigidbody2D>().gravityScale *= -1;

        // get the current state of the sprite and flip the sprite
        Vector3 new_vector = transform.localScale;
        new_vector.y = -new_vector.y;
        transform.localScale = new_vector;
    }

    public void SetGravity(bool negative)
    {
        // update the last_gravity_flip time
        last_gravity_flip = System.DateTime.Now;

        // set gravity and sprite direction
        float current_gravity = GetComponent<Rigidbody2D>().gravityScale;
        Vector3 new_vector = transform.localScale;
        if (negative)
        {
            // set gravity negative
            GetComponent<Rigidbody2D>().gravityScale = -Mathf.Abs(current_gravity);
            
            // set sprite to upside down
            new_vector.y = -Mathf.Abs(new_vector.y);
        }
        else
        {
            // set gravity positive
            GetComponent<Rigidbody2D>().gravityScale = Mathf.Abs(current_gravity);

            // set sprite to standing up
            new_vector.y = Mathf.Abs(new_vector.y);
        }

        // update the sprite
        transform.localScale = new_vector;
    }

    // function called when Damageable.OnDie
    public void Die()
    {
        // play the death sound
        this.gameObject.GetComponent<AudioSource>().playOnAwake = true;
        this.gameObject.GetComponent<AudioSource>().Play();

        // call respawn
        Respawn();
    }

    // respawns the player and updates appropriate info
    public void Respawn()
    {
        // set player as inactive
        gameObject.SetActive(false);

        // teleport the player to most recent checkpoint and set gravity
        gameObject.transform.position = spawnpoint.transform.position;
        SetGravity(spawnpoint.GetComponent<checkpoint>().negativeGravity);

        // reset the player's damageable health
        Damageable damageable = this.GetComponent<Damageable>();
        damageable.SetHealth(damageable.startingHealth);

        // increment the player's death count
        deaths++;

        // update the player's death counter on screen
        UpdateLivesUI();

        // reenable player
        gameObject.SetActive(true);
    }

    // updates the UI on screen with deaths value
    public void UpdateLivesUI()
    {
        Text ui_lives = GameObject.Find("Main Camera/UI/Lives").GetComponent<Text>();
        ui_lives.text = "Deaths: " + deaths.ToString() + "\n" +
                        "Par: " + parLevel.ToString();
    }
}
