using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : NetworkBehaviour
{
    public static Player selfPlayer;

    public static void SendData(DataCommand command, byte[] data)
    {
        if (selfPlayer == null)
            selfPlayer = NetworkClient.connection.identity.GetComponent<Player>();

        selfPlayer.CmdSend(command, data);
    }

    [Command]
    public void CmdSend(DataCommand command, byte[] data)
    {
        RpcReceive(command, data);
    }

    [ClientRpc]
    public void RpcReceive(DataCommand command, byte[] data)
    {
        ReceiveData.onDataReceive.Invoke(command, data);
    }
}

public enum DataCommand
{
    TEST1
}