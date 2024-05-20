using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantation : MonoBehaviour
{
    public GameObject lavaPrefab;
    public GameObject LavaCube; // Cambiado de LavaCube a GameObject
    public int numLavas = 100;
    public int numLavasPetits = 4;
    public float spawnRadius = 5f;
    public float upwardForce = 10f;
    public float lavaAngularSpeed = 10f;
    public float minDestructionDelay = 1f;
    public float maxDestructionDelay = 3f;
    public float spawnInterval = 1f; // Intervalo entre explosiones

    void Start()
    {
        // Llamar a SpawnExplosion repetidamente
        InvokeRepeating("SpawnExplosion", 0f, spawnInterval);
    }



    void SpawnExplosion()
    {
        for (int i = 0; i < numLavas; i++)
        {
            Vector3 spawnPosition = transform.position + Random.insideUnitSphere * spawnRadius;
            GameObject lava = Instantiate(lavaPrefab, spawnPosition, Quaternion.identity);

            lava.GetComponent<LavaCube>().Init(this);

            Rigidbody rb = lava.GetComponent<Rigidbody>();
            if (rb != null)
            {
                Vector3 upwardVelocity = transform.up * Random.Range(1f, upwardForce);
                rb.velocity = upwardVelocity + Random.onUnitSphere * lavaAngularSpeed;
                rb.useGravity = true;
            }
            LavaCube cubeScript = lava.GetComponent<LavaCube>();
            if (cubeScript != null)
            {
                cubeScript.Instantation = this; // Pasar la referencia a este script
            }
            float destructionDelay = Random.Range(minDestructionDelay, maxDestructionDelay);
            Destroy(lava, destructionDelay);
        }
    }

    public void SpawnSmallLavas(Vector3 position)
    {
        // Instanciar cubos más pequeños
        for (int i = 0; i < numLavasPetits ; i++)
        {
            Vector3 spawnPosition = position + Random.insideUnitSphere * spawnRadius / 2f; // Reducir el radio para cubos más pequeños
            GameObject lava = Instantiate(LavaCube, spawnPosition, Quaternion.identity); // Cambiado de LavaCube a GameObject
            Rigidbody rb = lava.GetComponent<Rigidbody>();
            if (rb != null)
            {
                Vector3 upwardVelocity = transform.up * Random.Range(1f, upwardForce / 2f); // Reducir la fuerza hacia arriba
                rb.velocity = upwardVelocity + Random.onUnitSphere * lavaAngularSpeed;
                rb.useGravity = true;
            }
            LavaCube cubeScript = lava.GetComponent<LavaCube>();
            if (cubeScript != null)
            {
                cubeScript.Instantation = this; // Pasar la referencia a este script
            }
            float destructionDelay = Random.Range(minDestructionDelay / 2f, maxDestructionDelay / 2f); // Reducir el tiempo de destrucción
            Destroy(lava, destructionDelay);
        }
    }
}
