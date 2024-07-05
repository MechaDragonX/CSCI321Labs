using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField]
    private Transform lowestObject;
    [SerializeField]
    private Transform player;
    private Vector3 playerStartPos;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(
            transform.position.x,
            lowestObject.position.y - 50.0f,
            transform.position.z
        );
        playerStartPos = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
            player.transform.position = playerStartPos;
    }
}
