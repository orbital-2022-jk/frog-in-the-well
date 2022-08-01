using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControls : MonoBehaviour
{
    private Rigidbody2D rb;
    private CircleCollider2D circ_col;
    Vector2 prev_velocity;
    private float width;
    private float height;
    private float ray_cast_length = 0.1f;
    private float collision_threshold = 0.3f;

    public PhysicsMaterial2D bouncy_material,
        normal_material;
    public float dir;
    public float charge;
    public float charge_rate;
    public float jump_height;
    public float bounce_boost;

    public bool paused = false;
    public GameObject pause_menu;
    public AudioManager audio_manager;

    public GameObject PointPrefab;
    public GameObject[] points;
    public int num_points;

    public Animator animator;

    private bool has_jumped;

    void Pause()
    {
        // toggle pause status and toggle pause menu
        if (paused)
        {
            Time.timeScale = 0f;
            pause_menu.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            pause_menu.SetActive(false);
            audio_manager.SaveSoundSettings();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // fix bug when player interacts with bomb
        if (
            collision.collider.tag == "bomb"
            && !collision.collider.GetComponent<Knockback>().has_exploded
        )
        {
            return;
        }

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
            // contact left
            if (col_x + collision_threshold < curr_x)
            {
                Debug.Log("contact left");
                dir = 1;
            }
            // contact right
            else if (col_x - collision_threshold > curr_x)
            {
                Debug.Log("contact right");
                dir = -1;
            }

            // // var speed = prev_velocity.magnitude;
            // // var direction = Vector2.Reflect(prev_velocity.normalized, collision.contacts[0].normal);
            // // rb.velocity = 0.8f * direction * Mathf.Max(speed, 0f);
        }

        // if player is too close to walls
        if (isLeftWall())
        {
            Debug.Log("left wall");
            dir = 1;
        }
        else if (isRightWall())
        {
            Debug.Log("right wall");
            dir = -1;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        circ_col = GetComponent<CircleCollider2D>();
        width = GetComponent<CircleCollider2D>().bounds.extents.x + 0.1f;
        height = GetComponent<CircleCollider2D>().bounds.extents.y + 0.1f;

        // debugging points
        points = new GameObject[num_points];

        for (int i = 0; i < num_points; i++)
        {
            points[i] = Instantiate(PointPrefab, transform.position, Quaternion.identity);
        }

        // fix bug for camera not lerp to player when click main menu from pause menu
        Pause();
        Pause();
    }

    // Update is called once per frame
    void Update()
    {
        // check for pause buttons
        if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape))
        {
            paused = !paused;
            Pause();
        }

        if (!paused)
        {
            prev_velocity = rb.velocity;

            // ground check
            if (Input.GetButton("Jump") && isGround())
            {
                charge += charge_rate * Time.deltaTime;

                // update animation
                animator.SetBool("space_pressed", true);
            }

            // release check
            if ((charge >= 20f || Input.GetButtonUp("Jump")) && isGround())
            {
                rb.velocity = new Vector2(dir * charge, jump_height * charge);

                charge = 1.0f;

                rb.sharedMaterial = bouncy_material;

                // update animation
                animator.SetBool("space_pressed", false);

                // play sound effect
                Invoke("jumped", 0.1f);

                FindObjectOfType<AudioManager>().Play("player_jump");
            }

            // update positions for debugging points
            for (int i = 0; i < num_points; i++)
            {
                points[i].transform.position = pointPos(i * 0.1f, charge);
            }

            // update animation
            animator.SetFloat("yVelocity", rb.velocity.y);

            if (isGround())
            {
                // update animation
                animator.SetBool("is_grounded", true);

                if (has_jumped)
                {
                    // play sound effect
                    FindObjectOfType<AudioManager>()
                        .Play("player_land");

                    has_jumped = false;
                }
            }
            else
            {
                // update animation
                animator.SetBool("is_grounded", false);
            }

            // update sprite direction
            if (dir == 1)
            {
                transform.localScale = new Vector2(1, transform.localScale.y);
            }
            else if (dir == -1)
            {
                transform.localScale = new Vector2(-1, transform.localScale.y);
            }
            else
            {
                transform.localScale = new Vector2(1, transform.localScale.y);
            }
        }
    }

    // update status of jump
    private void jumped()
    {
        has_jumped = true;
    }

    private bool isGround()
    {
        // return Physics2D.BoxCast(circ_col.bounds.center, circ_col.bounds.size * 0.3f, 0f, Vector2.down, 0.5f, platform);
        // return Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - height), Vector2.down, ray_cast_length);

        // three raycast lines to check for ground from different locations of player
        bool left = Physics2D.Raycast(
            new Vector2(transform.position.x - (width - 0.2f), transform.position.y - height),
            Vector2.down,
            ray_cast_length
        );
        bool mid = Physics2D.Raycast(
            new Vector2(transform.position.x, transform.position.y - height),
            Vector2.down,
            ray_cast_length
        );
        bool right = Physics2D.Raycast(
            new Vector2(transform.position.x + (width - 0.2f), transform.position.y - height),
            Vector2.down,
            ray_cast_length
        );

        if (left || mid || right)
        {
            return true;
        }
        return false;
    }

    // check for wall on left
    private bool isLeftWall()
    {
        return Physics2D.Raycast(
            new Vector2(transform.position.x - (width - 0.05f), transform.position.y),
            Vector2.left,
            ray_cast_length
        );
    }

    // check for wall on right
    private bool isRightWall()
    {
        return Physics2D.Raycast(
            new Vector2(transform.position.x + (width - 0.05f), transform.position.y),
            Vector2.right,
            ray_cast_length
        );
    }

    // update position of points
    Vector2 pointPos(float t, float charge)
    {
        // calculate correct position of points
        Vector2 curr_point_pos =
            (Vector2)transform.position
            + (new Vector2(dir * charge, jump_height * charge) * t)
            + 0.5f * rb.gravityScale * Physics2D.gravity * (t * t);

        return curr_point_pos;
    }
}
