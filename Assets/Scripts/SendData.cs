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
}
