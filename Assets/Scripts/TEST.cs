using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class TEST : MonoBehaviour
{
    public Button button;
    public Button button2;
    public List<TEST> ddd;

    // Start is called before the first frame update
    private void Start()
    {
        button.onClick.AddListener(OnClicked);
        button2.onClick.AddListener(() => { SendData.Sum(3, 4); });
    }

    private void OnClicked()
    {
        SendData.SenderFuction(200, true);
    }

    public static void OnDataReceive(int value, bool value2)
    {
        Debug.Log(value + " : " + value2);
    }
    //CLe4N Test

    public void OnDestroy()
    {
        ddd.Clear();
    }

    [ContextMenu("gamezaza")]
    public void gameza()
    {
        Debug.LogWarning("123");
        OnDataReceive(5, true);
    }

#if UNITY_EDITOR
    [UnityEditor.MenuItem("ABC/DEFG")]
    public static void tsss()
    {
        Debug.LogWarning("222");
    }
#endif
}
