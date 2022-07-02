using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBullet : MonoBehaviour
{
    // Start is called before the first frame update
    public float destroyTime = 1f;
    void Start()
        
        {
            Destroy(gameObject, destroyTime);
        }
    
    }
    