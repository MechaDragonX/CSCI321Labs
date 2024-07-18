using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patroller : MonoBehaviour
{
    [SerializeField]
    public Transform[] points;
    [SerializeField]
    private NavMeshAgent agent;
    private int destination = 0;
    // 0 = forward
    // 1 = backward
    int direction = 0;

    // Start is called before the first frame update
    void Start()
    {
        // Prevents slowing down as it approaches point
        agent.autoBraking = false;

        MoveToPoint();
    }

    // Update is called once per frame
    void Update()
    {
        if(!agent.pathPending && agent.remainingDistance < 0.5f)
            MoveToPoint();
    }

    void MoveToPoint()
    {
        if(points.Length == 0)
            return;
        
        // Go to current dest
        agent.destination = points[destination].position;
        if(direction == 0)
        {
            // Set next point to next val in array
            if(destination != points.Length - 1)
                destination++;
            // If at end, reverse
            else
            {
                direction = 1;

                destination--;
            }
        }
        else
        {
            // Set next point to prev val in array
            if(destination != 0)
                destination--;
            // If at start, reverse
            else
            {
                direction = 0;

                destination++;
            }
        }
    }
}
