using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowThePath : MonoBehaviour
{
    public Transform[] waypoints;

    [SerializeField]
    private float movespeed = 1f;

    [HideInInspector]
    public int waypointIndex = 0;

    public bool moveAllowed = false;
    void Start()
    {
        transform.position = waypoints[waypointIndex].transform.position;
    }


    void Update()
    {

        if (moveAllowed)
            Move();
    }
    private void Move()
    {
        if(waypointIndex <= waypoints.Length - 1)
        {
            transform.position = Vector2.MoveTowards(transform.position, waypoints[waypointIndex].transform.position, movespeed * Time.deltaTime);
        }
        if(transform.position == waypoints[waypointIndex].transform.position)
        {
            waypointIndex += 1;
        }
    }
}
