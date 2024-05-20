using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class persona : MonoBehaviour
{
    private databaseValues dB;
    public string PersonajeName;
    public string PersonajePersonalidad;
    public string PersonajeRopa;
    [Space(10)]
    public string[] Dialogos;
    public int DialogoValue;
    public int Fase = 0;

    private void Awake()
    {
        dB = GameObject.Find("DATABASE").GetComponent<databaseValues>();
        PersonajeName = dB.nombresPersonajes[Random.Range(0, dB.nombresPersonajes.Length)];
    }
    void Start()
    {
        
    }

}
