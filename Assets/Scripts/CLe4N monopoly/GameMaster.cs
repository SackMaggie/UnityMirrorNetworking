using Mirror;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

    public class GameMaster : NetworkBehaviour
    {
        List<PlayerData> playerData = new List<PlayerData>();
        string[] playerOrder;
        public Dictionary<string, PlayerData> playerDic = new Dictionary<string, PlayerData>();

        [Server]
        private void Start()
        {

        }

        public void GetPlayerData(string UID, int playerOrder, int Level, int money, GameObject playerObject)
        {
            playerData.Add(new PlayerData("Player(" + playerOrder + ")", Level, money));

            playerDic.Add(UID, playerData[playerOrder]);
        }

        public void StartGame(int maxPlayer)
        {
            string[] UIDList = playerDic.Keys.ToArray();

            playerOrder = new string[maxPlayer];

            System.Random rnd = new System.Random();
            playerOrder = UIDList.OrderBy(x => rnd.Next()).ToArray();
        }

    }

