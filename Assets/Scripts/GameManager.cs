using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject game_over_ui;

    bool game_over = false;

    public void EndGame()
    {
        if (!game_over)
        {
            game_over = true;

            Invoke("GameOver", 2f);

            Invoke("RestartGame", 5f);
        }
    }

    public void GameOver()
    {
        game_over_ui.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("PlayingScene");
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
