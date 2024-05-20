using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CollisionDetector : MonoBehaviour
{
    private Rigidbody rb;
    private bool gravedadActivada = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("player")) 
        {
            rb.useGravity = !gravedadActivada; 
            gravedadActivada = !gravedadActivada; 
        }
    }
}