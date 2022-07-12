using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarningSkillTree : MonoBehaviour
{
    private float timer;
    public GameObject warning;
    public AudioSource warningSound;
    void Update()
    {
        timer -= Time.unscaledDeltaTime;
        if (timer < 0)
        {
            HideWarning();
        }
    }

    public void ShowWarning()
    {
        warningSound.Play();
        warning.SetActive(true);
        timer = 2.5f;
    }

    public void HideWarning()
    {
        warning.SetActive(false);
    }
}
