using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantDeath : MonoBehaviour, ITakeDamage
{
    public float healthPoints = 100;
    public void TakeDamage(float amount)
    {
        healthPoints = 0;
        Destroy(gameObject);
    }
}
