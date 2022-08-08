using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Author: Peter
 * Date: 7 Aug 2022
 * 
 * Class that deals with the option menu UI
 */
public class OptionMenu : MonoBehaviour
{
    /*
     * Funcion that brings the user back to the main menu
     */
    public void Back()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
