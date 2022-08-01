using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMovement : MonoBehaviour
{
    public int length;
    public GameObject[] snake_body;
    public bool[] active;
    public float movement_speed;
    private float curr_movement = 0;
    public int head_ptr;
    public int tail_ptr;

    public Sprite[] head_sprite;
    public Sprite[] body_straight_sprite;
    public Sprite[] body_curve_sprite;
    public Sprite[] tail_sprite;

    // Start is called before the first frame update
    void Start()
    {
        // initialise state of snake
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
        curr_movement += Time.deltaTime;

        // update snake position
        if (curr_movement >= movement_speed)
        {
            head_ptr += 1;
            tail_ptr += 1;

            // handle circular array
            if (head_ptr == snake_body.Length)
            {
                head_ptr = 0;
            }

            // handle circular array
            if (tail_ptr == snake_body.Length)
            {
                tail_ptr = 0;
            }

            curr_movement = 0;

            update_active();
        }

        update_snake();

        update_body_sprite();

        update_curve_sprite();

        update_head_sprite();

        update_tail_sprite();
    }

    // update active state of snake parts
    void update_active()
    {
        if (head_ptr > tail_ptr)
        {
            for (int i = tail_ptr; i <= head_ptr; i++)
            {
                active[i] = true;
            }

            for (int i = head_ptr + 1; i < snake_body.Length; i++)
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
            for (int i = 0; i <= head_ptr; i++)
            {
                active[i] = true;
            }

            for (int i = head_ptr + 1; i < tail_ptr; i++)
            {
                active[i] = false;
            }

            for (int i = tail_ptr; i < snake_body.Length; i++)
            {
                active[i] = true;
            }
        }
    }

    // set snake parts to be active
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

    // update snake straight body sprites
    void update_body_sprite()
    {
        for (int i = 0; i < snake_body.Length; i++)
        {
            if (active[i] && i != head_ptr && i != tail_ptr)
            {
                if (i == 26 || (i >= 35 && i <= 37) || i == 65 || (i >= 73 && i <= 75))
                {
                    snake_body[i].GetComponent<SpriteRenderer>().sprite = body_straight_sprite[0];
                }
                else
                {
                    snake_body[i].GetComponent<SpriteRenderer>().sprite = body_straight_sprite[1];
                }
            }
        }
    }

    // update snake curved body sprites
    void update_curve_sprite()
    {
        for (int i = 0; i < snake_body.Length; i++)
        {
            if (active[i] && i != head_ptr && i != tail_ptr)
            {
                if (i == 0 || i == 20 || i == 43)
                {
                    snake_body[i].GetComponent<SpriteRenderer>().sprite = body_curve_sprite[3];
                }
                else if (i == 12 || i == 25 || i == 34 || i == 59 || i == 66)
                {
                    snake_body[i].GetComponent<SpriteRenderer>().sprite = body_curve_sprite[2];
                }
                else if (i == 13 || i == 27 || i == 58 || i == 64 || i == 72)
                {
                    snake_body[i].GetComponent<SpriteRenderer>().sprite = body_curve_sprite[1];
                }
                else if (i == 19 || i == 38 || i == 44)
                {
                    snake_body[i].GetComponent<SpriteRenderer>().sprite = body_curve_sprite[0];
                }
            }
        }
    }

    // update snake head sprite
    void update_head_sprite()
    {
        if (head_ptr == 0)
        {
            snake_body[head_ptr].GetComponent<SpriteRenderer>().sprite = head_sprite[0];
        }
        else if (head_ptr >= 1 && head_ptr <= 12)
        {
            snake_body[head_ptr].GetComponent<SpriteRenderer>().sprite = head_sprite[3];
        }
        else if (head_ptr == 13)
        {
            snake_body[head_ptr].GetComponent<SpriteRenderer>().sprite = head_sprite[1];
        }
        else if (head_ptr >= 14 && head_ptr <= 19)
        {
            snake_body[head_ptr].GetComponent<SpriteRenderer>().sprite = head_sprite[3];
        }
        else if (head_ptr == 20)
        {
            snake_body[head_ptr].GetComponent<SpriteRenderer>().sprite = head_sprite[0];
        }
        else if (head_ptr >= 21 && head_ptr <= 25)
        {
            snake_body[head_ptr].GetComponent<SpriteRenderer>().sprite = head_sprite[3];
        }
        else if (head_ptr >= 26 && head_ptr <= 27)
        {
            snake_body[head_ptr].GetComponent<SpriteRenderer>().sprite = head_sprite[1];
        }
        else if (head_ptr >= 28 && head_ptr <= 34)
        {
            snake_body[head_ptr].GetComponent<SpriteRenderer>().sprite = head_sprite[3];
        }
        else if (head_ptr >= 35 && head_ptr <= 38)
        {
            snake_body[head_ptr].GetComponent<SpriteRenderer>().sprite = head_sprite[1];
        }
        else if (head_ptr >= 39 && head_ptr <= 43)
        {
            snake_body[head_ptr].GetComponent<SpriteRenderer>().sprite = head_sprite[2];
        }
        else if (head_ptr == 44)
        {
            snake_body[head_ptr].GetComponent<SpriteRenderer>().sprite = head_sprite[1];
        }
        else if (head_ptr >= 45 && head_ptr <= 58)
        {
            snake_body[head_ptr].GetComponent<SpriteRenderer>().sprite = head_sprite[2];
        }
        else if (head_ptr == 59)
        {
            snake_body[head_ptr].GetComponent<SpriteRenderer>().sprite = head_sprite[0];
        }
        else if (head_ptr >= 60 && head_ptr <= 64)
        {
            snake_body[head_ptr].GetComponent<SpriteRenderer>().sprite = head_sprite[2];
        }
        else if (head_ptr >= 65 && head_ptr <= 66)
        {
            snake_body[head_ptr].GetComponent<SpriteRenderer>().sprite = head_sprite[0];
        }
        else if (head_ptr >= 67 && head_ptr <= 72)
        {
            snake_body[head_ptr].GetComponent<SpriteRenderer>().sprite = head_sprite[2];
        }
        else if (head_ptr >= 73 && head_ptr <= 75)
        {
            snake_body[head_ptr].GetComponent<SpriteRenderer>().sprite = head_sprite[0];
        }
    }

    // update snake tail sprite
    void update_tail_sprite()
    {
        if (tail_ptr >= 0 && tail_ptr <= 11)
        {
            snake_body[tail_ptr].GetComponent<SpriteRenderer>().sprite = tail_sprite[3];
        }
        else if (tail_ptr == 12)
        {
            snake_body[tail_ptr].GetComponent<SpriteRenderer>().sprite = tail_sprite[1];
        }
        else if (tail_ptr >= 13 && tail_ptr <= 18)
        {
            snake_body[tail_ptr].GetComponent<SpriteRenderer>().sprite = tail_sprite[3];
        }
        else if (tail_ptr == 19)
        {
            snake_body[tail_ptr].GetComponent<SpriteRenderer>().sprite = tail_sprite[0];
        }
        else if (tail_ptr >= 20 && tail_ptr <= 24)
        {
            snake_body[tail_ptr].GetComponent<SpriteRenderer>().sprite = tail_sprite[3];
        }
        else if (tail_ptr >= 25 && tail_ptr <= 26)
        {
            snake_body[tail_ptr].GetComponent<SpriteRenderer>().sprite = tail_sprite[1];
        }
        else if (tail_ptr >= 27 && tail_ptr <= 33)
        {
            snake_body[tail_ptr].GetComponent<SpriteRenderer>().sprite = tail_sprite[3];
        }
        else if (tail_ptr >= 34 && tail_ptr <= 37)
        {
            snake_body[tail_ptr].GetComponent<SpriteRenderer>().sprite = tail_sprite[1];
        }
        else if (tail_ptr >= 38 && tail_ptr <= 42)
        {
            snake_body[tail_ptr].GetComponent<SpriteRenderer>().sprite = tail_sprite[2];
        }
        else if (tail_ptr == 43)
        {
            snake_body[tail_ptr].GetComponent<SpriteRenderer>().sprite = tail_sprite[1];
        }
        else if (tail_ptr >= 44 && tail_ptr <= 57)
        {
            snake_body[tail_ptr].GetComponent<SpriteRenderer>().sprite = tail_sprite[2];
        }
        else if (tail_ptr == 58)
        {
            snake_body[tail_ptr].GetComponent<SpriteRenderer>().sprite = tail_sprite[0];
        }
        else if (tail_ptr >= 59 && tail_ptr <= 63)
        {
            snake_body[tail_ptr].GetComponent<SpriteRenderer>().sprite = tail_sprite[2];
        }
        else if (tail_ptr >= 64 && tail_ptr <= 65)
        {
            snake_body[tail_ptr].GetComponent<SpriteRenderer>().sprite = tail_sprite[0];
        }
        else if (tail_ptr >= 66 && tail_ptr <= 71)
        {
            snake_body[tail_ptr].GetComponent<SpriteRenderer>().sprite = tail_sprite[2];
        }
        else if (tail_ptr >= 72 && tail_ptr <= 75)
        {
            snake_body[tail_ptr].GetComponent<SpriteRenderer>().sprite = tail_sprite[0];
        }
    }
}
