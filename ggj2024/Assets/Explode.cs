using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }
    // https://stackoverflow.com/a/66453571
    void AddExplosionForce(Rigidbody2D rb, float explosionForce, Vector2 explosionPosition, float explosionRadius, float upwardsModifier = 0.0F, ForceMode2D mode = ForceMode2D.Impulse) {
        var explosionDir = rb.position - explosionPosition;
        var explosionDistance = explosionDir.magnitude;

        // Normalize without computing magnitude again
        if (upwardsModifier == 0)
            explosionDir /= explosionDistance;
        else {
            // From Rigidbody.AddExplosionForce doc:
            // If you pass a non-zero value for the upwardsModifier parameter, the direction
            // will be modified by subtracting that value from the Y component of the centre point.
            explosionDir.y += upwardsModifier;
            explosionDir.Normalize();
        }
        float falloff = 1 - (explosionDistance / explosionRadius);
        rb.AddForce(explosionDistance * explosionDir,mode);
        //rb.AddForce(Mathf.Lerp(0, explosionForce, (1 - explosionDistance)) * explosionDir, mode);
    }
    // Update is called once per frame
    int ticker = 30;
    public float range = 20.0f;
    public float strength = 70.0f;
    void Update()
    {
        ticker = ticker + 1 % 35;
        if (ticker < 34) {
            return;
        }
        Rigidbody2D point = gameObject.GetComponent<Rigidbody2D>();
        var x = Physics2D.OverlapCircleAll(gameObject.transform.position, range);
        foreach (var val in x)
        {
            Rigidbody2D target = val.gameObject.GetComponentInParent<Rigidbody2D>();
            if (target)
            {
                AddExplosionForce(target, strength, point.position, range);
            }
        }

    }
}
