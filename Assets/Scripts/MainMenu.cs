using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    PlayerControls player_controls;

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        // if (player_controls.paused)
    }

    public void QuitGame()
    {
        Debug.Log("Quit game");
        Application.Quit();
    }

    void Start()
    {
        player_controls = GetComponent<PlayerControls>();
    }
}
