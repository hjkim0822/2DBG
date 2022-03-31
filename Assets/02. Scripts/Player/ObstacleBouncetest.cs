using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBouncetest : MonoBehaviour
{
    public float bounceForce = 5;
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Player")) {
            print("Collision");
            Rigidbody2D rb = other.gameObject.GetComponent<Rigidbody2D>();
            Vector2 _playerMoveDirection = rb.velocity;
            rb.AddForce(-_playerMoveDirection * bounceForce, ForceMode2D.Force);
        }
    }
}
