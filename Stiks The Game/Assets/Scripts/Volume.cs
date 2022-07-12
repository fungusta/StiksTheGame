using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Volume : MonoBehaviour
{
    public void SetVolume(float f)
    {
        AudioSource[] audio = GetComponentsInChildren<AudioSource>();
        foreach (AudioSource s in audio)
            s.volume = f;
    }
}
