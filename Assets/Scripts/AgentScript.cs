using UnityEngine;
using UnityEngine.AI;

public class AgentScript : MonoBehaviour
{
    NavMeshAgent agent;
    [SerializeField] Transform[] patrolPoints;
    [SerializeField] float arrivalDistance = 1f;
    [SerializeField] Animator anim;
    [SerializeField] RaycastSight Raycast;
    [SerializeField] float velocity;
    [SerializeField] Transform playerTransform;


    private Transform currentDestination;
    private int currentPatrolPointIndex = 0;
    private bool persiguiendo = false;
    public Transform nuevaDireccion;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
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
        if (Raycast.jugadorVisible == true)
        {
            nuevaDireccion = playerTransform;
            agent.SetDestination(nuevaDireccion.position);
        }
        else
        {
            // Si el agente está cerca del punto actual, cambia al siguiente
            if (agent.remainingDistance <= arrivalDistance)
            {
                if (currentPatrolPointIndex < patrolPoints.Length - 1)
                {
                    currentPatrolPointIndex++;
                }
                else
                {
                    currentPatrolPointIndex = 0;
                }
                currentDestination = patrolPoints[currentPatrolPointIndex];
            }

            // Asegúrate de asignar siempre el destino a currentDestination
            agent.SetDestination(currentDestination.position);
        }

        velocity = agent.velocity.magnitude;
        anim.SetFloat("Speed", velocity);
    }


}
