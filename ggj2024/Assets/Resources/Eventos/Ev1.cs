using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ev1 : MonoBehaviour, IEvBase
{
    CarInputController x;
    CarInputController y;
    public float _timer = 5.0f;
    public float timer {
        get => _timer;
        set => _timer = value;
    }
    public string id{
        get => "Inverted Controls!";
    }
    public void ev_start(){
        Debug.Log("HA EMPEZADO");
        x = GameObject.Find("P1").GetComponent<CarInputController>();
        y = GameObject.Find("P2").GetComponent<CarInputController>();
        x.multx = -1;
        x.multy = -1;
        y.multx = -1;
        y.multy = -1;
    }
    public bool ev_loop(){
        return false;
    }
    public void ev_end(){
        Debug.Log("HA TERMINADO");
        x.multx = 1;
        x.multy = 1;
        y.multx = 1;
        y.multy = 1;
    }
}
