using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceLineSystem : MonoBehaviour
{
    public Rigidbody2D rb;

    public bool is_playing = false;
    public AudioSource[] voice_lines;
    private int random_voice_line = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // if fall more than 20 blocks
        if (!is_playing && rb.velocity.y <= -40)
        {
            is_playing = true;

            // generate random voice line
            random_voice_line = Random.Range(0, voice_lines.Length);
            voice_lines[random_voice_line].Play();

        }

        if (!voice_lines[random_voice_line].isPlaying)
        {
            is_playing = false;
        }
    }
}
