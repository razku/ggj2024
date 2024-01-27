using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ev1 : MonoBehaviour, IEvBase
{
    public string id(){
        return "Controles Invertidos";
    }
    public void ev_start(){
        Debug.Log("HA EMPEZADO");
    }
    public bool ev_loop(){
        return true;
    }
    public void ev_end(){
        Debug.Log("HA TERMINADO");
    }
}
