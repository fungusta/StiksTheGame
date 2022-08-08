using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Author: Peter
 * Date: 7 Aug 2022
 * 
 * Class that deals with player interactions upon collision with other objects
 * in the game.
 */
public class PlayerInteraction : MonoBehaviour
{
    /*
     * Player Health
     */
    private PlayerHealth player;

    /*
     * Sections of the game that we want to be unlocked upon interacting with
     * certain points of the map.
     */
    public GameObject[] sections;

    /*
     * Number of Sections
     */
    private int currSection = 0;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }

    /*
     * Function that does certain things upon collision depending on the objects
     * tag in Unity.
     */
    private void OnTriggerEnter2D(Collider2D collision)
    {
    
        //Player to proceed to next level if player collides with a
        //trigger collider with the Finish tag.
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
