using UnityEngine;
using UnityEngine.AI;

public class SimpleAI : MonoBehaviour
{
    public Transform finishLine;
    private NavMeshAgent agent;
    private bool isRacing = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        if (agent != null) 
        {
            // Freeze the spider at the start
            agent.isStopped = true;
        }
    }

    void Update()
    {
        // If the race started, hunt the target
        if (isRacing && finishLine != null)
        {
            agent.SetDestination(finishLine.position);
        }
    }

    // NEW COMMAND NAME: GoGoGo
    public void GoGoGo()
    {
        isRacing = true;
        if (agent != null) 
        {
            agent.isStopped = false; // Unfreeze!
        }
    }
}