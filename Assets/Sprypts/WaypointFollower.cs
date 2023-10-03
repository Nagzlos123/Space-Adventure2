using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    [SerializeField] private Transform[] waypoints;
    private int curentWaypoint = 0;
    [SerializeField] private float moveSpeed = 2f;
    void Start()
    {
        transform.position = waypoints[curentWaypoint].position;
    }
    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, waypoints[curentWaypoint].position ) < 0.01f)
        {
            curentWaypoint++;
            if(curentWaypoint == waypoints.Length)
            {
                curentWaypoint = 0;
            }
            
        }
        transform.position = Vector2.MoveTowards(transform.position, waypoints[curentWaypoint].position, Time.deltaTime*moveSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.transform.SetParent(transform);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.transform.SetParent(null);
    }
}
