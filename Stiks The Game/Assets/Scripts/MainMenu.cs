using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame ()
    {
        SceneManager.LoadScene("Level 0 Tutorial 1");
    }

    public void QuitGame ()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void Options ()
    {
        SceneManager.LoadScene("Option");
    }
}
