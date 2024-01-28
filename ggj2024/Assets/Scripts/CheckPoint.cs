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

    public Text lapText1;
    public Text lapText2;

    GameObject P1;
    GameObject P2;

    private int lapCounts1; 
    private int lapCounts2;
    private int player1LapCheckpoint;
    private int player2LapCheckpoint;

    public GameObject BlueWins;
    public GameObject RedWins;
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
                lapCounts1++;
                lapText1.text = "LAPS: " + lapCounts1 + "/3";
                RedWins.SetActive(true);
            }
            if (lapCounts1 <= 3 && player1LapCheckpoint == 3)
            {
                lapCounts1++;
                lapText1.text = "LAPS: " + lapCounts1 + "/3";
                player1LapCheckpoint = 0;
            }
            if (lapCounts1 == 4 && player1LapCheckpoint == 3)
            {
                //TODO c�digo de victoria
                RedWins.SetActive(true);
            }

            
        }
        if (GetUltimateParent(other.transform) == GetUltimateParent(coll2.transform)) {
            if (lapCounts2 == 0 && player2LapCheckpoint == 0)
            {
                lapCounts2++;
                lapText2.text = "LAPS: " + lapCounts2 + "/3";
                BlueWins.SetActive(true);
            }
            if (lapCounts2 <= 3 && player2LapCheckpoint == 3)
            {
                lapCounts2++;
                lapText2.text = "LAPS: " + lapCounts2 + "/3";
                player2LapCheckpoint = 0;
            }
            if (lapCounts2 == 4 && player2LapCheckpoint == 3)
            {
                //TODO c�digo de victoria
                BlueWins.SetActive(true);
            }
        }
    }

    public void addPlayer1LapCheckpoint() 
    { player1LapCheckpoint++; }

    public void addPlayer2LapCheckpoint() 
    {  player2LapCheckpoint++; }
}
