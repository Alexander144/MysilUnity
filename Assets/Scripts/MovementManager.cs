using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MovementManager : MonoBehaviour
{
    private NavMeshAgent Agent;
    private Animator Animator;
    public bool startRunning = false;
    // Start is called before the first frame update
    void Start()
    {
        Agent = this.GetComponent<NavMeshAgent>();
        Animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Agent.hasPath && startRunning)
        {
            Agent.SetDestination(GetRandomPoint(this.transform.position, 2f));
        }
    }

    public void StartRunningAnimation()
    {
        Animator.SetBool("Run", true);
    }

    public static Vector3 GetRandomPoint(Vector3 center, float maxDistance)
    {
        // Get Random Point inside Sphere which position is center, radius is maxDistance
        Vector3 randomPos = Random.insideUnitSphere * maxDistance + center;

        UnityEngine.AI.NavMeshHit hit; // NavMesh Sampling Info Container

        // from randomPos find a nearest point on NavMesh surface in range of maxDistance
        UnityEngine.AI.NavMesh.SamplePosition(randomPos, out hit, maxDistance, UnityEngine.AI.NavMesh.AllAreas);

        return hit.position;
    }
}
