using System;
using System.Collections.Generic;
using UnityEngine;
public class EfInvisible : MonoBehaviour, IEfBase
{
    public string msj { get; set; }
    [Range(1f, 10f)]
    public float time = 5.0f;
    float timer = 0.0f;
    bool invisible;
    void Awake(){
        msj = "Invisible!";
    }
    public void ef_start(GameObject a, GameObject b){
        GameObject trueobj = new GameObject("invis");
        trueobj.AddComponent<Rigidbody2D>();
        Invisibilizar x = trueobj.AddComponent<Invisibilizar>();
        x.Init(a, time);
        x.invis();
    }
    public void ef_end(){

    }
}
