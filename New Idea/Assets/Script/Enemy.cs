using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent  (typeof (NavMeshAgent))]
public class Enemy : MonoBehaviour
{
    NavMeshAgent pathfinder;
    Transform target;

    void Start()
    {
        pathfinder = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        pathfinder.SetDestination(target.position);
    }
}
