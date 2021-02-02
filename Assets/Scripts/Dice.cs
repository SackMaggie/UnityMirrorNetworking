using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{
    private Sprite[] diceSides;
    private SpriteRenderer rend;
    private int whosTurn = 1;
    private bool corountinceAllowed = true;

    private int _test;
    public int Test
    {
        get
        {
            
            return _test;
        }
        set
        {
            _test = value;
            TMPro.TextMeshProUGUI textMeshProUGUI = new TMPro.TextMeshProUGUI();
            textMeshProUGUI.text = value.ToString();
        }
    }

    
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        diceSides = Resources.LoadAll<Sprite>("DiceSide");
        rend.sprite = diceSides[5];

        Test = 5;
        _test = 5;
        textMeshProUGUI.text = _test.ToString();
    }

    private void OnMouseDown()
    {
        //if (!GameControl.gameOver && corountinceAllowed)
            StartCoroutine("RollTheDice");
    }

    private IEnumerator RollTheDice()
    {
        corountinceAllowed = false;
        int randomDiceSide = 0;
        for (int i = 0; i <= 20; i++)
        {
            randomDiceSide = Random.Range(0, 6);
            rend.sprite = diceSides[randomDiceSide];
            yield return new WaitForSeconds(0.05f);
        }

        //GameControl.diceSideThrown = randomDiceSide + 1;
        if (whosTurn == 1)
        {
            //GameControl.MovePlayer(1);            
        }
        else if(whosTurn == -1)
        {
            //GameControl.MovePlayer(2);
        }
        whosTurn *= -1;
        corountinceAllowed = true;
    }    
}
