using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RNGDice : MonoBehaviour
{
    public Button btt;
    public TMPro.TextMeshProUGUI diceText;

    private void Start()
    {
        btt.onClick.AddListener(randomNum);
    }

    private void randomNum()
    {
        diceText.text = Random.Range(1, 7).ToString();
    }
}
