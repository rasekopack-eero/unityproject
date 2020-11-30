using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIScript : MonoBehaviour
{
    public Transform destination;
    public Transform secondary;
    public Transform player;
    bool playerspotted = false;
    NavMeshAgent navMA;
    
    void Start()
    {
        navMA = GetComponent<NavMeshAgent>();
        SetDestination(destination);
    }
    void FixedUpdate()
    {
        if (Vector3.Distance(transform.position, player.position) < 10f && !playerspotted)
        {
            playerspotted = true;
            SetDestination(secondary);
        }
        if(playerspotted)
        {
            navMA.updateRotation = false;
            transform.LookAt(player.transform);
            if (Vector3.Distance(transform.position, player.position) > 20f)
            {
                playerspotted = false;
            }
        }
        /*   
        NavMeshHit hit;
        if (NavMesh.FindClosestEdge(transform.position, out hit, NavMesh.AllAreas))
        {
            Debug.DrawRay(hit.position, Vector3.up, Color.red, 10f);
        }
        */
    }
    void SetDestination(Transform destination)
    {
        navMA.SetDestination(destination.position);
    }
}
