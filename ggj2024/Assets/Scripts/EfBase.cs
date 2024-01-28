using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEfBase
{
    string msj { get; set; }
    void ef_start(GameObject activator, GameObject victim);
    void ef_end();
}
