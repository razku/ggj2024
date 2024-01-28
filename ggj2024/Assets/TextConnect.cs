using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextConnect : MonoBehaviour
{
    public EventosManager mgr;
    Text txt;
    void Awake()
    {
        txt = GetComponent<Text>();
    }

    void Update()
    {
        if (mgr.getEv() == null) {
            txt.text = "";
            return;
        }
        txt.text = mgr.getEv().id;
    }
}
