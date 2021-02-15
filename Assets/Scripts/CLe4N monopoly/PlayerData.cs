using System.Collections.Generic;
using UnityEngine;
public class PlayerData
{
    public string playerName;
    public int playerLevel;
    public int playerMoney;

    public PlayerData (string name , int level , int money)
    {
        playerName = name;
        playerLevel = level;
        playerMoney = money;
    }
}
