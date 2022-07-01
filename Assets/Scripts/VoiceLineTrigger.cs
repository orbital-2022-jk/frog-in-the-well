using UnityEngine;

public class VoiceLineTrigger : MonoBehaviour
{
    public AudioSource voice_line;
    public VoiceLineSystem voice_line_system;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            if (!voice_line_system.is_playing)
            {
                voice_line_system.is_playing = true;
                voice_line.Play();
            }

            Destroy(this.gameObject);
        }
    }
}
