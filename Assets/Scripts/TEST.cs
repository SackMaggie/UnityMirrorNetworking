using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TEST : MonoBehaviour
{
    public Button button;

    // Start is called before the first frame update
    private void Start()
    {
        button.onClick.AddListener(OnClicked);
    }

    private void OnClicked()
    {
        SendData.SenderFuction(200, true);
    }

    public static void OnDataReceive(int value, bool value2)
    {
        Debug.Log(value + " : " + value2);
    }
}
