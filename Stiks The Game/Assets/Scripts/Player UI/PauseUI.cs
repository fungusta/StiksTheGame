using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseUI : MonoBehaviour
{
    public GameObject pauseScreen;
    public GameObject pauseButton;
    public GameObject skillTreeUI;

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
        skillTreeUI.SetActive(true);
        pauseScreen.SetActive(false);
    }

    public void OnClickExitSkillTree()
    {
        skillTreeUI.SetActive(false);
        pauseScreen.SetActive(true);
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
