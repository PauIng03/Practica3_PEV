using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Botiquin : MonoBehaviour
{
    public float healingAmount = 30f;
    public Espiral Espiral;
        public GameObject[] objetosEspirales; 


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            HealthSystem healthSystem = other.GetComponent<HealthSystem>();
            if (healthSystem != null)
            {
                if (healthSystem.HealthPoints < healthSystem.MaxHealthPoints)
                {
                    float currentHealth = healthSystem.HealthPoints;
                    float maxHealth = healthSystem.MaxHealthPoints;
                    float newHealth = Mathf.Min(currentHealth + healingAmount, maxHealth);
                    healthSystem.Heal(newHealth - currentHealth);
                    foreach (GameObject objetoEspirales in objetosEspirales)
                    {
                        Espiral.GenerateSpiral(objetoEspirales);
                    }
                    Invoke("DestroySelf", 0.0f); 
                }
            }
        }
    }

    private void DestroySelf()
    {
        Destroy(gameObject); 
    }
}
