using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lanzamiento : MonoBehaviour
{
    public Transform pivot;
    public float RangoResortera;
    public float VelocidadMaxima;

    Rigidbody2D rb;

    bool canDrag = true;
    Vector3 distancia;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Kinematic;
    }

    private void OnMouseDrag()
    {
        if (!canDrag)
        {
            return;
        }
        var posicion = Camera.main.ScreenToWorldPoint( Input.mousePosition );
        distancia = posicion - pivot.position;
        distancia.z = 0;

        if(distancia.magnitude > RangoResortera)
        {
            distancia = distancia.normalized * RangoResortera;
        }
        transform.position = distancia + pivot.position;
    }

    private void OnMouseUp()
    {
        if (!canDrag)
        {
            return;
        }
        canDrag = false;
        rb.bodyType = RigidbodyType2D.Dynamic;
        rb.velocity = -distancia.normalized * VelocidadMaxima * distancia.magnitude / RangoResortera;
    }
}
