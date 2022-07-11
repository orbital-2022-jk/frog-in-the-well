using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float movement_speed;
    public float stall_duration;
    public float curr_duration = 0;
    public float top_y;
    public float bot_y;
    public float dir;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.position.y >= top_y)
        {
            dir = -1;

            curr_duration += Time.deltaTime;

            if (curr_duration >= Random.Range(1.0f, stall_duration))
            {
                transform.position += dir * movement_speed * transform.up * Time.deltaTime;
            }
        }
        else if (rb.position.y <= bot_y)
        {
            dir = 1;

            curr_duration += Time.deltaTime;

            if (curr_duration >= Random.Range(1.0f, stall_duration))
            {
                transform.position += dir * movement_speed * transform.up * Time.deltaTime;
            }
        }
        else
        {
            curr_duration = 0;

            transform.position += dir * movement_speed * transform.up * Time.deltaTime;
        }
    }
}
