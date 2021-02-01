using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : NetworkBehaviour
{
    public static NetworkEvent onDataReceive = new NetworkEvent();
    public class NetworkEvent : UnityEvent<DataCommand, object[]> { };
    public static Player selfPlayer;

    public static void SendData(DataCommand command, object[] data)
    {
        if (selfPlayer == null)
            selfPlayer = NetworkClient.connection.identity.GetComponent<Player>();
        selfPlayer.CmdSend(command, data);
    }

    [Command]
    public void CmdSend(DataCommand command, object[] data)
    {
        RpcReceive(command, data);
    }

    [ClientRpc]
    public void RpcReceive(DataCommand command, object[] data)
    {
        onDataReceive.Invoke(command, data);
    }
}

public enum DataCommand
{
    TEST1
}