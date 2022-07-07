using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillImproved : MonoBehaviour
{
    public SkillTreeEffects skillTree;
    public SkillImproved[] parents;
    public GameObject[] connected;

    public bool clicked;
    public void OnClickButton()
    {
        if(!skillTree.PointCheck())
        {
            return;
        }
        for (int i = 0; i < parents.Length; i++)
        {
            if (!parents[i].clicked)
            {
                return;
            }
        }
        for (int i = 0; i < connected.Length; i++)
        {
            connected[i].SetActive(true);
        }
        GetComponent<Button>().interactable = false;
        skillTree.Effect(this.name);
        clicked = true;
    }

}
