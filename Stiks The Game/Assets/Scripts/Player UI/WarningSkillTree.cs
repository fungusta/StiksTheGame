using UnityEngine;

/*
 * Author: Peter
 * Date: 8 Aug 2022
 * 
 * Class that deals with the UI of the warning sign when trying to unlock a 
 * skill tree without enough skill points
 */
public class WarningSkillTree : MonoBehaviour
{
    private float timer;

    //Warning object that is shown
    public GameObject warning;

    //Audio that is played when the warning shows up
    public AudioSource warningSound;

    void Update()
    {
        timer -= Time.unscaledDeltaTime;
        if (timer < 0)
        {
            HideWarning();
        }
    }

    /*
     * Function that activates the warning sign
     */
    public void ShowWarning()
    {
        warningSound.Play();
        warning.SetActive(true);
        timer = 2.5f;
    }

    /*
     * Function that hides the warning sign
     */
    public void HideWarning()
    {
        warning.SetActive(false);
    }
}
