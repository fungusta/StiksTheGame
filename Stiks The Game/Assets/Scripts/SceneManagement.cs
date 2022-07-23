using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject player;
    Vector3 startPoint;
    public GameObject[] characterPrefabs;
    // Start is called before the first frame update
    void Start()
    {
        //Use this component on the start point so that the player always spawns at that point
        startPoint = transform.position;
        player = GameObject.FindGameObjectWithTag("Player");
        if (player == null)
        {
            int selectedCharacter = PlayerPrefs.GetInt("selectedCharacter");
            playerPrefab = characterPrefabs[selectedCharacter];
            player = playerPrefab;
            Instantiate(player);
        } else
        {
            SceneManager.MoveGameObjectToScene(player, SceneManager.GetActiveScene());
            player.transform.position = startPoint;
        }
        
    }
}
