using System.Collections.Generic;
using UnityEngine;

public class TestCallPlayerData : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Dictionary<string, PlayerData> playerUID = new Dictionary<string, PlayerData>();

        PlayerData Player1 = new PlayerData("Jim", 15, 1000);
        PlayerData Player2 = new PlayerData("John", 20, 2000);
        PlayerData Player3 = new PlayerData("Jack", 01, 100);
        PlayerData Player4 = new PlayerData("June", 99, 9999);

        playerUID.Add("ASD-1245", Player1);

        PlayerData temp = null;

        if(playerUID.TryGetValue("ASD-1245", out temp))
        {
            print(temp.playerName);
            print(temp.playerLevel);
            print(temp.playerMoney);
        }
    }
}
