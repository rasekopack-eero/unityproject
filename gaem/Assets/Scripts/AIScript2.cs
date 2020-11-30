using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;

public class AIScript2 : MonoBehaviour
{
    NavMeshAgent agent;
    public Transform enemy;
    
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        List<NavMeshHit> hitList = new List<NavMeshHit>();
        NavMeshHit navHit;

        for (int i = 0; i < 15; i++)
        {
            Vector3 spawnPoint = transform.position;
            Vector2 offset = Random.insideUnitCircle * i;
            spawnPoint.x += offset.x;
            spawnPoint.z += offset.y;

            NavMesh.FindClosestEdge(spawnPoint, out navHit, NavMesh.AllAreas);

            hitList.Add(navHit);
            Vector3 up = new Vector3(navHit.position.x, 10, navHit.position.z);
            Debug.DrawRay(navHit.position, up, Color.green, 10f);
        }

        var sortedList = hitList.OrderBy(x => x.distance);

        foreach (NavMeshHit hit in sortedList)
        {
            if (Vector3.Dot(hit.normal, (enemy.transform.position - transform.position)) < 0)
            {
                agent.SetDestination(hit.position);
                break;
            }
        }
    }
    void FixedUpdate()
    {
        
    }
}
