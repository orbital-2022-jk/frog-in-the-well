using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D boxCol;

    public PhysicsMaterial2D bounceMat, normalMat;

    [SerializeField] private LayerMask platform;

    public float dir;
    public float charge;
    public float chargeRate;

    // void OnCollisionEnter2D(Collision2D col)
    // {
    //     if (isWall())
    //     {
            
    //     }
        //     Collider2D thisObject = col.collider;

        //     Vector3 contactPoint = col.contacts[0].point; // Point at which other collider intersects with this collider
        //     Vector3 center = thisObject.bounds.center; // Center point of this collider to use as reference for where player is in relation to this point

        //     if ((contactPoint.y > center.y) && (col.gameObject.tag == "platform")) // for walls and platform sides
        //     {
        //         onGround = true;
        //     }
        //     else // for grounds
        //     {
        //         dir *= -1;
        //         rb.velocity = new Vector2(dir * speed, speed);
        //     }
    // }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCol = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Jump") && isGround())
        {
            charge += chargeRate;
        }

        if ((charge >= 30f || Input.GetButtonUp("Jump")) && isGround())
        {
            rb.velocity = new Vector2(dir * charge, charge);

            charge = 0.0f;
        }

        if (!isGround() && isWall())
        {
            dir *= -1;
            rb.sharedMaterial = bounceMat;
        }
        else
        {
            rb.sharedMaterial = normalMat;
        }
    }

    private bool isGround()
    {
        return Physics2D.BoxCast(boxCol.bounds.center, boxCol.bounds.size, 0f, Vector2.down, 0.1f, platform);
    }

    private bool isWall()
    {
        return Physics2D.BoxCast(boxCol.bounds.center, boxCol.bounds.size, 0f, Vector2.left, 0.01f, platform) || Physics2D.BoxCast(boxCol.bounds.center, boxCol.bounds.size, 0f, Vector2.right, 0.01f, platform);

        // // 1
        // bool wallOnleft = Physics2D.Raycast(new Vector2(
        // transform.position.x - width, transform.position.y),
        // -Vector2.right, rayCastLengthCheck);
        // bool wallOnRight = Physics2D.Raycast(new Vector2(
        // transform.position.x + width, transform.position.y),
        // Vector2.right, rayCastLengthCheck);
        // // 2
        // if (wallOnleft || wallOnRight)
        // {
        //     return true;
        // }
        // else
        // {
        //     return false;
        // }
    }
}
