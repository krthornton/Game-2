using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Gamekit2D;

public class Player : MonoBehaviour
{
    // init some attributes modifiable in editor
    [SerializeField] int starting_lives;
    [SerializeField] int current_lives;
    [SerializeField] GameObject spawnpoint;

    // function called on start of game
    public void Start()
    {
        // init the player's current_lives to starting_lives
        current_lives = starting_lives;

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


            // if so, flip the gravity
            GetComponent<Rigidbody2D>().gravityScale *= -1;
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
