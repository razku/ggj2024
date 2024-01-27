using UnityEngine;

public class PowerUp : MonoBehaviour
{
    GameObject P1;
    GameObject P2;
    IEfBase[] ListaItems;
    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject initiator;
        GameObject victim;
        Debug.Log("HIT!");
        Collider2D coll1 = P1.GetComponentInChildren<Collider2D>();
        //Collider2D coll2 = P2.GetComponentInChildren<Collider2D>();
        if (GetUltimateParent(other.transform) == GetUltimateParent(coll1.transform)) {
            initiator = P1;
            victim = P2;
            Debug.Log("Player 1 hit");
        }
        /*if (GetUltimateParent(other.transform) == GetUltimateParent(coll2.transform)) {
            initiator = P2;
            Debug.Log("Player 2 hit");
            }*/
        else{
            Debug.LogError("!!!!");
            return;
        }
        ListaItems[1].ef_start(initiator,victim);
    }
    // Start is called before the first frame update
    void Start()
    {
        P1 = GameObject.Find("P1");
        P2 = GameObject.Find("P2");
        Debug.Log("loaded" + P1 + P2);
        ListaItems = GameObject.Find("ListaEfectos").GetComponents<IEfBase>();
        foreach(var el in ListaItems){
            Debug.Log(el.GetType());
            Debug.Log(el.msj);
        }
    }

    // Update is called once per frame
    void Update()
    {

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
}
