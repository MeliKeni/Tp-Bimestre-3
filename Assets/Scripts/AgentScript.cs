using UnityEngine;
using UnityEngine.AI;

public class AgentScript : MonoBehaviour
{
    NavMeshAgent agent;
    [SerializeField] Transform[] patrolPoints;
    [SerializeField] float arrivalDistance = 1f;
    [SerializeField] Animator anim;
    [SerializeField] RaycastScript Raycast; 

    private Transform currentDestination;
    private int currentPatrolPointIndex = 0;
    private Transform playerTransform;
    private bool persiguiendo = false;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        GameObject playerGO = GameObject.FindWithTag("Player");
        if (playerGO != null)
            playerTransform = playerGO.transform;
        else
            Debug.LogError("No se encontró el player con tag 'Player'");
    }

    void Start()
    {
        if (patrolPoints.Length > 0)
        {
            currentPatrolPointIndex = 0;
            currentDestination = patrolPoints[currentPatrolPointIndex];
            agent.SetDestination(currentDestination.position);
        }
    }

    void Update()
    {
        if (Raycast != null && Raycast.jugadorVisible && playerTransform != null)
        {
            persiguiendo = true;
            currentDestination = playerTransform;
        }
        else
        {
            if (persiguiendo) persiguiendo = false; 

            if (!agent.pathPending && agent.remainingDistance <= arrivalDistance)
            {
                currentPatrolPointIndex = (currentPatrolPointIndex + 1) % patrolPoints.Length;
                currentDestination = patrolPoints[currentPatrolPointIndex];
            }
        }

            agent.SetDestination(currentDestination.position);
            anim.SetFloat("Speed", agent.velocity.magnitude);
    }
}
