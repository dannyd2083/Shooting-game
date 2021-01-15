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
        StartCoroutine(UpadatePath());
    }

    // Update is called once per frame
    void Update()
    {
    }


    // Update every frame find the player target is very expensive so we make this function to contral the frequency
    // 
    IEnumerator UpadatePath()
    {
        float refreshRate = 0.25F;
        while (target != null)
        {
            Vector3 targetPosition = new Vector3(target.position.x, 0, target.position.z); // ensure the target is on the ground
            pathfinder.SetDestination(targetPosition);
            yield return new WaitForSeconds(refreshRate);
        }
    }
}
