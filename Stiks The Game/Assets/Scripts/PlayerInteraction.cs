using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerInteraction : MonoBehaviour
{
    public PlayerHealth player;
    public GameObject[] sections;
    private int currSection = 0;


    private void OnTriggerEnter2D(Collider2D collision)
    {
    
        //Player to proceed to next level if player collides with a trigger collider with the Finish tag
        if (collision.CompareTag("Finish"))
        {
            //Load next level
            SceneManager.LoadScene("MainMenu");
        }
        //If player collide with a trigger collider with the NextScene, load next scene
        if (collision.CompareTag("NextScene"))
        {
            DontDestroyOnLoad(GameObject.FindGameObjectWithTag("Player"));
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        if (collision.CompareTag("NextSection"))
        {
            sections[currSection].SetActive(true);
            Destroy(collision.gameObject);
            currSection++;
        }

        if (collision.CompareTag("Death"))
        {
            player.Die();
        }
    }
}
