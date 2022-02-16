using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    #region Declaration
    public Rigidbody2D rb;
    public Camera cam;


    //Move
    public float regularSpeed = 5;
    Vector2 moveDir;

    //Rotate
    Vector2 mousePos;
    #endregion Declaration


    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        //position
        rb.MovePosition(rb.position + moveDir * regularSpeed * Time.fixedDeltaTime);

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

        //look input
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }
}
