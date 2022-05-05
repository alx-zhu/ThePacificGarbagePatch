using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuFunctions: MonoBehaviour
{

    public void SetScreen(string NextScene)
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene(NextScene);
    }

    public void GoHome() {
        if (PlayerPrefs.GetString("previousScene").Equals("MarineEnvironment"))
        {
            SceneManager.LoadScene("MarineEnvironment");
        }
        else if (PlayerPrefs.GetString("previousScene").Equals("CoralEnvironment")) {
            SceneManager.LoadScene("CoralEnvironment");
        }
    }

    public void QuitGame() {
        Debug.Log("Quit Application.");
        Application.Quit();
    }

    public void RestartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Debug.Log("restarted");
    }
}
