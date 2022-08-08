using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Author: Peter
 * Date: 7 Aug 2022
 * 
 * Class that deals with the interactions with the pause menu UI in game
 */
public class PauseUI : MonoBehaviour
{
    /*
     * Pause Menu Objects
     */
    public GameObject pauseScreen;
    public GameObject pauseButton;
    public GameObject skillTreeUI;
    public GameObject volumeScreen;

    /*
     * Function that pauses the game and shows the pause menu
     */
    public void OnClickPause()
    {
        //Debug.Log("Paused");
        pauseScreen.SetActive(true);
        pauseButton.SetActive(false);
        PauseGame();
    }

    /*
     * Function that resumes/unpauses the game
     */
    public void OnClickResume()
    {
        pauseScreen.SetActive(false);
        pauseButton.SetActive(true);
        ResumeGame();
    }

    /*
     * Function that opens the skill tree UI
     */
    public void OnClickSkillTree()
    {
        skillTreeUI.SetActive(true);
        pauseScreen.SetActive(false);
    }

    /*
     * Function that exits the skill tree UI and goes back to pause menu
     */
    public void OnClickExitSkillTree()
    {
        skillTreeUI.SetActive(false);
        pauseScreen.SetActive(true);
    }

    /*
     * Function that opens the volume UI
     */
    public void OnClickVolume()
    {
        volumeScreen.SetActive(true);
        pauseScreen.SetActive(false);
    }

    /*
     * Function that exits the volume UI and goes back to pause menu
     */
    public void OnClickExitVolume()
    {
        pauseScreen.SetActive(true);
        volumeScreen.SetActive(false);      
    }

    /*
     * Function that returns player to MainMenu
     */
    public void OnClickHome()
    {
        SceneManager.LoadScene("MainMenu");
    }

    /*
     * Function that pauses time ingame
     */
    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    /*
     * Function that resumes time ingame
     */
    public void ResumeGame()
    {
        Time.timeScale = 1;
    }
}
