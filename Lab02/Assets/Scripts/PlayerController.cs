using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.Build.Content;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    // public Vector3 startPos;
    // private Vector3 startRot = new Vector3(0.0f, 179.870636f, 0.0f);

    [SerializeField]
    private float moveSpeed = 5.0f;
    // [SerializeField]
    // private float rotateSpeed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        // startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        // Vector3 rotation = new Vector3(-moveVertical, 0f, -moveHorizontal);
        transform.Translate(movement * Time.deltaTime * moveSpeed);
        // transform.Rotate(movement * Time.deltaTime * rotateSpeed);

        // if(transform.position.y <= lowestObject.position.y - 50.0f)
        // {
        //     transform.position = startPos;
        //     // transform.rotation = Quaternion.Euler(startRot);
        // }
    }
}
