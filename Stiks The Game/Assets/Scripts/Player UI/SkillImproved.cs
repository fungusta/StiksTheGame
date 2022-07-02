using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillImproved : MonoBehaviour
{
    public SkillImproved parent;
    public GameObject[] connected;

    public bool clicked;
    public void onClick()
    {
        if (parent == null || parent.clicked == true)
        {
            for (int i = 0; i < connected.Length; i++)
            {
                connected[i].SetActive(true);
            }
            GetComponent<Button>().interactable = false;
            clicked = true;
        }
    }

}
