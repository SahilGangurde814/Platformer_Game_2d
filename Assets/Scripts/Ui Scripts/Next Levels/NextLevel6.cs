using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel6 : MonoBehaviour
{
    public void NextLevel()
    {
        SceneManager.LoadScene("Level 7");
    }


    public void RestartLevel()
    {
        SceneManager.LoadScene("Level 6");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game Closed");
    }
}
