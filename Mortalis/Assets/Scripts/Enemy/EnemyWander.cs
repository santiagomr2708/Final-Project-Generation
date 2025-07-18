using UnityEngine;
using UnityEngine.AI;

public class EnemyWander : MonoBehaviour
{
    public float wanderRadius = 15f;
    public float minDistanceFromCurrent = 10f;

    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        SetNewDestination();
    }

    void Update()
    {
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            SetNewDestination();
        }
    }

    void SetNewDestination()
    {
        Vector3 newDestination = GetRandomPoint(transform.position, minDistanceFromCurrent, wanderRadius);
        agent.SetDestination(newDestination);
    }

    Vector3 GetRandomPoint(Vector3 origin, float minDist, float maxDist)
    {
        Vector2 random2D = Random.insideUnitCircle.normalized * Random.Range(minDist, maxDist);
        Vector3 randomDirection = new Vector3(random2D.x, 0, random2D.y);
        Vector3 candidatePoint = origin + randomDirection;

        NavMeshHit navHit;
        if (NavMesh.SamplePosition(candidatePoint, out navHit, maxDist, NavMesh.AllAreas))
        {
            return navHit.position;
        }

        return origin; // fallback si no encuentra un punto válido
    }
}
