using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class NewPlayer : NetworkBehaviour
{
    private static NewPlayer selfPlayer;
    public int AssignNember;

    private void Start()
    {
        GameObject[] ActivePlayerNumber = GameObject.FindGameObjectsWithTag("Player");
        AssignNember = ActivePlayerNumber.Length - 1;
    }
    public static void SendData(DataCommand command, byte[] data)
    {
        if (selfPlayer == null)
        {
            selfPlayer = NetworkClient.connection.identity.GetComponent<NewPlayer>();
        }

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
            case DataCommand.DiceRoll:
                DiceRoll(data);
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
    [Server]
    public void DiceRoll(byte[] serverReceivedData)
    {
        GameStateData gsd = GameObject.Find("GameState").GetComponent<GameStateData>();
        if(gsd.GetTurn() == AssignNember)
        {
            PooledNetworkReader pooledNetworkReader = NetworkReaderPool.GetReader(serverReceivedData);
            int FirstDie = pooledNetworkReader.Read<int>();
            int SecondDie = pooledNetworkReader.Read<int>();
            pooledNetworkReader.Dispose();
            int Total = FirstDie + SecondDie;
            PooledNetworkWriter pooledNetworkWriter = NetworkWriterPool.GetWriter();
            pooledNetworkWriter.Write(Total);
            pooledNetworkWriter.ToArray();
            byte[] dataToSendClient = pooledNetworkWriter.ToArray();
            Debug.Log("Your Dice Result is " + FirstDie + " + " + SecondDie + " = " + Total);
            gsd.Moving(AssignNember, Total);
            RpcReceive(DataCommand.DiceRoll, dataToSendClient);
            pooledNetworkWriter.Dispose();
            gsd.NextTurn();
        }
        else
        {
            Debug.LogError("This is NOT your turn");
        }

    }
}
