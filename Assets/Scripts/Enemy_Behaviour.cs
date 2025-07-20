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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InitializePatrolRoute();

        _agent = GetComponent<NavMeshAgent>();
        InitializePatrolRoute();

        MoveToNextPatrolLocation();
    }

    // Update is called once per frame
    void Update()
    {
        if (_agent.remainingDistance < 0.2f && _agent.pathPending)
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

    void MoveToNextPatrolLocation()
    {
        if (Locations.Count == 0) return;


        _agent.destination = Locations[_locationIndex].position;

        _locationIndex = (_locationIndex + 1) % Locations.Count;
    }
}
