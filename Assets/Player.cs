using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gamekit2D;

public class Player : MonoBehaviour
{
    // init some attributes
    [SerializeField]GameObject spawnpoint;

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

    public void Respawn()
    {
        // set player as inactive
        this.gameObject.SetActive(false);

        // teleport the player to most recent checkpoint
        this.gameObject.transform.position = spawnpoint.transform.position;

        // reset the player's health
        Damageable damageable = this.GetComponent<Damageable>();
        damageable.SetHealth(damageable.startingHealth);

        // reenable player
        this.gameObject.SetActive(true);
    }
}
