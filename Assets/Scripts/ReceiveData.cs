using Mirror;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ReceiveData : MonoBehaviour
{
    public static ReceiveData instance;
    public static NetworkEvent onDataReceive = new NetworkEvent();
    public class NetworkEvent : UnityEvent<DataCommand, byte[]> { };

    public void Awake()
    {
        instance = this;
        onDataReceive.AddListener(OnDataReceived);
    }

    private void OnDataReceived(DataCommand dataCommand, byte[] data)
    {
        try
        {
            switch (dataCommand)
            {
                case DataCommand.TEST1:
                    ReaderFuction(data);
                    break;
                case DataCommand.TEST_SumOnServer:
                    ReadSumResult(data);
                    break;
                case DataCommand.DiceRoll:
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

    public void ReaderFuction(byte[] data)
    {
        PooledNetworkReader pooledNetworkReader = NetworkReaderPool.GetReader(data);
        int value = pooledNetworkReader.Read<int>();
        bool value2 = pooledNetworkReader.Read<bool>();
        Debug.LogWarning("ABCD " + value);

        TEST.OnDataReceive(value, value2);

        pooledNetworkReader.Dispose();
    }

    public void ReadSumResult(byte[] data)
    {
        PooledNetworkReader pooledNetworkReader = NetworkReaderPool.GetReader(data);
        int value = pooledNetworkReader.Read<int>();

        Debug.LogWarning("Sum " + value);

        pooledNetworkReader.Dispose();
    }
}
