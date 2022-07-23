using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectCharacter : MonoBehaviour
{
    public void StartGame(int character)
    {
        PlayerPrefs.SetInt("selectedCharacter", character);
        SceneManager.LoadScene("Level 0 Tutorial");
    }
}
