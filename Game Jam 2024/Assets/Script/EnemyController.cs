using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target;  // Player's transform
    private NavMeshAgent navMeshAgent;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();

        if (target == null)
        {
            Debug.LogError("Target (Player) not assigned.");
        }
    }

    void Update()
    {
        if (target != null)
        {
            // Set the destination for the NavMeshAgent to follow
            navMeshAgent.SetDestination(target.position);
        }
    }
}
