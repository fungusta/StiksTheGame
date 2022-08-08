using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Author: Peter
 * Date: 7 Aug 2022
 * 
 * Class that deals with the UI in the main menu
 */
public class MainMenu : MonoBehaviour
{
    private void Start()
    {
        //just as a quick fix for dealing with issues
        //when going back to main menu dont know why
        //the preious scene is still loaded
        Destroy(GameObject.FindGameObjectWithTag("Player"));
    }

    /*
     * Function that changes the scene to select character
     */
    public void PlayGame ()
    {
        SceneManager.LoadScene("Select Character");
    }

    /*
     * Function that ends the game and quits the application
     */
    public void QuitGame ()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    /*
     * Function that loads the option menu
     */
    public void Options ()
    {
        SceneManager.LoadScene("Option");
    }
}
