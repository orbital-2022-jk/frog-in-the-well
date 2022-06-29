using UnityEngine;

public class StarTrigger : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            PlayerPrefs.SetInt(this.name.ToString(), 1);
            Destroy(this.gameObject);
        }
    }
}
