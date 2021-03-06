
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverTrigger : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider)
    {
        // if trigger collide with player
        if (collider.gameObject.tag == "Player")
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
