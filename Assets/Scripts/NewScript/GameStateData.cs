using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateData : MonoBehaviour
{
    public int[] Money;
    public string[] Name;
    public int[] SpaceNumber;
    public int TurnPlayer = 0;
    private int TempTurnPlayer = -99;
    public GameStateData()
    {
        for (int i = 0; i < 4; i++)
        {
            Money[i] = 25000;
            Name[i] = "Player " + (i+1);
            SpaceNumber[i] = 0;
        }
    }
    private void Update()
    {
        if(TempTurnPlayer != TurnPlayer)
        {
            Debug.Log(Name[TurnPlayer] + "'s Turn");
            TempTurnPlayer = TurnPlayer;
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
