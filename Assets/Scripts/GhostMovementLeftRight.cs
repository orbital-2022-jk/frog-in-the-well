using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMovementLeftRight : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    public float movement_speed;
    public float left_x;
    public float right_x;
    public float dir;
    public Sprite left_sprite;
    public Sprite right_sprite;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.position.x >= right_x)
        {
            // update direction
            dir = -1;

            // update sprite
            sr.sprite = left_sprite;
        }
        else if (rb.position.x <= left_x)
        {
            // update direction
            dir = 1;

            // update sprite
            sr.sprite = right_sprite;
        }

        // move ghost
        transform.position += dir * movement_speed * transform.right * Time.deltaTime;
    }
}
