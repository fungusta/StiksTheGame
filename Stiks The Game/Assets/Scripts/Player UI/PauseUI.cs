using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseUI : MonoBehaviour
{
    public GameObject pauseScreen;
    public GameObject pauseButton;

    public void OnClickPause()
    {
        //Debug.Log("Paused");
        pauseScreen.SetActive(true);
        pauseButton.SetActive(false);
        PauseGame();
    }

    public void OnClickResume()
    {
        pauseScreen.SetActive(false);
        pauseButton.SetActive(true);
        ResumeGame();
    }

    public void OnClickSkillTree()
    {
        //TBD how to implement
    }

    public void OnClickVolume()
    {
        //TBD
    }

    public void OnClickHome()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
    }
}
