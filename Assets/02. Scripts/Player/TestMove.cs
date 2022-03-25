using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMove : MonoBehaviour
{
    private Vector2 velocity;
    public Rigidbody2D rb;
    public PlayerStats playerStats;
    Vector2 moveDir;
    public float startSpeed = 5;



    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        playerStats = gameObject.GetComponent<PlayerStats>();

    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveDir * playerStats.PLAYERSPEED * Time.fixedDeltaTime);
        //rb.velocity = moveDir * playerStats.PLAYERSPEED;
    }

    private void Update()
    {
        moveDir.x = Input.GetAxisRaw("Horizontal");
        moveDir.y = Input.GetAxisRaw("Vertical");

        velocity = rb.velocity;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        var reflection = Vector2.Reflect(velocity, other.contacts[0].normal);
        rb.velocity = reflection;
    }
}
