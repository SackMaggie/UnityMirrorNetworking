using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;

public class UIControl : MonoBehaviour
{
    public Button diceButtonPrefab;
    [Server]
    void Start()
    {
        Instantiate(diceButtonPrefab,this.transform);
    }
}
