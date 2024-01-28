using System;
using System.Collections.Generic;
using UnityEngine;
public class Invisibilizar : MonoBehaviour{
    public float timer= 0.0f;
    public float time;
    public GameObject obj;
    public SpriteRenderer spr;
    public bool invisible;
    public void Init(GameObject a, float time){
        this.time = time;
        this.obj = a;
        Debug.Log("Init!" + timer + a);
    }
    void Start(){}
    void Update(){
        if (invisible) {
            timer += Time.deltaTime;
            if (timer >= time) {
                ef_end();
                timer = 0f;
                invisible = false;
            }
        }
    }
    public void invis(){
        SpriteRenderer[] spr_list = obj.GetComponentsInChildren<SpriteRenderer>();
        foreach(SpriteRenderer el in spr_list) {
            if (String.Equals(el.sprite.name,"coche1")
                ||String.Equals(el.sprite.name,"car2")) {
                Debug.Log("found sprite!" + el.sprite.name + el);
                spr = el;
                Color newColor = spr.color;
                newColor.a = 0f;
                newColor.r = 1f;
                spr.color = newColor;
                invisible = true;
            }
        }
    }
    void ef_end(){
        Color newColor = spr.color;
        newColor.a = 1f;
        spr.color = newColor;
        Destroy(gameObject);
    }
}
