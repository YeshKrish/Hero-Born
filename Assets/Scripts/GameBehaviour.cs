using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameBehaviour : MonoBehaviour
{

    private int itemsCollected = 0;

 
    private int enemyHp = 100;

    public bool winOrLoss = false;
    public bool isdead;

    public string lableText = "Collect 4 Items to Win!";
    public const int maxItems = 4;
    public string gameOver = "You Won";

    public GameObject enemySpawnPoint;
    public GameObject playerSpwanPoint;

    public GameObject enemy;
    public GameObject player;

    private void Start()
    {
        PlayerHP = 100;
        Instantiate(enemy, enemySpawnPoint.transform.position, Quaternion.identity);
        Instantiate(player, playerSpwanPoint.transform.position, Quaternion.identity);
    }
    void RestartLevel()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1.0f;
    }
    public int ItemsCollected
    {
        get
        {
            return itemsCollected;
        }
        set
        {
            itemsCollected = value;
            Debug.LogFormat("Items Collected: {0}", itemsCollected);
           
            if(itemsCollected == maxItems)
            {
                lableText = "You have found all the items";
                winOrLoss = true;
                Time.timeScale = 0f;
            }
            else
            {
                lableText = "Items Found Only" + (maxItems - itemsCollected) + "Collect remaining items";
            }
        }

        
    }
    private int _playerHp = 100;

    public int PlayerHP
    {
        get
        {
            return _playerHp;
        }
        set
        {
            _playerHp = value;
            Debug.LogFormat("The Current Player HP: {0}", _playerHp);

            if (_playerHp <= 0)
            {
                isdead = true;
                Time.timeScale = 0f;
                
            }
        }
    }

    public int EnemyHp
    {
        get
        {
            return enemyHp;
        }
        set
        {
            enemyHp = value;
        }

    }

    private void OnGUI()
    {
        GUI.Box(new Rect(20, 20, 150, 25), "Player Health:" + PlayerHP);
        GUI.Box(new Rect(20, 50, 150, 25), "Items Collected:" + itemsCollected);
        GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height - 50, 300, 50), lableText);

        if (winOrLoss)
        {
            if(GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2, 200, 100), "You Won!"))
            {
                Utilities.RestartLevel();
            }

        }
        else if(isdead)
        {
            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2, 200, 100), "You Lost!"))
            {
                Utilities.RestartLevel();
            }
        }

    }
}
