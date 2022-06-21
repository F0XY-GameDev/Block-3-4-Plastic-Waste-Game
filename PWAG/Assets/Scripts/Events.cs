using UnityEngine.SceneManagement;
using UnityEngine;

public class Events : MonoBehaviour
{
    public void RestartGame()
    {
        SceneManager.LoadScene("Game");

    }

    public void QuitGame()
    {
        Application.Quit();
    }
   
}
