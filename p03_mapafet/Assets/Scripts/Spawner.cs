using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class Spawner : MonoBehaviour
{
    public GameObject Prefab;
    public float nCubes = 10;
    public float fillProbability = 0.9f;
    public Gradient CubeGradient;
    public float ColorSpeed = 1;
    public Transform Mama;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
            SpawnInPlane();
        //}
    }

    void SpawnInPlane()
    {
        for (int h = 0; h < nCubes; h++)
        {
            Vector3 pos = transform.position;

            pos.x += Random.Range(-20, 20);
            pos.z += Random.Range(-20, 20);

            Quaternion rot = Random.rotation;
            rot = Quaternion.Euler(0, Random.Range(0, 360), 0);

            SpawnOne(pos, rot);
        }
    }

    void SpawnMany()
    { 
        for (int i = 0; i < nCubes; i++) 
        {            
            for (int h = 0; h < nCubes; h++)
            {
                Vector3 pos = transform.position;
                
                pos.x += i;
                pos.y += h;

                if (Random.value < fillProbability)
                SpawnOne(pos);
            }
        }
    }

    void SpawnOne()
    {
        Instantiate(Prefab, transform.position, transform.rotation);
    }
    void SpawnOne(Vector3 pos)
    {
        Instantiate(Prefab, pos, transform.rotation);
    }
    void SpawnOne(Vector3 pos, Quaternion rot)
    {
        GameObject go = Instantiate(Prefab, pos, rot);
        go.transform.localScale *= Random.Range(0.1f, 1f);

        float rdm = Mathf.Sin(Time.time*ColorSpeed)/2+0.5f;
        Color color = new Color(Random.value, Random.value, Random.value);
        color = CubeGradient.Evaluate(rdm);
        //color = new Color(rdm, rdm, rdm);

        go.GetComponent<MeshRenderer>().material.color = color;
        go.transform.SetParent(Mama);
    }
}
