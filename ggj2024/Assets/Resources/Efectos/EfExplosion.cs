using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EfExplosion : MonoBehaviour, IEfBase
{
    public string _msj;
    public GameObject explosionobj;
    public string msj{ get => _msj;set => _msj = value; }
    void Awake(){
        msj = "Explosion!";
    }
    public void ef_start(GameObject activator, GameObject a)
    {
        GameObject exp = Instantiate(explosionobj);
        exp.transform.position = activator.transform.position;
    }

    public void ef_end()
    {
        throw new System.NotImplementedException();
    }
}
