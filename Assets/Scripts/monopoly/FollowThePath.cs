using UnityEngine;
using System.Collections.Generic;

public class FollowThePath : MonoBehaviour
{
    public Transform[] waypoints;

    [SerializeField]
    private float moveSpeed = 1f;

    public int waypointIndex = 0;

    public bool isMyTurn = false;
    private void Start()
    {
        transform.localPosition = waypoints[waypointIndex].transform.localPosition;
    }

    private void Update()
    {
        if (isMyTurn == true)
        {
            Move();
        }
    }
    private void Move()
    {
        if(waypointIndex <= waypoints.Length)
        { 
            transform.localPosition = Vector2.MoveTowards(transform.localPosition, waypoints[waypointIndex].localPosition, moveSpeed);
            if (transform.localPosition == waypoints[waypointIndex].transform.localPosition)
            {
                waypointIndex += 1;
            }
        }
    }
}
