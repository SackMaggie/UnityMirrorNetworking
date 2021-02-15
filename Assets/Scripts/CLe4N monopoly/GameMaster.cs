using Mirror;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : NetworkBehaviour
{
    List<PlayerData> player = new List<PlayerData>();
    Dictionary<string, PlayerData> playerDic = new Dictionary<string, PlayerData>();

    [Server]
    private void Start()
    {
        
    }
    public void GetPlayerData(string UID,int playerOrder,GameObject playerObject)
    {
        print(UID);
        print(playerOrder);
        print(playerObject.name);

        player.Add(new PlayerData("Player(" + playerOrder+")", 10, 1000));

        playerDic.Add(UID, player[playerOrder]);

        PlayerData temp = null;

        if (playerDic.TryGetValue(UID, out temp)) ;
        {
            print(temp.playerName+" Lv: "+temp.playerLevel+" Cash :"+temp.playerMoney);
        }
    }
}
