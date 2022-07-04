using UnityEngine;

public class StarTrigger : MonoBehaviour
{
    // if trigger collide with player
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            // star collected
            PlayerPrefs.SetInt(this.name.ToString(), 1);
            Destroy(this.gameObject);
        }
    }
}
