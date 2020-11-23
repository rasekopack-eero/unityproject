using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIScript : MonoBehaviour
{
    public Transform destination;
    NavMeshAgent navMA;
    
    void Start()
    {
        navMA = GetComponent<NavMeshAgent>();
        SetDestination();
    }
    void Update()
    {
        
    }
    void SetDestination()
    {
        Vector3 target = destination.transform.position;
        navMA.SetDestination(target);
    }
}
