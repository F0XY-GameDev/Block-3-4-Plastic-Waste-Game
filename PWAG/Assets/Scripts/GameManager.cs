using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;//setting a game end bool
    public float gameRestartDelay = 2f;//so the game doesnt restart too fast

    public GameObject completeLevelUI;
    public void CompleteLevel()
    {
        completeLevelUI.SetActive(true);//enable the End level UI panel upon collision with the 3d object 
    }
    public void EndGame ()
    {
        if(gameHasEnded == false)// if we fell of the map
        {
            gameHasEnded = true;//end the game
            Invoke("Restart", gameRestartDelay);//restart the game with some delay
        }
    }

    void Restart ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);//restart the current active scene
    }
    
}
