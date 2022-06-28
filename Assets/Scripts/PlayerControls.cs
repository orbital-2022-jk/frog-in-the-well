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
    private float ray_cast_length = 0.3f;
    private float collision_threshold = 0.3f;

    public PhysicsMaterial2D bouncy_material, normal_material;
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

    void Pause()
    {
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
                dir = 1;
            }
            // contact right
            else if (col_x - collision_threshold > curr_x)
            {
                dir = -1;
            }

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

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        circ_col = GetComponent<CircleCollider2D>();
        width = GetComponent<CircleCollider2D>().bounds.extents.x + 0.1f;
        height = GetComponent<CircleCollider2D>().bounds.extents.y + 0.1f;

        // points
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
        if (Input.GetKeyDown(KeyCode.P))
        {
            paused = !paused;
            Pause();
        }

        if (!paused)
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

            for (int i = 0; i < num_points; i++)
            {
                points[i].transform.position = pointPos(i * 0.1f, charge);
            }
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

    Vector2 pointPos(float t, float charge)
    {
        Vector2 curr_point_pos = (Vector2)transform.position + (new Vector2(dir * charge, jump_height * charge) * t) + 0.5f * rb.gravityScale * Physics2D.gravity * (t * t);

        return curr_point_pos;
    }
}
