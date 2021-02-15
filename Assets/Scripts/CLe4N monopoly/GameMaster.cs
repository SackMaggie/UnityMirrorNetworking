using Mirror;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : NetworkBehaviour
{
    List<PlayerData> playerData = new List<PlayerData>();
    Dictionary<string, PlayerData> playerDic = new Dictionary<string, PlayerData>();

    [Server]
    private void Start()
    {
        
    }
    public void GetPlayerData(string UID,int playerOrder,int Level,int money,GameObject playerObject)
    {
        print(UID);
        print(playerOrder);
        print(playerObject.name);

        playerData.Add(new PlayerData("Player(" + playerOrder+")", Level, money));

        playerDic.Add(UID, playerData[playerOrder]);

        PlayerData temp = null;

        if (playerDic.TryGetValue(UID, out temp)) ;
        {
            print(temp.playerName+" Lv: "+temp.playerLevel+" Cash :"+temp.playerMoney);
        }
    }
}
