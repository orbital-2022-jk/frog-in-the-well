using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // load game scene
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // quit game
    public void QuitGame()
    {
        Debug.Log("Quit game");
        Application.Quit();
    }
}
