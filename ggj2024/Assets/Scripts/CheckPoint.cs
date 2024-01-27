using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    Text lapText; // Reference to a UI Text element to display lap count
    private int lapCounts; // Lap count for each player

    void Start()
    {
        // Add this line to ensure that the trigger collider works without a Rigidbody on the player
        Rigidbody rb = gameObject.GetComponent<Rigidbody>();
        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody>();
            rb.isKinematic = true; // Ensure it doesn't affect physics
        }

        lapText = GetComponent<Text>();
        lapCounts = 0;
    }

    void OnTriggerEnter(Collider other)
    {

        Debug.Log("Trigger entered by: " + other.name);
        lapCounts++;
        lapText.text ="LAPS: " + lapCounts + "/3";
    }
}
