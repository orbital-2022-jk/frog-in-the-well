using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    private Rigidbody2D rb;
    private CircleCollider2D circ_col;
    Vector2 prev_velocity;
    private float width;
    private float height;
    private float ray_cast_length = 0.3f;
    private float collision_threshold = 0.3f;

    public PhysicsMaterial2D bouncy_material, normal_material;
    public float dir;
    public float charge;
    public float charge_rate;
    public float jump_height;
    public float bounce_boost;

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Debug.Log(collision.contacts[0].point);
        // Debug.Log(rb.transform.position);

        var col_x = collision.contacts[0].point.x;
        var col_y = collision.contacts[0].point.y;
        var curr_x = rb.transform.position.x;
        var curr_y = rb.transform.position.y;

        // contact down
        if (col_y + collision_threshold < curr_y)
        {
            rb.sharedMaterial = normal_material;
            rb.velocity = new Vector2(0, 0);
        }
        // contact up
        else if (col_y - collision_threshold > curr_y)
        {
            rb.velocity = new Vector2(prev_velocity.x, 0);
            // var speed = prev_velocity.magnitude;
            // var direction = Vector2.Reflect(prev_velocity.normalized, collision.contacts[0].normal);
            // rb.velocity = 0.8f * direction * Mathf.Max(speed, 0f);
        }
        else
        {
            rb.velocity = new Vector2(-prev_velocity.x, bounce_boost * prev_velocity.y);
            // // contact left
            // if (col_x + collision_threshold < curr_x)
            // {
            //     dir = 1;
            // }
            // // contact right
            // else if (col_x - collision_threshold > curr_x)
            // {
            //     dir = -1;
            // }

            // // var speed = prev_velocity.magnitude;
            // // var direction = Vector2.Reflect(prev_velocity.normalized, collision.contacts[0].normal);
            // // rb.velocity = 0.8f * direction * Mathf.Max(speed, 0f);
        }

        if (isLeftWall())
        {
            dir = 1;
        }
        else if (isRightWall())
        {
            dir = -1;
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "ceiling")
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        circ_col = GetComponent<CircleCollider2D>();
        width = GetComponent<CircleCollider2D>().bounds.extents.x + 0.1f;
        height = GetComponent<CircleCollider2D>().bounds.extents.y + 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        prev_velocity = rb.velocity;

        if (Input.GetButton("Jump") && isGround())
        {
            charge += charge_rate;
        }

        if ((charge >= 20f || Input.GetButtonUp("Jump")) && isGround())
        {
            rb.velocity = new Vector2(dir * charge, jump_height * charge);

            charge = 1.0f;

            rb.sharedMaterial = bouncy_material;
        }

        if (isLeftWall())
        {
            dir = 1;
        }
        else if (isRightWall())
        {
            dir = -1;
        }
    }

    private bool isGround()
    {
        // return Physics2D.BoxCast(circ_col.bounds.center, circ_col.bounds.size * 0.3f, 0f, Vector2.down, 0.5f, platform);
        // return Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - height), Vector2.down, ray_cast_length);
        bool left = Physics2D.Raycast(new Vector2(transform.position.x - (width - 0.2f), transform.position.y - height), Vector2.down, ray_cast_length);
        bool mid = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - height), Vector2.down, ray_cast_length);
        bool right = Physics2D.Raycast(new Vector2(transform.position.x + (width - 0.2f), transform.position.y - height), Vector2.down, ray_cast_length);

        if (left || mid || right)
        {
            return true;
        }
        return false;
    }

    private bool isLeftWall()
    {
        return Physics2D.Raycast(new Vector2(transform.position.x - (width - 0.05f), transform.position.y), Vector2.left, ray_cast_length);
    }

    private bool isRightWall()
    {
        return Physics2D.Raycast(new Vector2(transform.position.x + (width - 0.05f), transform.position.y), Vector2.right, ray_cast_length);
    }
}
