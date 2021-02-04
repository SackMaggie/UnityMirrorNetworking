using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateWaypoint : MonoBehaviour
{
    public GameObject waypointPre;
    float posX = 43;
    float posY = 43;

    private void Awake()
    {
        for (int i = 0; i <= 31; i++)
        {
            GameObject waypoint = Instantiate(waypointPre, this.transform);
            waypoint.transform.localPosition = new Vector2(posX, -posY);
            waypoint.name = "waypoint (" + i.ToString() + ")";
            if (i <= 7)
            {
                posX = posX - 10.75f;
            }
            else if(i > 7 && i <= 15)
            {
                posY = posY - 10.75f;
            }
            else if(i > 15 && i <= 23)
            {
                posX = posX + 10.75f;
            }
            else if(i > 23)
            {
                posY = posY + 10.75f;
            }
        }
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
