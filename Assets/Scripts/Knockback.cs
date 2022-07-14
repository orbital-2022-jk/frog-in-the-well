using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    public float knockback_strength;
    public bool has_exploded = false;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!has_exploded)
        {
            Rigidbody2D rb = collision.collider.GetComponent<Rigidbody2D>();

            Vector2 new_direction = collision.transform.position - transform.position;
            new_direction = new_direction.normalized;

            rb.AddForce(new_direction * knockback_strength, ForceMode2D.Impulse);
        }
    }
}
