using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointAssign : MonoBehaviour
{
    public Transform board;
    public FollowThePath[] Players;
    [SerializeField]
    List<Transform> AllBoardWaypoint = new List<Transform>();

    void Start()
    {
        Transform WayP = board.GetComponentInChildren<Transform>();
        foreach (Transform child in board)
        {
            AllBoardWaypoint.Add(child.transform);
        }

        for(int i = 0; i < Players.Length; i++)
        {
            Players[i].waypoints = AllBoardWaypoint.ToArray();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
