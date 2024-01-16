using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruible : MonoBehaviour
{
    public float resistencia;
    public GameObject explosionPrefab;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.relativeVelocity.magnitude > resistencia)
        {
            if(explosionPrefab != null)
            {
                var gameobject = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
                Destroy(gameobject, 3);
            }
            Destroy(gameObject, 0.1f);
        }
        else
        {
            resistencia -= collision.relativeVelocity.magnitude;
        }
    }
    
}
