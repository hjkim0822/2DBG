using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    #region Declaration
    //Components
    public Rigidbody2D rb;
    public Camera cam;
    PlayerStats playerStats;

    //Move
    public float startSpeed = 5;
    Vector2 moveDir;

    //Rotate
    Vector2 mousePos;

    //Collision
    bool isBumped;
    public float inputDisableTime = 1.5f;
    #endregion Declaration



    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        playerStats = gameObject.GetComponent<PlayerStats>();
    }

    private void FixedUpdate()
    {
        if (isBumped == false)
        {
            StopCoroutine(IEDisableUserInput());
            //position
            //rb.MovePosition(rb.position + moveDir * playerStats.PLAYERSPEED * Time.fixedDeltaTime);
            rb.velocity = moveDir * playerStats.PLAYERSPEED;
        }
        else {
            Debug.LogWarning("Disable UserInput");
            StartCoroutine(IEDisableUserInput());
        }

        //rotation
        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }

    // Update is called once per frame
    void Update()
    {
        //move input
        moveDir.x = Input.GetAxisRaw("Horizontal");
        moveDir.y = Input.GetAxisRaw("Vertical");

        #region Camera
        //look input
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        #endregion Camera

        lastVelocity = rb.velocity;

    }

    Vector2 lastVelocity;


    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Obstacle")) {

            isBumped = true;

            print(rb.velocity);
            float _speed = rb.velocity.magnitude;
            Vector2 _objectNormal = other.contacts[0].normal.normalized;
            moveDir = Vector2.Reflect(rb.velocity, _objectNormal);

            rb.velocity = moveDir * _speed;

            print(rb.velocity);

            /*            float _speed = lastVelocity.magnitude;
                        var direction = Vector2.Reflect(lastVelocity.normalized, other.contacts[0].normal);
                        rb.velocity = direction * Mathf.Max(_speed, 3f);
            */

        }
    }



    IEnumerator IEDisableUserInput() {
        Debug.LogWarning("Staret IEDisableUserInput Coroutine");
        yield return new WaitForSeconds(inputDisableTime);
        isBumped = false;
    }
}
