using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class EventosManager : MonoBehaviour
{
    static float targetevtime = 2.0f;
    float evtime = targetevtime;// (segundos)
    GameObject TrueManager;
    int cur_event = -1;
    // Start is called before the first frame update
    void Start()
    {
        var ListaEventos = Resources.LoadAll<MonoScript>( "Eventos/");
        Debug.Log("aaaaaaaaaaaa");
        Debug.Log(ListaEventos.Length);
        TrueManager = new GameObject("aaaa");
        foreach(var el in ListaEventos){
            Debug.Log(el.GetClass());
            TrueManager.AddComponent(el.GetClass());
        }
        foreach(var el in TrueManager.GetComponents<IEvBase>()){
            Debug.Log(el.GetType());
            Debug.Log(el.id());
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (cur_event != -1) {
            var ev = TrueManager.GetComponents<IEvBase>()[cur_event];
            bool end = ev.ev_loop();
            if (end) {
                ev.ev_end();
                cur_event = -1;
            }
            return;
        }
        evtime -= Time.deltaTime;
        if (evtime <= 0.0f) {
            rollEvent();
            evtime = targetevtime;
        }
    }
    void rollEvent(){
        var evs = TrueManager.GetComponents<IEvBase>();
        int coinflip = Random.Range( 0, 2); // 0 a 1
        if (coinflip != 0) {
            int evpick = Random.Range(0,evs.Length);
            Debug.Log("evento #:" + evpick);
            evs[evpick].ev_start();
            cur_event = evpick;
        }

    }
}
