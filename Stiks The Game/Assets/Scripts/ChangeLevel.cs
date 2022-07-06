using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChangeLevel : MonoBehaviour
{
    public LevelSystem level;

    [SerializeField]
    private TextMeshProUGUI _title;

    private void Start()
    {
        LevelChange(1);
    }
    public void LevelChange(int level)
    {
        _title.text = "Level " + level;
    }
}
