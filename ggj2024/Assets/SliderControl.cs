using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderControl : MonoBehaviour
{
    public EventosManager mgr;
    Slider slider;
    Vector2 initialpos;
    RectTransform sliderRectTransform;
    // Start is called before the first frame update
    void Awake()
    {
        slider = GetComponent<Slider>();
        sliderRectTransform = slider.GetComponent<RectTransform>();
        initialpos = sliderRectTransform.anchoredPosition;
    }

    // Update is called once per frame
    void Update()
    {
        IEvBase ev = mgr.getEv();
        if (ev == null) {
            sliderRectTransform.anchoredPosition = new Vector2(-1000f, -1000f);
            slider.enabled = false;
            return; }
        slider.enabled = true;
        sliderRectTransform.anchoredPosition = initialpos;
        float preval = mgr.evtime;
        float val = (preval) / (ev.timer);
        slider.value =  val;
    }
}
