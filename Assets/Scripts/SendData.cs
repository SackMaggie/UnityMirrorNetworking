using Mirror;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SendData
{
    public static void SenderFuction(int a, bool b)
    {
        PooledNetworkWriter pooledNetworkWriter = NetworkWriterPool.GetWriter();

        pooledNetworkWriter.Write(a);
        pooledNetworkWriter.Write(b);

        Player.SendData(DataCommand.TEST1, pooledNetworkWriter.ToArray());
        pooledNetworkWriter.Dispose();
    }

    public static void Sum(int a, int b)
    {
        PooledNetworkWriter pooledNetworkWriter = NetworkWriterPool.GetWriter();

        pooledNetworkWriter.Write(a);
        pooledNetworkWriter.Write(b);

        Player.SendData(DataCommand.TEST_SumOnServer, pooledNetworkWriter.ToArray());
        pooledNetworkWriter.Dispose();
    }

    public static void diceRoll()
    {
        PooledNetworkWriter pooledNetworkWriter = NetworkWriterPool.GetWriter();

        int FirstDice = UnityEngine.Random.Range(1, 7);
        int SecondDice = UnityEngine.Random.Range(1, 7);

        pooledNetworkWriter.Write(FirstDice);
        pooledNetworkWriter.Write(SecondDice);

        NewPlayer.SendData(DataCommand.DiceRoll, pooledNetworkWriter.ToArray());
        pooledNetworkWriter.Dispose();
    }
}
