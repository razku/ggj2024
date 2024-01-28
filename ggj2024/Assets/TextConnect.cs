using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextConnect : MonoBehaviour
{
    EventosManager mgr;
    Text txt;
    void Awake()
    {
        mgr = GameObject.Find("EventSystem").GetComponent<EventosManager>();
        txt = GetComponent<Text>();
    }

    void Update()
    {
        if (mgr.getEv() == null) {
            return;
        }
        txt.text = mgr.getEv().id;
    }
}
