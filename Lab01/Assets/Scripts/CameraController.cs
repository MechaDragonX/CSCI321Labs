using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.UIElements;
using Cursor = UnityEngine.Cursor;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    private Vector3 startPos;
    private Vector3 startRot ;
    private Vector3 distToTarget;
    private Vector3 rotation = new Vector3(0, 0, 0);


    [SerializeField]
    private float lookSpeed = 10.0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;

        startPos = transform.position;
        startRot = transform.rotation.eulerAngles;

        distToTarget = startPos - target.position;
    }

    void Update()
    {
        rotation.y += Input.GetAxis("Mouse X") * lookSpeed;
        // transform.Rotate(0.0f, rotation.y, 0.0f, Space.Self);
        transform.rotation = Quaternion.Euler(startRot + rotation);
    }

    void LateUpdate()
    {
        Vector3 newPos = target.position + /*new Vector3(0f, 1.5f, -2f)*/ distToTarget;
        transform.position = newPos;
    }
}
