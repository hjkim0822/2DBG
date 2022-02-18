using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSlow : MonoBehaviour
{
    public float regularSpeed = 5;
    public float swampSpeed = 2.5f;
    PlayerStats playerStats;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            PlayerStats playerStats = other.gameObject.GetComponent<PlayerStats>();
            playerStats.PLAYERSPEED = swampSpeed;
            print(playerStats.PLAYERSPEED);
            
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            PlayerStats playerStats = other.gameObject.GetComponent<PlayerStats>();
            playerStats.PLAYERSPEED = regularSpeed;
            print(playerStats.PLAYERSPEED);
        }
    }

}
