using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour, ISmashable
{
    public float explosionForce;
    public float explosionRadius;

    private void Awake()
    {
        explosionForce = 750;
        explosionRadius = 10;
        SmashTheGlass();
    }
    private void Update()
    {
        
    }

    public void SmashTheGlass()
    {
        foreach (Rigidbody rb in GetComponentsInChildren<Rigidbody>())
        {
            rb.AddExplosionForce(explosionForce, transform.position, explosionRadius);
        }
    }
}
