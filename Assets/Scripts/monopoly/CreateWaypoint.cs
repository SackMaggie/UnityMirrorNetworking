using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateWaypoint : MonoBehaviour
{
    public GameObject waypointPre;
    Vector2 BordPos;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(waypointPre, this.transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
