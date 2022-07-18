using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMovementUpDown : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    public float movement_speed;
    public float up_y;
    public float down_y;
    public float dir;
    public Sprite up_sprite;
    public Sprite down_sprite;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.position.y >= up_y)
        {
            dir = -1;
            sr.sprite = down_sprite;
        }
        else if (rb.position.y <= down_y)
        {
            dir = 1;
            sr.sprite = up_sprite;
        }

        transform.position += dir * movement_speed * transform.up * Time.deltaTime;
    }
}
