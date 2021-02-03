using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class test2 : MonoBehaviour
{
    [SerializeField] public string PlayerName;
    //public Text m_currentGold;
    //public Text m_lvlLand;
    [SerializeField] private int StartGold = 10000;
    [SerializeField] private int PaymoneyPerRound = 1000; // salary
    [SerializeField] private int currentGold;

    public string Owner_Current;
    public string landName;
    private int CurentlandNumber = 0;

    private int landPrice = 100 ; // ราคาที่ดิน
    private int housePrice ; // ราคาบ้าน
    private int totalPrice; // ราคาทีรวมทั้งอสังหา
    private int lvlPrice;// ระดับของที่ดิน
    private bool Buyhouse = false;

    private const int Max_lvlPrice = 3;
    private const int All_ROUND = 33;


    private bool All_WalkRound = false;

    void Start()
    {
        currentGold = StartGold;
    }

    void Update()
    {
        if (lvlPrice >= Max_lvlPrice)
        {
            lvlPrice = Max_lvlPrice;
        }
        Currentlvlland(); // เลเวลที่ดิน


        totalPrice = landPrice + housePrice;
        

        if (CurentlandNumber >= All_ROUND)
        {
            All_WalkRound = true;
            CurentlandNumber = 0;        
        }

        if (CurentlandNumber == 0 && All_WalkRound == true)
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                currentGold += PaymoneyPerRound;  // check when u walk 1 round give u money
                All_WalkRound = false;
            }
        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            currentGold += 100;
        }

        if(Buyhouse == true)
        {
            lvlPrice += 1;
            currentGold -= totalPrice * 2;
            Debug.Log(totalPrice * 2);
            Buyhouse = false;
        }

        if(Input.GetKeyDown(KeyCode.Y))
        {
            Buyhouse = true;
        }

        if(Input.GetKeyDown(KeyCode.N))
        {
            Buyhouse = false;
        }
        Debug.Log(currentGold);
        //m_currentGold.text = currentGold.ToString();

    }

    public void Currentlvlland()
    {
        switch (lvlPrice)
        {
            case 0:
                housePrice = 0;
                Debug.Log("1oh_" + housePrice);
                break;
            case 1:
                housePrice = landPrice / 4;
                Debug.Log("2oh_" + housePrice);
                break;
            case 2:
                housePrice = (landPrice / 4) * 2;
                Debug.Log("3oh_" + housePrice);
                break;
            case 3:
                housePrice = ((landPrice / 4) * 2) * 2;
                Debug.Log("4ho_" + housePrice);
                Buyhouse = false;
                break;
        }
    }
    
}


