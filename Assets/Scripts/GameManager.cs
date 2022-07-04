using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool game_over = false;

    public void EndGame()
    {
        if (!game_over)
        {
            game_over = true;

            // load game over scene after 1f
            Invoke("GameOver", 1f);
        }
    }

    // load game over scene
    public void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
