using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraDeVida : MonoBehaviour
{
    public HealthSystem healthSystem;
    public Image barraDeVida;
    private float vidaMaxima;

    void Start()
    {
        healthSystem = GetComponent<HealthSystem>();

        vidaMaxima = healthSystem.MaxHealthPoints;
    }

    void Update()
    {
        float vidaActual = healthSystem.HealthPoints;

        barraDeVida.fillAmount = vidaActual / vidaMaxima;

    }
}
