using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    public float onScreenDelay = 3f;

    public int bulletDamage = 20;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, onScreenDelay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
