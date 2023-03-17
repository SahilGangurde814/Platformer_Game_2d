using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AfterLevel : MonoBehaviour
{
    // Start is called before the first frame update
    public void NextLevel()
    {
        SceneManager.LoadScene("Level 2");
    }


    public void RestartLevel()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game Closed");
    }
}
