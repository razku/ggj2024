using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EvExplosiones : MonoBehaviour, IEvBase
{
    CarInputController x;
    CarInputController y;
    public float _timer = 5.0f;
    public GameObject explosionobj;
    public GameObject areaobj;
    RectTransform rt;
    int ticker = 0;
    public float timer {
        get => _timer;
        set => _timer = value;
    }
    public string id{
        get => "¡¡Explosiones!!";
    }
    public void ev_start(){
        rt = areaobj.GetComponent<RectTransform>();
    }
    public bool ev_loop(){
        ticker = ticker + 1;
        if (ticker == 9) {
            ticker = 0;
            int coinflip = Random.Range(0, 2);
            if (coinflip == 0) {
                return false;
            }
            GameObject exp = Instantiate(explosionobj);
            Vector2 randomPoint = new Vector2( Random.Range(rt.rect.xMin, rt.rect.xMax),
                                               Random.Range(rt.rect.yMin, rt.rect.yMax) ) + (Vector2) rt.transform.position;
            exp.transform.position = randomPoint;
        }
        return false;
    }
    public void ev_end(){

    }
}
