using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    public Vector3 camOffset = new Vector3(0.76f, 3.81f, -4.96f);

    
    private Transform target;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player(Clone)").transform;        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        this.transform.position = target.TransformPoint(camOffset);
     
        this.transform.LookAt(target);
    }
}
