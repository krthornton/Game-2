using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Gamekit2D;

public class Player : MonoBehaviour
{
    // init some attributes modifiable in editor
    public bool debug_log;
    public int starting_lives;
    public int current_lives;
    public GameObject spawnpoint;
    public int gravity_flip_delay;

    // init some private attributes
    System.DateTime last_gravity_flip;

    // function called on start of game
    public void Start()
    {
        // init the player's current_lives to starting_lives
        current_lives = starting_lives;

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

                // update the last_gravity_flip time
                last_gravity_flip = now;

                // flip gravity
                GetComponent<Rigidbody2D>().gravityScale *= -1;
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
                Debug.Log("checkpoint reached: " + spawnpoint.name);
            }
        }
    }

    // function called when Damageable.OnDie
    public void Die()
    {
        // call respawn
        Respawn();
    }

    // respawns the player and updates appropriate info
    public void Respawn()
    {
        // set player as inactive
        this.gameObject.SetActive(false);

        // teleport the player to most recent checkpoint
        this.gameObject.transform.position = spawnpoint.transform.position;

        // reset the player's damageable health
        Damageable damageable = this.GetComponent<Damageable>();
        damageable.SetHealth(damageable.startingHealth);

        // subtract a life from the player
        current_lives--;

        // update the player's lives count
        UpdateLivesUI();

        // reenable player
        this.gameObject.SetActive(true);
    }

    // updates the UI on screen with current_lives value
    public void UpdateLivesUI()
    {
        Text ui_lives = GameObject.Find("Main Camera/UI/Lives").GetComponent<Text>();
        ui_lives.text = "Lives " + current_lives.ToString() + "/" + starting_lives.ToString();
    }
}
