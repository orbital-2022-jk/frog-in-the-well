using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    private Rigidbody2D rb;
    private CircleCollider2D circCol;
    Vector2 prevVelocity;
    private float width;
    private float height;

    public float dir;
    public float charge;
    public float chargeRate;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (isLeftWall()) 
        { 
            dir = 1; 
        } 
        else if (isRightWall()) 
        { 
            dir = -1; 
        }

        if (collision.contacts[0].normal.x != 0)
        {
            // dir = collision.contacts[0].normal.x;

            var speed = prevVelocity.magnitude;
            var direction = Vector2.Reflect(prevVelocity.normalized, collision.contacts[0].normal);
            rb.velocity = 0.5f * direction * Mathf.Max(speed, 0f);
        }

        if (isGround())
        {
            rb.velocity = new Vector2(0, 0);
        }

        if (collision.gameObject.tag == "ceiling")
        {
            Debug.Log("game over");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        circCol = GetComponent<CircleCollider2D>();
        width = GetComponent<CircleCollider2D>().bounds.extents.x + 0.1f;
        height = GetComponent<CircleCollider2D>().bounds.extents.y + 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        prevVelocity = rb.velocity;

        if (Input.GetButton("Jump") && isGround())
        {
            charge += chargeRate;
        }

        if ((charge >= 20f || Input.GetButtonUp("Jump")) && isGround())
        {

            rb.velocity = new Vector2(dir * charge, 1.1f * charge);

            charge = 0.0f;
        }
        Debug.Log(transform.right);
    }

    private bool isGround()
    {

        // return Physics2D.BoxCast(circCol.bounds.center, circCol.bounds.size * 0.3f, 0f, Vector2.down, 0.5f, platform);
        return Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - height), -Vector2.up, 0.005f);
    }

    private bool isLeftWall() 
    { 
        return Physics2D.Raycast(new Vector2(transform.position.x - width / 2, transform.position.y), Vector2.left, 0.005f); 
    } 
 
    private bool isRightWall() 
    { 
        return Physics2D.Raycast(new Vector2(transform.position.x + width / 2, transform.position.y), Vector2.right, 0.005f); 
    }
}
