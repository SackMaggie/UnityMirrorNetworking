using UnityEngine;
using System.Collections.Generic;

public class FollowThePath : MonoBehaviour
{
    public Transform[] waypoints;

    [SerializeField]
    private float moveSpeed = 1f;

    [HideInInspector]
    public int waypointIndex = 0;

    public bool moveAllowed = false;
    private void Start()
    {
<<<<<<< HEAD
       

        Transform WayP = board.GetComponentInChildren<Transform>();
        foreach(Transform child in board)
        {
            AllBoardWaypoint.Add(child.transform);
        }
        waypoints = AllBoardWaypoint.ToArray();
        transform.localPosition = waypoints[waypointIndex].transform.localPosition;

=======
        transform.position = waypoints[waypointIndex].transform.position;
>>>>>>> 76411a1c3045648e96968179bf676f0b26124b31
    }

    private void Update()
    {
        if (moveAllowed == true)
        {
            Move();
        }
    }
    private void Move()
    {
        if(waypointIndex <= waypoints.Length - 1)
        {
            
            transform.position = Vector2.MoveTowards(transform.position, waypoints[waypointIndex].position, moveSpeed * Time.deltaTime);
            print(waypointIndex);
            if (transform.position == waypoints[waypointIndex].transform.position)
            {
                print("555");
                waypointIndex += 1;
            }
        }
    }
}
