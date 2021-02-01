using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TEST : MonoBehaviour
{
    public Button button;

    // Start is called before the first frame update
    void Start()
    {
        Player.onDataReceive.AddListener(OnDataReceive);
        button.onClick.AddListener(OnClicked);
    }

    private void OnClicked()
    {
        Player.SendData(DataCommand.TEST1, null);
    }

    private void OnDataReceive(DataCommand arg0, object[] arg1)
    {
        Debug.Log(arg0.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
