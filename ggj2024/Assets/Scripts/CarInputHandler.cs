using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarInputController : MonoBehaviour
{
    public float tiempoEspera = 3.5f;
    float ticker;
    public int playerNumber = 1;
    public int multx = 1;
    public int multy = 1;
    //Components
    CarController carController;

    void Awake()
    {
        carController = GetComponent<CarController>();
    }

    // Update is called once per frame
    void Update()
    {
        ticker += Time.deltaTime;

        Vector2 inputVector = Vector2.zero;
         if (ticker >= tiempoEspera) {
            switch (playerNumber)
            {
                case 1:
                    inputVector.x = Input.GetAxis("Horizontal_P1") * multx;
                    inputVector.y = Input.GetAxis("Vertical_P1") * multy; ;
                    break;

                case 2:
                    inputVector.x = Input.GetAxis("Horizontal_P2") * multx;
                    inputVector.y = Input.GetAxis("Vertical_P2") * multy;
                    break;
            }
        }

        carController.SetInputVector(inputVector);
    }
}
