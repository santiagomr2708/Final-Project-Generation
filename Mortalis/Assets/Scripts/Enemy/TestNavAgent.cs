using UnityEngine;
using UnityEngine.AI;

public class TestNavAgent : MonoBehaviour
{
    public Transform target;

    void Start()
    {
        GetComponent<NavMeshAgent>().SetDestination(target.position);
    }
}

