using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStateData : MonoBehaviour
{
    public int[] Money;
    public string[] Name;
    public int[] SpaceNumber;
    public int TurnPlayer = 0;
    private int TempTurnPlayer = -99;
    public Text[] statusText;

    private void Update()
    {
        if(TempTurnPlayer != TurnPlayer)
        {
            Debug.Log(Name[TurnPlayer] + "'s Turn");
            TempTurnPlayer = TurnPlayer;
        }
        for (int i = 0; i < statusText.Length; i++)
        {
            statusText[i].text = Name[i] + " :\n" + Money[i];
        }
    }
    public int GetTurn()
    {
        return TurnPlayer;
    }
    public void NextTurn()
    {
        TurnPlayer++;
        if(TurnPlayer >= 4) { TurnPlayer -= 4; }
    }
    public void Moving(int AsNum , int Roll)
    {
        SpaceNumber[AsNum] += Roll;
    }
}
