using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LearningCurve : MonoBehaviour
{
    private Transform camTransform;
    public GameObject directionalLight;
    private Transform lightTransform;
    // Start is called before the first frame update
    void Start()
    {
        //directionalLight = GameObject.Find("Directional Light");
        lightTransform = directionalLight.GetComponent<Transform>();
        camTransform = this.GetComponent<Transform>();
        Debug.Log(camTransform.position);
        Debug.Log(lightTransform.position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
