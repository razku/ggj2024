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

    void Start()
    {
        P1 = GameObject.Find("P1");
        P2 = GameObject.Find("P2");
        lapCounts1 = 0;
        lapCounts2 = 0;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Collider2D coll1 = P1.GetComponentInChildren<Collider2D>();
        Collider2D coll2 = P2.GetComponentInChildren<Collider2D>();

        if (GetUltimateParent(other.transform) == GetUltimateParent(coll1.transform))
        {
            lapCounts1++;
            lapText1.text = "LAPS: " + lapCounts1 + "/3";
        }
        if (GetUltimateParent(other.transform) == GetUltimateParent(coll2.transform)) {
            lapCounts2++;
            lapText2.text = "LAPS: " + lapCounts2 + "/3";
        }
    }
}
