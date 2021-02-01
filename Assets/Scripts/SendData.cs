using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public static class SendData
{
    public static void SenderFuction(int a,bool b)
    {
        PooledNetworkWriter pooledNetworkWriter = NetworkWriterPool.GetWriter();

        pooledNetworkWriter.Write(a);
        pooledNetworkWriter.Write(b);

        Player.SendData(DataCommand.TEST1, pooledNetworkWriter.ToArray());
        pooledNetworkWriter.Dispose();
    }
}
