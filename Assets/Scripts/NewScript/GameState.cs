using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameState : MonoBehaviour
{
    public Button button;
    public int Turn;
    private void Start()
    {
        button.onClick.AddListener(RollDiceClick);
        Turn = 0;
    }
    private void RollDiceClick()
    {
        NewSendData.SendRandomNumber(Turn);
    }
    private void Update()
    {
        MonopolyNetworkManager mma = GameObject.Find("NetworkManager").GetComponent<MonopolyNetworkManager>();
        if(Turn >= mma.PNum) { Turn -= mma.PNum; }
    }
}
