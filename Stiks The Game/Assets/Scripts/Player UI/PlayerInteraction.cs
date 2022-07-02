using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerInteraction : MonoBehaviour
{
    public GameObject[] sections;
    private int currSection = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
    
        //Player to proceed to next level if player collides with a trigger collider with the Finish tag
        if (collision.tag == "Finish")
        {
            //Load next level
            SceneManager.LoadScene("MainMenu");
        }
        //If player collide with a trigger collider with the NextScene, load next scene
        if (collision.tag == "NextScene")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        if (collision.tag == "NextSection")
        {
            sections[currSection].SetActive(true);
            Destroy(collision.gameObject);
            currSection++;
        }

        if (collision.tag == "Death")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
