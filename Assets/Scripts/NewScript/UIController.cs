using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;
public class UIController : NetworkBehaviour
{
    public Button aDieButton;

    private void Start()
    {
        aDieButton.onClick.AddListener(WhenClicked);
    }
    private void WhenClicked()
    {
        SendData.diceRoll();
    }
}
