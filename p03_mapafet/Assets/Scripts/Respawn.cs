using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public float threshold;

    void FixedUpdate()
    {
        if(transform.position.y < threshold && transform.position.z <= 912f)
        {
            transform.position = new Vector3(-58.8f, 34.4f, 425.2f);
        }
        else if (transform.position.y < threshold && (transform.position.z > 912f && transform.position.z <= 1077.749f))
        {
            transform.position = new Vector3(-58.8f, 34.4f, 912f);
        }
        else if(transform.position.y < threshold && (transform.position.z > 1077.749f && transform.position.z <= 1698.944f))
        {
            transform.position = new Vector3(-58.8f, 34.4f, 1077.749f);
        }
        else if(transform.position.y < threshold && (transform.position.z > 1698.944f && transform.position.z <= 2254.48f))
        {
            transform.position = new Vector3(-58.8f, 149f, 1698.944f);
        }
        else if(transform.position.y < threshold && (transform.position.z > 2254.48f && transform.position.z <= 3149.224f))
        {
            transform.position = new Vector3(-58.8f, 170f, 2254.48f);
        }
        else if(transform.position.y < threshold && (transform.position.z > 3149.224f))
        {
            transform.position = new Vector3(-58.8f, 170f, 3149.224f);
        }
    }
}
