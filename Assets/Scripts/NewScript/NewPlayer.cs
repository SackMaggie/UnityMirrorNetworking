using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class NewPlayer : NetworkBehaviour
{
    private static NewPlayer SelfPlayer;

    public int AssignNumber;
    private int Name, Money = 10000, aSpace = 0;
    public static void SendData(NewCommand command, byte[] data)
    {
        if (SelfPlayer == null)
        { SelfPlayer = NetworkClient.connection.identity.GetComponent<NewPlayer>(); }
        SelfPlayer.CmdSend(command, data);
    }

    [Command]
    public void CmdSend(NewCommand command, byte[] data)
    {
        switch (command)
        {
            case NewCommand.DiceRoll:
                RollDice(data);
                CheckSpace();
                break;
            case NewCommand.MovePiece:
                //SumOnServer(data);
                break;
            case NewCommand.GainMoney:

            default:
                break;
        }
    }

    [ClientRpc]
    public void RpcReceive(NewCommand command, byte[] data)
    {
        NewReceiveData.onDataReceive.Invoke(command, data);
    }

    [Server]
    public void RollDice(byte[] serverRecieveData)
    {
        PooledNetworkReader aPooledNetworkReader = NetworkReaderPool.GetReader(serverRecieveData);
        int num = aPooledNetworkReader.Read<int>();
        int turn = aPooledNetworkReader.Read<int>();
        aPooledNetworkReader.Dispose();
        if (AssignNumber != turn) { Debug.LogError("THIS IS NOT YOUR TURN"); }
        else
        {
            aSpace += num;
            float SpaceX, SpaceY;
            if (aSpace > 31) { aSpace -= 32; }
            if (aSpace <= 8) { SpaceY = -4; }
            else if (aSpace >= 16 && aSpace <= 24) { SpaceY = 4; }
            else if (aSpace == 9 || aSpace == 31) { SpaceY = -3; }
            else if (aSpace == 10 || aSpace == 30) { SpaceY = -2; }
            else if (aSpace == 11 || aSpace == 29) { SpaceY = -1; }
            else if (aSpace == 12 || aSpace == 28) { SpaceY = 0; }
            else if (aSpace == 13 || aSpace == 27) { SpaceY = 1; }
            else if (aSpace == 14 || aSpace == 26) { SpaceY = 2; }
            else if (aSpace == 15 || aSpace == 25) { SpaceY = 3; }
            else { SpaceY = -4; }
            if (aSpace == 0 && aSpace >= 24) { SpaceX = 4; }
            else if (aSpace >= 8 && aSpace <= 16) { SpaceX = -4; }
            else if (aSpace == 7 || aSpace == 17) { SpaceX = -3; }
            else if (aSpace == 6 || aSpace == 18) { SpaceX = -2; }
            else if (aSpace == 5 || aSpace == 19) { SpaceX = -1; }
            else if (aSpace == 4 || aSpace == 20) { SpaceX = 0; }
            else if (aSpace == 3 || aSpace == 21) { SpaceX = 1; }
            else if (aSpace == 2 || aSpace == 22) { SpaceX = 2; }
            else if (aSpace == 1 || aSpace == 23) { SpaceX = 3; }
            else { SpaceX = 4; }
            Transform pcs;
            if (AssignNumber == 0) { pcs = GameObject.Find("P1").transform; }
            else if (AssignNumber == 1) { pcs = GameObject.Find("P2").transform; }
            else if (AssignNumber == 2) { pcs = GameObject.Find("P3").transform; }
            else if (AssignNumber == 3) { pcs = GameObject.Find("P4").transform; }
            else { pcs = GameObject.Find("P1").transform; }
            pcs.position = new Vector3(SpaceX, SpaceY, 0);
            GameObject.Find("GameState").GetComponent<GameState>().Turn++;
        }
    }

    [Server]
    public void CheckSpace()
    {
        string SpaceName;
        if (aSpace < 10) { SpaceName = "Position0" + aSpace; }
        else { SpaceName = "Position" + aSpace; }
        GameObject CurrSpace = GameObject.Find(SpaceName);
        SpaceProperties sp = CurrSpace.GetComponent<SpaceProperties>();
        if(sp.CheckOwner() == 99)
        {
            //Create Buying Mechanic Here
        }
        else if(sp.CheckOwner() == AssignNumber)
        {
            //Create Upgrading Mechanic Here
        }
        else
        {
            if(sp.UpgradeNumber == 0)
            {
                this.Money -= sp.SpaceRent;
                NewSendData.SendMoneyValue(sp.SpaceRent, sp.CheckOwner());
            }
            else if (sp.UpgradeNumber == 1)
            {
                this.Money -= sp.HouseRent;
                NewSendData.SendMoneyValue(sp.HouseRent, sp.CheckOwner());
            }
            else if (sp.UpgradeNumber == 2)
            {
                this.Money -= sp.HotelRent;
                NewSendData.SendMoneyValue(sp.HotelRent, sp.CheckOwner());
            }
        }
    }

    [Server]
    public void MyMoney(byte[] serverRecieveData)
    {
        PooledNetworkReader aPooledNetworkReader = NetworkReaderPool.GetReader(serverRecieveData);
        int Money = aPooledNetworkReader.Read<int>();
        int Target = aPooledNetworkReader.Read<int>();
        aPooledNetworkReader.Dispose();
        if(Target == this.AssignNumber)
        {
            this.Money += Money;
        }
    }
}
