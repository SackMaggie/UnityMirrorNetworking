using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : NetworkBehaviour
{
    private static Player selfPlayer;
    public static void SendData(DataCommand command, byte[] data)
    {
        if (selfPlayer == null)
            selfPlayer = NetworkClient.connection.identity.GetComponent<Player>();

        selfPlayer.CmdSend(command, data);
    }

    [Command]
    public void CmdSend(DataCommand command, byte[] data)
    {
        switch (command)
        {
            case DataCommand.TEST1:
                RpcReceive(command, data);
                break;
            case DataCommand.TEST_SumOnServer:
                SumOnServer(data);
                break;
            default:
                break;
        }
    }

    [ClientRpc]
    public void RpcReceive(DataCommand command, byte[] data)
    {
        ReceiveData.onDataReceive.Invoke(command, data);
    }
    
    [Server]
    public void SumOnServer(byte[] serverReceivedData)
    {
        PooledNetworkReader pooledNetworkReader = NetworkReaderPool.GetReader(serverReceivedData);
        int a = pooledNetworkReader.Read<int>();
        int b = pooledNetworkReader.Read<int>();
        pooledNetworkReader.Dispose();
        PooledNetworkWriter pooledNetworkWriter = NetworkWriterPool.GetWriter();
        int result = a + b;
        pooledNetworkWriter.Write(result);
        pooledNetworkWriter.ToArray();
        byte[] dataToSendClient = pooledNetworkWriter.ToArray();
        Debug.LogWarning("Server " + result);
        RpcReceive(DataCommand.TEST_SumOnServer, dataToSendClient);
        pooledNetworkWriter.Dispose();
    }
}