using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Animations;
using UnityEngine.UIElements;

public class Patroller : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    [SerializeField]
    public Transform[] points;
    [SerializeField]
    private NavMeshAgent agent;
    private int destination = 0;

    // 0 = forward
    // 1 = backward
    int direction = 0;

    private Ray outward;
    private RaycastHit target;
    [SerializeField]
    private float targetRange = 2.0f;
    private bool following = false;
    [SerializeField]
    private Transform playerTransform;

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
        if(transform.eulerAngles.y == 180.0f)
            animator.SetInteger("yRot", 0);
        else if(transform.eulerAngles.y < 180.0f)
            animator.SetInteger("yRot", -1);
        else if(transform.eulerAngles.y > 180.0f)
            animator.SetInteger("yRot", 1);

        outward = new Ray(transform.position, Vector3.forward);
        Debug.DrawRay(outward.origin, outward.direction * targetRange, Color.cyan);
        CheckRayCastHit();

        if(!following)
        {
            if(!agent.pathPending && agent.remainingDistance < 0.5f)
                MoveToPoint();
        }
        else
            agent.destination = playerTransform.position;
    }

    void CheckRayCastHit()
    {
        if(Physics.Raycast(outward, out target))
        {
            if(target.collider.CompareTag("Player") && target.distance <= targetRange)
            {
                print("COMIN' FOR YA!");
                following = true;
            }
        }
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
