using TMPro;
using UnityEngine;

/*
 * Author: Peter
 * Date: 7 Aug 2022
 * Class that deals with the UI change for leveling up
 */
public class ChangeLevel : MonoBehaviour
{
    /*
     * Level System of the player
     */
    public LevelSystem level;

    [SerializeField]
    /*
     * The UI that shows that current level of the player
     */
    private TextMeshProUGUI _title;

    private void Start()
    {
        LevelChange(1);
    }

    /*
     * Function that updates the UI to show the level inserted in the params
     */
    public void LevelChange(int level)
    {
        _title.text = "Level " + level;
    }
}
