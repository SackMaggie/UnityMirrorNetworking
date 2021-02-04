using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceText : MonoBehaviour
{
    //private Sprite[] diceSides;
    //private SpriteRenderer rend;
    public TMPro.TextMeshProUGUI diceSides;

    private const int limitePlayer = 2; 
    private int whosTurn = 1;
    private bool corountinceAllowed = true;

    
    void Start()
    {
        //rend = GetComponent<SpriteRenderer>();
        //diceSides = Resources.LoadAll<Sprite>("DiceSide/");
        //rend.sprite = diceSides[5];
        diceSides.text = "Thrown";
    }

    private void OnMouseDown()
    {
        if (!GameControl.gameOver && corountinceAllowed)
            StartCoroutine("RollTheDice");
    }

    private IEnumerator RollTheDice()
    {
        corountinceAllowed = false;
        int randomDiceSide = 0;
        for (int i = 0; i <= 20; i++)
        {
            randomDiceSide = Random.Range(1, 7);
            diceSides.text = randomDiceSide.ToString();
            //rend.sprite = diceSides[randomDiceSide];
            yield return new WaitForSeconds(0.05f);
        }

        GameControl.diceSideThrown = randomDiceSide;

        if(whosTurn >= limitePlayer+1)
        {
            whosTurn = 1;
        }

        switch (whosTurn)
        {
            case 1:
                GameControl.MovePlayer(1);
                break;
            case 2:
                GameControl.MovePlayer(2);
                break;
        }
        whosTurn++;
        corountinceAllowed = true;
    }    
}
