using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float explosionForce;
    public float explosionRadius;

    private void Awake()
    {
        Explode();
    }
    private void Update()
    {
        
    }
    public void Explode()
    {
        foreach (Rigidbody rb in GetComponentsInChildren<Rigidbody>())
        {
            rb.AddExplosionForce(explosionForce, transform.position, explosionRadius);
        }
    }
}
