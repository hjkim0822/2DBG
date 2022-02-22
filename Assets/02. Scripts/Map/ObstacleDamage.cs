using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleDamage : MonoBehaviour
{
    Vector3 changeSizeVector;
    public float damage = 0.5f;
    public float changeSize = 2f;
    PlayerStats playerStats;
    private void Start()
    {
        changeSizeVector = new Vector3(changeSize, changeSize, 0);
        
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerStats playerStats = other.gameObject.GetComponent<PlayerStats>();
            playerStats.PLAYERHP -= damage;
            playerStats.PLAYERSIZE += changeSizeVector;
            print(playerStats.PLAYERHP);
            print(playerStats.PLAYERSIZE);
        }
    }


}
