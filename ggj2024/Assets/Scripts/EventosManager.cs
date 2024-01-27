using UnityEngine;

public class EventosManager : MonoBehaviour
{
    public float rolltime = 2.0f;
    GameObject TrueManager;
    int cur_event = -1;
    float evtime;
    float ticker;
    // Start is called before the first frame update
    void Start()
    {

        var ListaEventos = GameObject.Find("ListaEventos").GetComponents<IEvBase>();
        TrueManager = new GameObject("aaaa");
        Debug.Log("aaaaa");
        foreach(var el in ListaEventos){
            Debug.Log(el.GetType());
            TrueManager.AddComponent(el.GetType());
        }
        foreach(var el in TrueManager.GetComponents<IEvBase>()){
            Debug.Log(el.GetType());
            Debug.Log(el.id);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (cur_event != -1) {
            var ev = TrueManager.GetComponents<IEvBase>()[cur_event];
            bool end = ev.ev_loop();
            evtime -= Time.deltaTime;
            if (end || (evtime <= 0.0f)) {
                ev.ev_end();
                cur_event = -1;
            }
            return;
        }
        ticker += Time.deltaTime;
        if (ticker >= rolltime) {
            Debug.Log("Rolling");
            rollEvent();
            ticker = 0.0f;
        }
    }
    void rollEvent(){
        var evs = TrueManager.GetComponents<IEvBase>();
        int coinflip = Random.Range( 0, 2); // 0 a 1
        Debug.Log("coinflip: " + coinflip);
        if (coinflip != 0) {
            int evpick = Random.Range(0,evs.Length);
            var ev = evs[evpick];
            Debug.Log("evento #:" + evpick);
            ev.ev_start();
            cur_event = evpick;
            evtime = ev.timer;
            Debug.Log("Timer de " + evtime);
        }

    }
}
