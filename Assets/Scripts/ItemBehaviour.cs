using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBehaviour : MonoBehaviour
{
    private GameObject particleSys;

    private GameBehaviour gameBehaviour;

    void Start()
    {
        gameBehaviour = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameBehaviour>();
    }

    private void OnCollisionEnter(Collision collision)
    {      
        if(collision.gameObject.CompareTag("Player"))
        {
            this.transform.parent.gameObject.SetActive(false);

            Debug.Log("Item Picked");

            gameBehaviour.ItemsCollected += 1;
        }  
    }
}
