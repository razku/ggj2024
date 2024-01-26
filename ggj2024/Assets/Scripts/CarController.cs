using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    [Header("Car settings")]
    public float accelerationFactor = 30.0f;
    public float turnFactor = 3.5f;

    //Local Variables
    float accelerationInput = 0;
    float steeringInput = 0;
    float rotationAngle = 0;

    //Components
    Rigidbody2D carRigidbody2D;

    // Awake is called when the script instance is being loaded
    void Awake() 
    {
        carRigidbody2D = GetComponent<Rigidbody2D>();
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ApplyEngineForce()
    {
        //Create force for the engine
        Vector2 engineForceVector = transform.up * accelerationInput * accelerationFactor;

        //Apply force and pushes the car forward
        carRigidbody2D.AddForce(engineForceVector, ForceMode2D.Force);
    }

    void ApplySteering() 
    {
        //Update the rotation angle based on input
        rotationAngle -= steeringInput * turnFactor;

        //Apply steering by rotating the car object
        carRigidbody2D.MoveRotation(rotationAngle);
    }

    public void SetInputVector(Vector2 inputVector) 
    {
        steeringInput = inputVector.x;
        accelerationInput = inputVector.y;
    }
}
