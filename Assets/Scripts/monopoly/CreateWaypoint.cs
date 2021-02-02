using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateWaypoint : MonoBehaviour
{
    public GameObject waypointPre;
    Vector2 BordPos;
    float posX = 43;
    float posY = 43;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i <= 32; i++)
        {
            if (i < 8)
            {
                GameObject waypoint = Instantiate(waypointPre, this.transform);
                waypoint.transform.localPosition = new Vector3(posX, -posY);
                waypoint.name = "waypoint" + i.ToString();
                posX = posX - 10.75f; ;
            }
            else if (i > 8 && i <= 16)
            {
                GameObject waypoint = Instantiate(waypointPre, this.transform);
                waypoint.transform.localPosition = new Vector3(posX, -posY);
                waypoint.name = "waypoint" + i.ToString();
                posY = posY - 10.75f; ;
            }
            else if (i > 16 && i <= 24)
            {
                GameObject waypoint = Instantiate(waypointPre, this.transform);
                waypoint.transform.localPosition = new Vector3(posX, -posY);
                waypoint.name = "waypoint" + i.ToString();
                posX = posX + 10.75f; ;
            }
            else if (i > 24)
            {
                GameObject waypoint = Instantiate(waypointPre, this.transform);
                waypoint.transform.localPosition = new Vector3(posX, -posY);
                waypoint.name = "waypoint" + i.ToString();
                posY = posY + 10.75f; ;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
