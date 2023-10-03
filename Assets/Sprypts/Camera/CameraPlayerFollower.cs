using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPlayerFollower : MonoBehaviour
{
    [SerializeField] private float cameraSpeed;
    private float currentPosX;
    private float currentPosY;
    private Vector3 velocity = Vector3.zero;

    private void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, new Vector3(currentPosX, currentPosY, transform.position.z), 
            ref velocity, cameraSpeed);


    }

    public void CameraMoveToX(Transform newLocation)
    {
        currentPosX = newLocation.position.x;
        currentPosY = transform.position.y;
    }
    
    public void CameraMoveToY(Transform newLocation)
    {
        currentPosX = transform.position.x;
        currentPosY = newLocation.position.y;
    }
    
}
