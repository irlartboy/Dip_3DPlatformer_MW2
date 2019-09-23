using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatforms : MonoBehaviour
{
    public Transform[] Waypoints;
    public float speed = 2f;
    public int CurrentPoint = 0;

    void Update()
    {
        if (transform.position.y != Waypoints[CurrentPoint].transform.position.y)
        {
            transform.position = Vector3.MoveTowards(transform.position, Waypoints[CurrentPoint].transform.position, speed * Time.deltaTime);
        }
    }
}
