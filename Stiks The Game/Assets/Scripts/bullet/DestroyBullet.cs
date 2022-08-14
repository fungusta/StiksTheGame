using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Author: Jason
 * Date: 8 Aug 2022
 * 
 * Class that deals with dedstruction of bullets
 */


public class DestroyBullet : MonoBehaviour
{
    // Start is called before the first frame update
    //bullet destroyed after a certain time
    public float destroyTime = 1f;
    void Start()
        
        {
            Destroy(gameObject, destroyTime);
        }
    
    }
    