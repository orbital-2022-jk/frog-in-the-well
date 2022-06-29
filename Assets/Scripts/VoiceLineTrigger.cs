using UnityEngine;

public class VoiceLineTrigger : MonoBehaviour
{
    public AudioSource voice_line;
    private VoiceLineSystem voice_line_system;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);

            if (!voice_line_system.is_playing)
            {
                voice_line.Play();
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        voice_line_system = GetComponent<VoiceLineSystem>();
    }
}
