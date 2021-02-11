using Mirror;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Server
{
    public class NetWorkManagerMonopoly : NetworkManager
    {
        public GameObject gameMasterPrefab;
        public GameObject waypointPrefab;
        public Transform board;

        GameObject gameMaster;
        List<Transform> allBoardWayPoint = new List<Transform>();

        [Server]
        public override void OnServerAddPlayer(NetworkConnection conn)
        {
            GameObject player = Instantiate(playerPrefab, allBoardWayPoint[0].TransformPoint(Vector2.zero),Quaternion.identity);
            //print(player.GetComponent<NetworkIdentity>().netId);
            NetworkServer.AddPlayerForConnection(conn, player);
        }

        public override void OnStartServer()
        {
            gameMaster = Instantiate(gameMasterPrefab, Vector2.zero, Quaternion.identity);
            CreateWaypoint(waypointPrefab, board, 10.7f, -10.7f);

            foreach (Transform child in board)
            {
                allBoardWayPoint.Add(child.transform);
            }
            base.OnStartServer();
        }

        private void CreateWaypoint(GameObject waypointPre, Transform localPos, float posX, float posY)
        {
            for (int i = 0; i <= 31; i++)
            {
                GameObject waypoint = Instantiate(waypointPre, localPos.transform);
                waypoint.transform.localPosition = new Vector2(posX, posY);
                waypoint.name = "waypoint (" + i.ToString() + ")";
                if (i <= 7)
                {
                    posX = posX - 2.675f;
                }
                else if (i > 7 && i <= 15)
                {
                    posY = posY + 2.675f;
                }
                else if (i > 15 && i <= 23)
                {
                    posX = posX + 2.675f;
                }
                else if (i > 23)
                {
                    posY = posY - 2.675f;
                }
            }
        }
        public override void OnStopServer()
        {
            if(gameMaster != null)
            {
                Destroy(gameMaster);
            }
        }
    }
}
