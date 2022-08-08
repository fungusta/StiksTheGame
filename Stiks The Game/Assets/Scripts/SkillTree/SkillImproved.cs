using UnityEngine;
using UnityEngine.UI;

/*
 * Author: Peter
 * Date: 7 Aug 2022
 * 
 * Class that deals with the UI interaction of the skill tree UI
 * in the pause menu. Applied to each skill icon in the skill tree
 */
public class SkillImproved : MonoBehaviour
{
    /*
     * System that updates the character traits when skill trees are active
     */
    public SkillTreeEffects skillTree;

    /*
     * Parents of current skill, current skill can only be unlocked if parents
     * have been already unlocked.
     */
    public SkillImproved[] parents;

    /*
     * Connectors that are connect to current skill, that will become active,
     * upon the skill being activated
     */
    public GameObject[] connected;

    /*
     * Sound that is played when the skill is activated
     */
    public AudioSource skillTreeLevelUpSound;

    /*
     * Boolean that is true when the skill is activated
     */
    public bool clicked;

    /*
     * Function that occurs when the skill icon is clicked
     */
    public void OnClickButton()
    {
        for (int i = 0; i < parents.Length; i++)
        {
            //If any parents are not active yet, do not activate skill
            if (!parents[i].clicked)
            {
                return;
            }
        }

        //If not enough skills points, cannot activate skill
        if (!skillTree.PointCheck())
        {
            return;
        }

        //Set connectors to be active as well as skill
        for (int i = 0; i < connected.Length; i++)
        {
            connected[i].SetActive(true);
        }
        skillTreeLevelUpSound.Play();
        GetComponent<Button>().interactable = false;
        skillTree.Effect(this.name);
        clicked = true;
    }

}
