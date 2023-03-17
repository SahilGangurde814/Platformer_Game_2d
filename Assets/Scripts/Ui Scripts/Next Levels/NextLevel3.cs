using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel3 : MonoBehaviour
{
    public void NextLevel()
    {
        SceneManager.LoadScene("Level 4");
    }


    public void RestartLevel()
    {
        SceneManager.LoadScene("Level 3");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game Closed");
    }
}
