using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceProperties : MonoBehaviour
{
    public bool Purchaseable;
    public int InitialPurchase;
    public int SpaceRent, HouseRent, HotelRent;
    public int UpgradeNumber;
    public bool isJail, isGotojail, isRestspot;
    private int Owner;
    private void Start()
    {
        Owner = 99; //99 is for None
        UpgradeNumber = 0; //0 for blank space, 1 for House Upgrade, 2 for Hotel Upgrade
    }
    public int ChangeOwner(int Buyer)
    {
        this.Owner = Buyer;
        return InitialPurchase;
    }
    public int CheckOwner()
    {
        return Owner;
    }
}
