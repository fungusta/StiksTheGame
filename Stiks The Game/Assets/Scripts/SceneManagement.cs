using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Author: Peter
 * Date: 7 Aug 2022
 * 
 * Class that deals with the player movement between scenes
 */
public class SceneManagement : MonoBehaviour
{
    /*
     * The class of character chosen by the player
     */
    public GameObject playerPrefab;

    /*
     * The instance of the character chosen
     */
    public GameObject player;

    /*
     * The start point of the scene
     */
    Vector3 startPoint;

    /*
     * The Characters available to be chosen in the Select Character Scene
     */
    public GameObject[] characterPrefabs;

    // Start is called before the first frame update
    void Start()
    {
        //Use this component on the start point so that the player always spawns at that point
        startPoint = transform.position;
        player = GameObject.FindGameObjectWithTag("Player");

        //If no player is found, instantiate a new player and save it
        if (player == null)
        {
            int selectedCharacter = PlayerPrefs.GetInt("selectedCharacter");
            playerPrefab = characterPrefabs[selectedCharacter];
            player = playerPrefab;
            Instantiate(player);
        } else 
        {
            //If a player is found, the player is moved to the new scene.
            SceneManager.MoveGameObjectToScene(player, SceneManager.GetActiveScene());
            player.transform.position = startPoint;
        }
        
    }
}
