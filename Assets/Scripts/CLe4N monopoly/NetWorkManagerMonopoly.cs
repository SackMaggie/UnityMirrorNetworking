using Mirror;
using System.Collections.Generic;
using UnityEngine;

namespace Server
{
    public class NetWorkManagerMonopoly : NetworkManager
    {
        public int maxPlayer;
        public GameObject gameMasterPrefab;
        public GameObject waypointPrefab;
        public Transform board;

        [SerializeField]
        int level;
        [SerializeField]
        int money;

        GameMaster gameMaster;
        GameObject gameMasterObject;

        List<Transform> allBoardWayPoint = new List<Transform>();

        public override void OnStartServer()
        {
            gameMasterObject = Instantiate(gameMasterPrefab, Vector2.zero, Quaternion.identity);
            gameMaster = gameMasterObject.GetComponent<GameMaster>();
            CreateWaypoint(waypointPrefab, board, 10.7f, -10.7f);

            foreach (Transform child in board)
            {
                allBoardWayPoint.Add(child.transform);
            }
            base.OnStartServer();
        }
        public override void OnServerAddPlayer(NetworkConnection conn)
        {
            if (!gameMaster.playerDic.ContainsKey(conn.address))
            {
                GameObject player = Instantiate(playerPrefab, allBoardWayPoint[0].TransformPoint(Vector2.zero), Quaternion.identity);
                gameMaster.GetPlayerData(conn.address, NetworkServer.connections.Count - 1, level, money, player);
                NetworkServer.AddPlayerForConnection(conn, player);
                if (NetworkServer.connections.Count == maxPlayer)
                {
                    gameMaster.StartGame(maxPlayer);
                }
            }
            else
            {
                conn.Disconnect();
            }

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
            if (gameMasterObject != null)
            {
                Destroy(gameMasterObject);
            }
        }
    }
}
