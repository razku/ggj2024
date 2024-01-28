using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderControl : MonoBehaviour
{
    EventosManager mgr;
    Slider slider;
    // Start is called before the first frame update
    void Awake()
    {
        var ev = GameObject.Find("EventSystem");
        Debug.Log("ev" + ev);
        mgr =  ev.GetComponent<EventosManager>();
        Debug.Log("mgr" + mgr);
        slider = GetComponent<Slider>();
        Debug.Log("slider::" + slider);
    }

    // Update is called once per frame
    void Update()
    {
        IEvBase ev = mgr.getEv();
        if (ev == null) {
            slider.enabled = false;
            return; }
        slider.enabled = true;
        float preval = mgr.evtime;
        float val = (preval) / (ev.timer);
        slider.value =  val;
    }
}
