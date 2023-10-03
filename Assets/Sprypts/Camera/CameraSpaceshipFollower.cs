using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSpaceshipFollower : MonoBehaviour
{
    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    void FixedUpdate()
    {

        if(player != null)
        {
            transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
        }
        
    }
}
