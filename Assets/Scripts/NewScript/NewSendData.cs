using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public static class NewSendData
{
    public static void SendIntFunction(int a)
    {
        PooledNetworkWriter pooledNetworkWriter = NetworkWriterPool.GetWriter();

        pooledNetworkWriter.Write(a);

        //Player.SendData(DataCommand.TEST1, pooledNetworkWriter.ToArray());
        pooledNetworkWriter.Dispose();
    }
    public static void SendRandomNumber(int Turn)
    {
        int x = Random.Range(1, 7);
        PooledNetworkWriter pooledNetworkWriter = NetworkWriterPool.GetWriter();
        pooledNetworkWriter.Write(x);
        pooledNetworkWriter.Write(Turn);
        NewPlayer.SendData(NewCommand.DiceRoll, pooledNetworkWriter.ToArray());
        pooledNetworkWriter.Dispose();

    }
    public static void SendMoneyValue(int Money, int Target)
    {
        PooledNetworkWriter pooledNetworkWriter = NetworkWriterPool.GetWriter();
        pooledNetworkWriter.Write(Money);
        pooledNetworkWriter.Write(Target);
        NewPlayer.SendData(NewCommand.GainMoney, pooledNetworkWriter.ToArray());
        pooledNetworkWriter.Dispose();
    }
}
