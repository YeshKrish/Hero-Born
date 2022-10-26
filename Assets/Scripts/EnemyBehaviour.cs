using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour
{
    public int damage = 5;

    public Transform patrolRoute;

    public List<Transform> locations;

    private int locationIndex = 0;

    private NavMeshAgent navAgent;

    public Transform player;

    private bool dead = false;

    private BulletBehaviour bulletBehaviour;
    private GameBehaviour gameBehaviour;

    private void Start()
    {
        bulletBehaviour = GameObject.FindGameObjectWithTag("Bullet").GetComponent<BulletBehaviour>();
        gameBehaviour = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameBehaviour>();

        player = GameObject.FindGameObjectWithTag("Player").transform;

        navAgent = GetComponent<NavMeshAgent>();

        IntializePatrolRoute();

        MoveToNextTargetLocation();
    }

    private void Update()
    {
        if(navAgent.remainingDistance < 0.1f && !navAgent.pathPending)
        {
            MoveToNextTargetLocation();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            navAgent.destination = player.position;

            Debug.Log("Player Entered");
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player Exit");
        }
    }

    void IntializePatrolRoute()
    {
        foreach(Transform child in locations)
        {
            locations.Add(child);
        }
    }

    void MoveToNextTargetLocation()
    {
        if (locations.Count <= 0)
            return;
        
        navAgent.destination = locations[locationIndex].position;

        locationIndex = (locationIndex + 1) % locations.Count;
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Debug.Log("Hurray! Enemy Hit!");
            gameBehaviour.EnemyHp = gameBehaviour.EnemyHp - bulletBehaviour.bulletDamage;
            Debug.Log("Enemy Health:" + gameBehaviour.EnemyHp);
            this.EnemyDead(gameBehaviour.EnemyHp);
        }
    }

    private void EnemyDead(int damage)
    {
        if(damage <= 0 && !dead)
        {
            this.gameObject.SetActive(false);

            dead = true;
        }
    }


}
