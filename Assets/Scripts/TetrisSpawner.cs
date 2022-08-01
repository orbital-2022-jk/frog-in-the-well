using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrisSpawner : MonoBehaviour
{
    public GameObject[] tetrominos = new GameObject[7];
    public float max_delay;
    public float min_delay;
    private float delay;
    private float curr_delay;
    public float fall_speed;
    private float x,
        y;
    private float tetris_min_y = 41.0f;
    private int random_tetromino;

    // Start is called before the first frame update
    void Start()
    {
        // initialise location of tetris spawner
        x = this.transform.position.x;
        y = this.transform.position.y;

        // set random delay duration
        delay = Random.Range(min_delay, max_delay);
    }

    // Update is called once per frame
    void Update()
    {
        curr_delay += Time.deltaTime;

        if (curr_delay >= delay)
        {
            // select a random tetromino to spawn
            random_tetromino = Random.Range(0, 6);

            reset_tetromino(tetrominos[random_tetromino]);

            curr_delay = 0;

            // update random delay duration
            delay = Random.Range(min_delay, max_delay);
        }

        remove_tetromino();
    }

    // reset tetromino position to tetromino spawner location
    void reset_tetromino(GameObject tetromino)
    {
        tetromino.SetActive(true);
        tetromino.transform.position = new Vector3(x, y, 0);
        tetromino.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -fall_speed);
    }

    // remove tetromino when reach minimum y
    void remove_tetromino()
    {
        for (int i = 0; i < tetrominos.Length; i++)
        {
            if (tetrominos[i].transform.position.y < tetris_min_y)
            {
                tetrominos[i].SetActive(false);
            }
        }
    }
}
