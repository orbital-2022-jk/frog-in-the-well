using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D boxCol;
    Vector2 prevVelocity;

    [SerializeField] private LayerMask platform;

    public float dir;
    public float charge;
    public float chargeRate;



    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.contacts[0].normal.x != 0)
        {
            dir = collision.contacts[0].normal.x;

            var speed = prevVelocity.magnitude;
            var direction = Vector2.Reflect(prevVelocity.normalized, collision.contacts[0].normal);
            rb.velocity = 0.5f * direction * Mathf.Max(speed, 0f);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCol = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        prevVelocity = rb.velocity;

        if (Input.GetButton("Jump") && isGround())
        {
            charge += chargeRate;
        }

        if ((charge >= 30f || Input.GetButtonUp("Jump")) && isGround())
        {
            rb.velocity = new Vector2(dir * charge, charge);

            charge = 0.0f;
        }
    }

    private bool isGround()
    {
        return Physics2D.BoxCast(boxCol.bounds.center, boxCol.bounds.size, 0f, Vector2.down, 0.1f, platform);
    }
}
