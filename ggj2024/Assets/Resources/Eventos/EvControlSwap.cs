using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvControlSwap : MonoBehaviour, IEvBase
{
    CarInputController x;
    CarInputController y;
    public float _timer = 5.0f;
    public float timer {
        get => _timer;
        set => _timer = value;
    }
    public string id{
        get => "Car Controls Swapped!";
    }
    public void ev_start(){
        Debug.Log("ha empezado");
        x = GameObject.Find("P1").GetComponent<CarInputController>();
        y = GameObject.Find("P2").GetComponent<CarInputController>();
        Swap(ref x.playerNumber, ref y.playerNumber);
    }
    public bool ev_loop(){
        return false;
    }
    public void ev_end(){
        Debug.Log("ha terminado");
        Swap(ref x.playerNumber, ref y.playerNumber);
    }
    public static void Swap<T>(ref T x, ref T y)
    {
        T temp = x;
        x = y;
        y = temp;
    }
}
