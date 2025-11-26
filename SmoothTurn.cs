using UnityEngine;
using UnityEngine.AI;

public class SmoothTurn : MonoBehaviour
{
    private NavMeshAgent agent;
    public float turnSpeed = 10f; // Fast turning

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        // We will handle rotation manually
        agent.updateRotation = false; 
    }

    void Update()
    {
        if (agent.pathPending || agent.steeringTarget == transform.position) return;

        // 1. Where is the next point on the path?
        Vector3 direction = (agent.steeringTarget - transform.position).normalized;
        direction.y = 0; // Keep it flat on the ground

        if (direction != Vector3.zero)
        {
            // 2. Calculate rotation
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            
            // 3. Force the turn
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
        }
    }
}