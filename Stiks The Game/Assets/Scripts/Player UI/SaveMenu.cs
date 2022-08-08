using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Level 0 Tutorial");
    }

    public void Back()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
