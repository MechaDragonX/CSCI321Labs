using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    private float moveSpeed = 5f;
    [SerializeField]
    private float rotateSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(-moveHorizontal, 0f, -moveVertical);
        Vector3 rotation = new Vector3(-moveVertical, 0f, -moveHorizontal);
        transform.Translate(movement * Time.deltaTime * moveSpeed);
        transform.Rotate(movement * Time.deltaTime * rotateSpeed);
    }
}
