using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public GameObject P1;
    public GameObject P2;
    IEfBase[] ListaItems;
    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject initiator;
        GameObject victim;
        Debug.Log("HIT!");
        Collider2D coll1 = P1.GetComponentInChildren<Collider2D>();
        Collider2D coll2 = P2.GetComponentInChildren<Collider2D>();
        Debug.Log("coll2" + coll2);
        if (GetUltimateParent(other.transform) == GetUltimateParent(coll1.transform)) {
            initiator = P1;
            victim = P2;
            Debug.Log("Player 1 hit");
        }
        else if (GetUltimateParent(other.transform) == GetUltimateParent(coll2.transform)) {
            initiator = P2;
            victim = P1;
            Debug.Log("Player 2 hit");
            }
        else{
            Debug.LogError("!!!!");
            return;
        }
        ListaItems[Random.Range(0,ListaItems.Length)].ef_start(initiator,victim);
        DisablePowerup();
    }
    // Start is called before the first frame update
    void Start()
    {
        if (!P1) {
            P1 = GameObject.Find("P1");
        }
        if (!P2){
            P2 = GameObject.Find("P2");
        }
        Debug.Log("loaded" + P1 + P2);
        ListaItems = GameObject.Find("ListaEfectos").GetComponents<IEfBase>();
        foreach(var el in ListaItems){
            Debug.Log(el.GetType());
            Debug.Log(el.msj);
        }
    }
    public float respawn_timer = 10.0f;
    float respawn_time;
    // Update is called once per frame
    void Update()
    {
        if (respawn_time <= 0.0f) {
            return;
        }
        respawn_time -= Time.deltaTime;
        if (respawn_time <= 0.0f) {
            EnablePowerup();
        }
    }
    Transform GetUltimateParent(Transform child)
    {
        Transform currentParent = child;

        while (currentParent.parent != null)
        {
            currentParent = currentParent.parent;
        }
        return currentParent;
    }

    void DisablePowerup(){
        Collider2D coll = GetComponent<BoxCollider2D>();
        Sprite spr = GetComponent<Sprite>();
        coll.enabled = false;
        GetComponent<Renderer>().enabled = false;
        respawn_time = respawn_timer;
    }

    void EnablePowerup(){
        Collider2D coll = GetComponent<BoxCollider2D>();
        Sprite spr = GetComponent<Sprite>();
        coll.enabled = true;
        GetComponent<Renderer>().enabled = true;
    }
}
