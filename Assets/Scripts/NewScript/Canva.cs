using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Canva : MonoBehaviour
{
    public Button aDieButton;

    private void Start()
    {
        aDieButton.onClick.AddListener(OnClicked);
    }
    private void OnClicked()
    {
        SendData.diceRoll();
    }
}
