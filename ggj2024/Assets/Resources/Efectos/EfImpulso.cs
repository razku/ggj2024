using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EfImpulso : MonoBehaviour, IEfBase
{
    public string msj { get; set; }

    void Awake(){
        msj = "Impulso!";
    }
    public void ef_start(GameObject a, GameObject b){
        Rigidbody2D phys = a.GetComponentInChildren<Rigidbody2D>();
        Vector2 physv = phys.velocity;
        Debug.Log(physv);
        phys.AddRelativeForce(transform.up * 1000.0f,ForceMode2D.Impulse);
        Debug.Log(physv);
    }
    public void ef_end(){

    }
}
