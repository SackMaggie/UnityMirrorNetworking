using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    private static GameObject whoWinsTextShadow, whoMoveTextShadow, player1MoveText, player2MoveText;

    private static FollowThePath player1, player2, player3, player4;
    public static Dictionary<int, FollowThePath> playerDict = new Dictionary<int, FollowThePath>();
    public int calWaypoint = 1;
    public static int diceSideThrown = 0;
    public static int player1StartWaypoint = 0;
    public static int player2StartWaypoint = 0;
    public static int player3StartWaypoint = 0;
    public static int player4StartWaypoint = 0;

    public static bool gameOver = false;

    void Start()
    {
        whoWinsTextShadow = GameObject.Find("WhoWinsText");
        whoMoveTextShadow = GameObject.Find("WhoMoveText");
        player1MoveText = GameObject.Find("Player1MoveText");
        player2MoveText = GameObject.Find("Player2MoveText");

        /*player1 = GameObject.Find("Player1");
        player2 = GameObject.Find("Player2");
        player3 = GameObject.Find("Player3");
        player4 = GameObject.Find("Player4");*/

        player1.GetComponent<FollowThePath>().isMyTurn = false;
        player2.GetComponent<FollowThePath>().isMyTurn = false;
        player3.GetComponent<FollowThePath>().isMyTurn = false;
        player4.GetComponent<FollowThePath>().isMyTurn = false;

        whoWinsTextShadow.gameObject.SetActive(false);
        //whoMoveText.gameObject.SetActive(true);
        whoMoveTextShadow.GetComponent<TMPro.TextMeshProUGUI>().text = "Player 1 Move";
        //player1MoveText.gameObject.SetActive(true);
        //player2MoveText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        /*player1.GetComponent<FollowThePath>().waypointIndex = player1StartWaypoint + diceSideThrown;
        player2.GetComponent<FollowThePath>().waypointIndex = player2StartWaypoint + diceSideThrown;
        player3.GetComponent<FollowThePath>().waypointIndex = player3StartWaypoint + diceSideThrown;
        player4.GetComponent<FollowThePath>().waypointIndex = player4StartWaypoint + diceSideThrown;*/

        if (player1.GetComponent<FollowThePath>().waypointIndex > player1StartWaypoint + diceSideThrown)
        {
            player1.GetComponent<FollowThePath>().isMyTurn = false;
            //player1MoveText.gameObject.SetActive(false);
            //player2MoveText.gameObject.SetActive(true);
            whoMoveTextShadow.GetComponent<TMPro.TextMeshProUGUI>().text = "Player 2 Move";
            player1StartWaypoint = player1.GetComponent<FollowThePath>().waypointIndex - 1;
        }

        if (player2.GetComponent<FollowThePath>().waypointIndex > player2StartWaypoint + diceSideThrown)
        {
            player2.GetComponent<FollowThePath>().isMyTurn = false;
            //player2MoveText.gameObject.SetActive(false);
            //player1MoveText.gameObject.SetActive(true);
            whoMoveTextShadow.GetComponent<TMPro.TextMeshProUGUI>().text = "Player 3 Move";
            player2StartWaypoint = player2.GetComponent<FollowThePath>().waypointIndex - 1;
        }
        if (player3.GetComponent<FollowThePath>().waypointIndex > player3StartWaypoint + diceSideThrown)
        {
            player3.GetComponent<FollowThePath>().isMyTurn = false;
            //player2MoveText.gameObject.SetActive(false);
            //player1MoveText.gameObject.SetActive(true);
            whoMoveTextShadow.GetComponent<TMPro.TextMeshProUGUI>().text = "Player 4 Move";
            player3StartWaypoint = player3.GetComponent<FollowThePath>().waypointIndex - 1;
        }

        if (player4.GetComponent<FollowThePath>().waypointIndex > player4StartWaypoint + diceSideThrown)
        {
            player4.GetComponent<FollowThePath>().isMyTurn = false;
            //player2MoveText.gameObject.SetActive(false);
            //player1MoveText.gameObject.SetActive(true);
            whoMoveTextShadow.GetComponent<TMPro.TextMeshProUGUI>().text = "Player 1 Move";
            player4StartWaypoint = player4.GetComponent<FollowThePath>().waypointIndex - 1;
        }

        if (player1.GetComponent<FollowThePath>().waypointIndex + diceSideThrown >= player1.GetComponent<FollowThePath>().waypoints.Length && player1.GetComponent<FollowThePath>().isMyTurn == false)
        {
            calWaypoint = player1.GetComponent<FollowThePath>().waypoints.Length - player1.GetComponent<FollowThePath>().waypointIndex;
            print("calWaypoint =" + calWaypoint);
        }

        if (player1.GetComponent<FollowThePath>().waypointIndex ==
            player1.GetComponent<FollowThePath>().waypoints.Length)
        {
            print(calWaypoint);
            diceSideThrown -= calWaypoint + 1;
            //player1.GetComponent<FollowThePath>().moveAllowed = false;
            //player1MoveText.gameObject.SetActive(false);
            //player2MoveText.gameObject.SetActive(true);
            whoMoveTextShadow.GetComponent<TMPro.TextMeshProUGUI>().text = "Player 2 Move";
            player1StartWaypoint = 0;
            if (calWaypoint != 0)
            {
                player1.GetComponent<FollowThePath>().waypointIndex = diceSideThrown;
            }
            else if ((calWaypoint == 0))
            {
                print("bug yeah");
                player1.GetComponent<FollowThePath>().waypointIndex = diceSideThrown - 1;
            }
        }

        if (player2.GetComponent<FollowThePath>().waypointIndex ==
        player2.GetComponent<FollowThePath>().waypoints.Length)
        {
            //player2.GetComponent<FollowThePath>().moveAllowed = false;
            //player1MoveText.gameObject.SetActive(false);
            //player2MoveText.gameObject.SetActive(true);
            whoMoveTextShadow.GetComponent<TMPro.TextMeshProUGUI>().text = "Player 3 Move";
            player2StartWaypoint = player2.GetComponent<FollowThePath>().waypointIndex = 0;
        }

        if (player3.GetComponent<FollowThePath>().waypointIndex ==
        player3.GetComponent<FollowThePath>().waypoints.Length)
        {
            //player3.GetComponent<FollowThePath>().moveAllowed = false;
            //player1MoveText.gameObject.SetActive(false);
            //player2MoveText.gameObject.SetActive(true);
            whoMoveTextShadow.GetComponent<TMPro.TextMeshProUGUI>().text = "Player 4 Move";
            player3StartWaypoint = player3.GetComponent<FollowThePath>().waypointIndex = 0;
        }

        if (player4.GetComponent<FollowThePath>().waypointIndex ==
        player4.GetComponent<FollowThePath>().waypoints.Length)
        {
            //player4.GetComponent<FollowThePath>().moveAllowed = false;
            //player1MoveText.gameObject.SetActive(false);
            //player2MoveText.gameObject.SetActive(true);
            whoMoveTextShadow.GetComponent<TMPro.TextMeshProUGUI>().text = "Player 1 Move";
            player4StartWaypoint = player4.GetComponent<FollowThePath>().waypointIndex = 0;
        }
    }

    public static void MovePlayer(int playerToMove)
    {
        GetPlayer(playerToMove);
        switch (playerToMove)
        {
            case 1:
                player1.GetComponent<FollowThePath>().isMyTurn = true;
                break;
            case 2:
                player2.GetComponent<FollowThePath>().isMyTurn = true;
                break;
            case 3:
                player3.GetComponent<FollowThePath>().isMyTurn = true;
                break;
            case 4:
                player4.GetComponent<FollowThePath>().isMyTurn = true;
                break;
        }
    }

    private static FollowThePath GetPlayer(int playerUid)
    {
        FollowThePath followThePath;
        if (playerDict.TryGetValue(playerUid, out followThePath))
        {
            return followThePath;
        }
        else
        {
            return null;
        }
    }

    public bool Findplayer(int id,out int index,out bool isturn)
    {
        List<int> lists = new List<int>();
        int v = lists[id];
        index = v;
        isturn = true;
        jhhh(ref v);
        return false;
    }
   
    public void jhhh(ref int a)
    {

    }


    public static void SendRollDice()
    {
        
    }
}
