using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;  // Necesario si usas Visual Effect Graph

public class RayController : MonoBehaviour
{
    public VisualEffect visualEffect;  // Cambia a ParticleSystem si usas ParticleSystem

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            visualEffect.Play();  // Cambia a visualEffect.Play() para Visual Effect Graph
            // visualEffect.Emit(1); // Descomenta esta l�nea si usas ParticleSystem
        }
    }
}
