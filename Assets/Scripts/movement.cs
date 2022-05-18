using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public LayerMask ground;
    private Rigidbody2D rb;
    public bool onGround = true;
    public float horizontalSpeed = 10f;
    public float verticalSpeed = 5f;
    public int dir = 1;
    public float verticalInc = 0.1f;

    void OnCollisionEnter2D(Collision2D col)
    {
        onGround = true;
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
            verticalSpeed += verticalInc;
        }

        if (verticalSpeed >= 30f && onGround)
        {
            onGround = false;
            float tempx = dir * horizontalSpeed;
            float tempy = verticalSpeed;
            rb.velocity = new Vector2(tempx, tempy);
            
            Invoke("ResetJump", 0.2f);
        }
    }
    
    void ResetJump()
    {
        verticalSpeed = 0.0f;
    }
}

