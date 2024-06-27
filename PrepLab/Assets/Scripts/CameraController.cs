using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.UIElements;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    private Vector3 startPos;
    private Quaternion startRot ;
    private Vector3 distToTarget;

    void Start()
    {
        startPos = transform.position;
        startRot = transform.rotation;

        distToTarget = startPos - target.position;
    }

    void LateUpdate()
    {
        Vector3 newPos = target.position + /*new Vector3(0f, 1.5f, -2f)*/ distToTarget;
        transform.position = newPos;
        transform.rotation = startRot;
    }
}
