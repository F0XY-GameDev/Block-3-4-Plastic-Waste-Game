using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour
{
    /* This class exists to hold the current state of our game
     * it will hold the bool and int values for quest progression
     * it must be attached to the GameStateManager GameObject in the scene
     * 
     * 
     * 
     * 
     */
    public bool[] Q1Flags;
    //element 0 is q1 accepted
    //element 1 is q1 completed
    //element 2 is q1 objectives fulfilled

    private void Update()
    {
        if (Q1Flags[1])
        {
            StartCoroutine(ExecuteAfterTime(10));
        }
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        SceneManager.LoadScene(2);
        // Code to execute after the delay
    }
}
