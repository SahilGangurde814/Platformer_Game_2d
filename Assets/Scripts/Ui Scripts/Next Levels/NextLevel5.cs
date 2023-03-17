using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel5 : MonoBehaviour
{
    public void NextLevel()
    {
        SceneManager.LoadScene("Level 6");
    }


    public void RestartLevel()
    {
        SceneManager.LoadScene("Level 5");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game Closed");
    }
}