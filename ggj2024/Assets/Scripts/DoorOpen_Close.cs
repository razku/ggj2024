using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen_Close : MonoBehaviour
{
    public float rotationSpeed = 45f; // Adjust the rotation speed as needed

    void Update()
    {
        // Calculate the new rotation around the Z-axis
        float rotationAmount = rotationSpeed * Time.deltaTime;

        // Apply the new rotation to the rectangle's Transform
        transform.Rotate(Vector3.forward, rotationAmount);
    }
}
