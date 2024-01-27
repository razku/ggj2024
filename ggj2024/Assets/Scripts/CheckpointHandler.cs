using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointHandler : MonoBehaviour
{
    CheckPoint checkpoint;
    GameObject P1;
    GameObject P2;

    Transform GetUltimateParent(Transform child)
    {
        Transform currentParent = child;

        while (currentParent.parent != null)
        {
            currentParent = currentParent.parent;
        }

        return currentParent;
    }

    void Awake() 
    {
        checkpoint = GetComponentInParent<CheckPoint>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Collider2D coll1 = P1.GetComponentInChildren<Collider2D>();
        Collider2D coll2 = P2.GetComponentInChildren<Collider2D>();

        if (GetUltimateParent(other.transform) == GetUltimateParent(coll1.transform))
        {
            checkpoint.addPlayer1LapCheckpoint();
        }
        if (GetUltimateParent(other.transform) == GetUltimateParent(coll2.transform))
        {
            checkpoint.addPlayer2LapCheckpoint();
        }
    }

    void Start()
    {
      P1 = GameObject.Find("P1");
      P2 = GameObject.Find("P2");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
