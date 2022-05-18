using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    private Rigidbody2D rb;

    public bool onGround = true;
    public float speed = 0.0f;
    public int dir = 1;
    public float verticalInc = 5.0f;

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "platform")
        {
            onGround = true;
        }
        
        if (col.gameObject.tag == "wall")
        {
            dir *= -1;
            rb.velocity = new Vector2(dir * speed, speed);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {  
        if (Input.GetButton("Jump") && onGround)
        {
            speed += verticalInc;
        }

        if ((speed >= 30f || Input.GetButtonUp("Jump")) && onGround)
        {
            onGround = false;
            rb.velocity = new Vector2(dir * speed, speed);
            
            Invoke("ResetJump", 0.2f);
        }

        if (rb.velocity.magnitude == 0.0f)
        {
            onGround = true;
        }
    }
    
    void ResetJump()
    {
        speed = 0.0f;
    }
}
