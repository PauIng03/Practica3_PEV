using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaCube : MonoBehaviour
{
    public Instantation Instantation; // Cambiado de private a public

    private void Start()
    {
        // Obtener una referencia al componente Instantation en el objeto padre
        //Instantation = GetComponentInParent<GameObject>();
    }
    public void Init(Instantation inst)
    {
        Instantation = inst;
    }

    private void OnDestroy()
    {
        if (Instantation != null)
        {
            Instantation.SpawnSmallLavas(transform.position); // Llamar a SpawnSmallLavas del script Instantation
        }
    }

}
