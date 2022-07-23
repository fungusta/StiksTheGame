using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private void Start()
    {
        //just as a quick fix for dealing with issues when going back to main menu dont know why the preious scene is still loaded
        Destroy(GameObject.FindGameObjectWithTag("Player"));
    }
    public void PlayGame ()
    {
        SceneManager.LoadScene("Select Character");
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
