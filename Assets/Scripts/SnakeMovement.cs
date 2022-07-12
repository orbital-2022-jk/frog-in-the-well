using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMovement : MonoBehaviour
{
    public int length;
    public GameObject[] snake_body;
    public bool[] active;
    public float movement_speed;
    public float curr = 0;
    private int head_ptr;
    private int tail_ptr;

    // Start is called before the first frame update
    void Start()
    {
        active = new bool[snake_body.Length];
        head_ptr = length - 1;
        tail_ptr = 0;

        for (int i = tail_ptr; i < head_ptr; i++)
        {
            active[i] = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        curr += Time.deltaTime;

        if (curr >= movement_speed)
        {
            head_ptr += 1;
            tail_ptr += 1;

            if (head_ptr == snake_body.Length)
            {
                head_ptr = 0;
            }

            if (tail_ptr == snake_body.Length)
            {
                tail_ptr = 0;
            }

            curr = 0;

            update_active();
        }

        update_snake();
    }

    void update_active()
    {
        if (head_ptr > tail_ptr)
        {
            for (int i = tail_ptr; i < head_ptr; i++)
            {
                active[i] = true;
            }

            for (int i = head_ptr; i < snake_body.Length; i++)
            {
                active[i] = false;
            }

            for (int i = 0; i < tail_ptr; i++)
            {
                active[i] = false;
            }
        }
        // head_ptr < tail_ptr
        else
        {
            for (int i = 0; i < head_ptr; i++)
            {
                active[i] = true;
            }

            for (int i = head_ptr; i < tail_ptr; i++)
            {
                active[i] = false;
            }

            for (int i = tail_ptr; i < snake_body.Length; i++)
            {
                active[i] = true;
            }
        }
    }

    void update_snake()
    {
        for (int i = 0; i < snake_body.Length; i++)
        {
            if (active[i])
            {
                snake_body[i].SetActive(true);
            }
            else
            {
                snake_body[i].SetActive(false);
            }
        }
    }
}
