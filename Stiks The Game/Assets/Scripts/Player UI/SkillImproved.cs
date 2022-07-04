using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillImproved : MonoBehaviour
{
    public SkillImproved[] parents;
    public GameObject[] connected;

    public bool clicked;
    public void onClickButton()
    {
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
        clicked = true;
    }

}
