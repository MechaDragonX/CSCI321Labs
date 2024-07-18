using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEditor.Build.Content;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float lookSpeed;
    private Vector2 cameraRot = new Vector2(0, 0);

    [SerializeField]
    private Transform lowestObject;
    private Vector3 startPos;

    [SerializeField]
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;

        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("speed", Input.GetAxis("Vertical") * moveSpeed);
        animator.SetFloat("direction", Input.GetAxis("Horizontal"));
        
        cameraRot.y += Input.GetAxis("Mouse X") * lookSpeed;
        transform.eulerAngles = cameraRot;

        if(transform.position.y <= lowestObject.position.y - 50.0f)
            transform.position = startPos;
    }
}
