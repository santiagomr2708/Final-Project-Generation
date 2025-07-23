using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public float wanderRadius = 15f;
    public float minDistanceFromCurrent = 10f;
    public float detectionRadius = 12f;

    public Transform player;

    private NavMeshAgent agent;
    private enum State { Wandering, Chasing }
    private State currentState = State.Wandering;
    [SerializeField] AudioClip enemyDetection;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player").transform;
        SetNewDestination();
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // Cambiar de estado seg�n la distancia al jugador
        if (distanceToPlayer <= detectionRadius)
        {
            if (currentState != State.Chasing)
            {
                currentState = State.Chasing;
                SoundFXManager.instance.PlaySoundFXClip(enemyDetection, transform, 1f, false);
            }
        }
        else
        {
            if (currentState == State.Chasing)
            {
                // Solo volver a patrullar si estaba persiguiendo
                currentState = State.Wandering;
                SetNewDestination();
            }
        }

        // Ejecutar comportamiento seg�n estado
        switch (currentState)
        {
            case State.Wandering:
                WanderLogic();
                break;
            case State.Chasing:
                ChasePlayer();
                break;
        }
    }

    void WanderLogic()
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

    void ChasePlayer()
    {
        agent.SetDestination(player.position);
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

        return origin;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}

