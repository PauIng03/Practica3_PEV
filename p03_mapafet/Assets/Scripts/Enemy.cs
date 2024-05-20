using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private HealthSystem _parentHealthSystem;

    void Start()
    {
        _parentHealthSystem = GetComponentInParent<HealthSystem>();
    }
}
