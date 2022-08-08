using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Author: Peter
 * Date: 7 Aug 2022
 * 
 * Class that deals with the select character UI
 */
public class SelectCharacter : MonoBehaviour
{
    /*
     * Function that starts game with a selected character by saving
     * that specfic character int and passing it down to the start of the game
     */
    public void StartGame(int character)
    {
        PlayerPrefs.SetInt("selectedCharacter", character);
        SceneManager.LoadScene("Level 0 Tutorial");
    }
}
