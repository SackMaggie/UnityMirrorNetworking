using UnityEngine;
using Mirror;
namespace Server
{
    public class NetworkManagerForMonopolyNew : NetworkManager
    {
        public GameObject gameStatePrefab;

        private GameStateData dataGameState;
        private GameObject objectGameState;

        //For Spawning Purpose

        public override void OnStartServer()
        {
            objectGameState = Instantiate(gameStatePrefab, Vector2.zero, Quaternion.identity);
            dataGameState = objectGameState.GetComponent<GameStateData>();
            /*CreateWaypoint(waypointPrefab, board, 10.7f, -10.7f);

            foreach (Transform child in board)
            {
                allBoardWayPoint.Add(child.transform);
            }*/
            base.OnStartServer();
        }
        public override void OnServerAddPlayer(NetworkConnection conn)
        {
            if (NetworkServer.connections.Count <= 4)
            {
                GameObject player = Instantiate(playerPrefab, Vector2.zero, Quaternion.identity);
                
            }
            else
            {
                conn.Disconnect();
            }
        }
    }
}
