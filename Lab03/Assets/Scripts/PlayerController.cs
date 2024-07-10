using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEditor.Build.Content;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    private float moveSpeed = 5.0f;
    [SerializeField]
    private float lookSpeed = 10.0f;
    private Vector2 cameraRot = new Vector2(0, 0);

    [SerializeField]
    private Transform lowestObject;
    private Vector3 startPos;

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
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        transform.Translate(movement * Time.deltaTime * moveSpeed);
        
        cameraRot.y += Input.GetAxis("Mouse X") * lookSpeed;
        transform.eulerAngles = cameraRot;

        if(transform.position.y <= lowestObject.position.y - 50.0f)
            transform.position = startPos;
    }
}
