using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCWayPoints : MonoBehaviour
{
    private NavMeshAgent agent;
    [SerializeField] private Transform[] wayPoints;
    private int tempCount;
    bool isDone = true;
    void Start()
    {
        tempCount = 0;
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(wayPoints[0].position);

    }

    private void Update()
    {
        Wandering();

    }
    private void Wandering()
    {
        if (Vector3.SqrMagnitude(wayPoints[tempCount].position - transform.position) < 0.5f)
        {
            tempCount++;
            if (tempCount >= wayPoints.Length)
            {
                tempCount = 0;
            }
            agent.SetDestination(wayPoints[tempCount].position);

        }

    }
}
