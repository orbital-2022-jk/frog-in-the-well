using UnityEngine;

public class VoiceLineTrigger : MonoBehaviour
{
    public AudioSource voice_line;
    public VoiceLineSystem voice_line_system;

    // if trigger collide with player
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            // check if voice line is currently playing
            if (!voice_line_system.is_playing)
            {
                voice_line_system.is_playing = true;
                voice_line.Play();
            }

            Destroy(this.gameObject);
        }
    }
}
