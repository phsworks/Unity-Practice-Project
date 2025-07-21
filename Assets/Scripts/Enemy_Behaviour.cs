using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;
using System;



public class Enemy_Behaviour : MonoBehaviour
{
    public Transform PatrolRoute;

    public List<Transform> Locations;

    private int _locationIndex = 0;

    private NavMeshAgent _agent;

    public Transform Player;

    private bool _isChasingPlayer;

    private int _lives = 3;

    public int EnemyLives
    {
        get { return _lives; }

        private set
        {
            _lives = value;


            if (_lives <= 0)
            {
                Destroy(this.gameObject);
                Debug.Log("Enemy Down");
            }
        }
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        _agent = GetComponent<NavMeshAgent>();

        InitializePatrolRoute();

        MoveToNextPatrolLocation();

        Player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (_agent.remainingDistance < 0.2f && !_agent.pathPending)
        {
            MoveToNextPatrolLocation();
        }
    }

    void InitializePatrolRoute()
    {
        foreach (Transform child in PatrolRoute)
        {
            Locations.Add(child);

        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Bullet(Clone)")
        {
            EnemyLives -= 1;
            Debug.Log("Critical Hit");
        }
    }

    void MoveToNextPatrolLocation()
    {
        if (Locations.Count == 0) return;


        _agent.destination = Locations[_locationIndex].position;

        _locationIndex = (_locationIndex + 1) % Locations.Count;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _agent.destination = Player.position;
            Debug.Log("Enemy Detected");
        }
    }
}
