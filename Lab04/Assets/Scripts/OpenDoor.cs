using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.Animations;

public class OpenDoor : MonoBehaviour
{
    [SerializeField]
    private GameObject key;
    [SerializeField]
    private Animator animator;
    private bool isColliding;

    // Start is called before the first frame update
    void Start()
    {
        isColliding = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(isColliding)
        {
            if(Input.GetKeyDown(KeyCode.T))
            {
                Debug.Log("Pressed");
                animator.SetBool("isOpened", true);
                animator.Play("DoorOpen");
            }
        }
    }

    public void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Player"))
            if(key.gameObject.activeSelf == false)
                Debug.Log("Colliding with key");
                isColliding = true;
    }
}
