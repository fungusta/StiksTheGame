using UnityEngine;

/*
 * Author: Peter
 * Date: 7 Aug 2022
 * 
 * Class that deals with the players changes to the in-game volume
 */
public class Volume : MonoBehaviour
{
    /*
     * Function that sets volume of the game in turn with the float volume in Unity
     */
    public void SetVolume(float f)
    {
        AudioSource[] audio = GetComponentsInChildren<AudioSource>();
        foreach (AudioSource s in audio)
            s.volume = f;
    }
}
