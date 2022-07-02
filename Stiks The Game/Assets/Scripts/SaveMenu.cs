using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Level 0 Tutorial 1");
    }

    public void Back()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
