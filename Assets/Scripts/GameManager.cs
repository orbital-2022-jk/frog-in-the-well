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

            Invoke("RestartGame", 2f);
        }
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
