using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleDamage : MonoBehaviour
{
    public float damage = 0.5f;
    PlayerStats playerStats;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerStats playerStats = other.gameObject.GetComponent<PlayerStats>();
            playerStats.PLAYERHP -= damage;
            print(playerStats.PLAYERHP);
        }
    }


}
