using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class MonopolyNetworkManager : NetworkManager
{
    public Transform aStart;
    public int PNum = 0;
    public bool GameStart = false;
    public override void OnServerAddPlayer(NetworkConnection conn)
    {
        GameObject player = Instantiate(playerPrefab, aStart.position, aStart.rotation);
        player.GetComponent<NewPlayer>().AssignNumber = numPlayers;
        NetworkServer.AddPlayerForConnection(conn, player);
        PNum = numPlayers;
        if (numPlayers >= 2)
        {
            Debug.Log("GameStart");
        }
    }
}
