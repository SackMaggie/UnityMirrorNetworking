using UnityEngine;
using Mirror;
namespace Server
{
    public class NetworkManagerForMonopolyNew : NetworkManager
    {

        public Transform FirstSpawn, SecondSpawn, ThirdSpawn, ForthSpawn;

        public GameObject diceButtonPrefab,gameStatePrefab;

        public override void OnServerAddPlayer(NetworkConnection conn)
        {
            Transform CorrectionConnect;
            if (numPlayers == 0) { CorrectionConnect = FirstSpawn; }
            else if (numPlayers == 1) { CorrectionConnect = SecondSpawn; }
            else if (numPlayers == 2) { CorrectionConnect = ThirdSpawn; }
            else { CorrectionConnect = ForthSpawn; }
            GameObject player = Instantiate(playerPrefab, CorrectionConnect.position, CorrectionConnect.rotation);
            NetworkServer.AddPlayerForConnection(conn, player);

            if (numPlayers >= 1) 
            { 
                Debug.LogError("Game Start");
                GameObject aStage = Instantiate(gameStatePrefab);
                NetworkServer.Spawn(aStage);
            }
        }
        
    }
}
