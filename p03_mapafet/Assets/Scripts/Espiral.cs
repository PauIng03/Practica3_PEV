using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Espiral : MonoBehaviour
{
    public GameObject prefab; 
    public int numEspirales = 5; 
    public int numObjects = 10;
    public float radius = 1f; 
    public float heightStep = 0.5f; 
    public float angleStep = 30f; 
    public GameObject[] objetosEspirales; 

    public void GenerateSpiral(GameObject objetoEspirales)
    {
        for (int i = 0; i < numObjects; i++)
        {
            float angle = i * angleStep * Mathf.Deg2Rad;
            float x = radius * Mathf.Cos(angle);
            float y = i * heightStep;
            float z = radius * Mathf.Sin(angle);

            Vector3 parentPosition = objetoEspirales.transform.position;
            Quaternion parentRotation = objetoEspirales.transform.rotation;

            Vector3 adjustedPosition = parentPosition + parentRotation * new Vector3(x, y, z);

            GameObject obj = Instantiate(prefab, adjustedPosition, Quaternion.identity);
            obj.transform.parent = objetoEspirales.transform; 

            Collider objCollider = obj.AddComponent<BoxCollider>();
            objCollider.isTrigger = true; 

            obj.AddComponent<DestroyOnCollision>(); 
        }
    }
}
