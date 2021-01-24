using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent  (typeof (NavMeshAgent))]
public class Enemy : LivingEntity
{
    NavMeshAgent pathfinder;
    Transform target;
    float attackDistanceThreshold = 1.5f;
    float timeBetweenAttack = 1;
    float nextAttackTime;
    protected override void Start()
    {
        base.Start();
        pathfinder = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(UpadatePath());
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextAttackTime) {
            float sqrDstToTarget = (target.position - transform.position).sqrMagnitude;
            if (sqrDstToTarget < Mathf.Pow(attackDistanceThreshold, 2)) {
                nextAttackTime = Time.time + timeBetweenAttack;
            }
        }
    }


    IEnumerator Attack()
    {
        Vector3 originalPosition = transform.position;
        Vector3 attackPosition = target.position;
        float percent = 0;
        float attackSpeed = 3;
        while(percent <= 1)
        {
            percent += Time.deltaTime * attackSpeed;
            yield return null;
        }
    }

    // Update every frame find the player target is very expensive so we make this function to contral the frequency
    // 
    IEnumerator UpadatePath()
    {
        float refreshRate = 0.25F;
        while (target != null)
        {
            Vector3 targetPosition = new Vector3(target.position.x, 0, target.position.z); // ensure the target is on the ground
            if (!dead) 
            {
                pathfinder.SetDestination(targetPosition);
            }
            yield return new WaitForSeconds(refreshRate);
        }
    }
}
