using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    Transform GetUltimateParent(Transform child)
    {
        Transform currentParent = child;

        while (currentParent.parent != null)
        {
            currentParent = currentParent.parent;
        }

        return currentParent;
    }

    public RedWinnerHandler RedWinnerHandler;
    public BlueWinnerHandler BlueWinnerHandler;
    public Text lapText1;
    public Text lapText2;

    GameObject P1;
    GameObject P2;

    private int lapCounts1; 
    private int lapCounts2;
    private int player1LapCheckpoint;
    private int player2LapCheckpoint;

    void Start()
    {
        P1 = GameObject.Find("P1");
        P2 = GameObject.Find("P2");
        lapCounts1 = 0;
        lapCounts2 = 0;
        player1LapCheckpoint = 0;
        player2LapCheckpoint = 0;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Collider2D coll1 = P1.GetComponentInChildren<Collider2D>();
        Collider2D coll2 = P2.GetComponentInChildren<Collider2D>();

        if (GetUltimateParent(other.transform) == GetUltimateParent(coll1.transform))
        {
            if( lapCounts1 == 0 && player1LapCheckpoint == 0)
            {
                lapText1.text = "LAPS: " + lapCounts1 + "/3";
            }
            if (lapCounts1 <= 3 && player1LapCheckpoint >= 3)
            {
                lapCounts1++;

                if (lapCounts1 == 4 && player1LapCheckpoint >= 3)
                {
                    //TODO código de victoria
                    RedWinnerHandler.RedSetup();
                }
                else 
                {
                    lapText1.text = "LAPS: " + lapCounts1 + "/3";
                    player1LapCheckpoint = 0;
                }
                
            }
            

            
        }
        if (GetUltimateParent(other.transform) == GetUltimateParent(coll2.transform)) {
            if (lapCounts2 == 0 && player2LapCheckpoint == 0)
            {
                lapText2.text = "LAPS: " + lapCounts2 + "/3";
            }
            if (lapCounts2 <= 3 && player2LapCheckpoint >= 3)
            {
                lapCounts2++;
                if (lapCounts2 == 4 && player2LapCheckpoint >= 3)
                {
                    //TODO código de victoria
                    BlueWinnerHandler.BlueSetup();
                }
                else 
                {
                    lapText2.text = "LAPS: " + lapCounts2 + "/3";
                    player2LapCheckpoint = 0;
                }
            }
        }
    }

    public void addPlayer1LapCheckpoint() 
    { player1LapCheckpoint++; }

    public void addPlayer2LapCheckpoint() 
    {  player2LapCheckpoint++; }
}
