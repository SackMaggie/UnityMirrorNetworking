using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.Events;
using System;

public class NewReceiveData : MonoBehaviour
{
    public static NewReceiveData instance;
    public static NetworkEvent onDataReceive = new NetworkEvent();

    public class NetworkEvent : UnityEvent<NewCommand, byte[]> { };

    private void Awake()
    {
        instance = this;
        onDataReceive.AddListener(OnDataReceived);
    }
    private void OnDataReceived(NewCommand dataCommand, byte[] data)
    {
        try
        {
            switch (dataCommand)
            {
                case NewCommand.DiceRoll:
                    //ReaderFuction(data);
                    break;
                case NewCommand.MovePiece:
                    //ReadSumResult(data);
                    break;
                default:
                    break;
            }
        }
        catch (Exception e)
        {
            Debug.LogError(e);
        }
    }
    
}
