using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtacBasic : MonoBehaviour
{
    public GameObject enemic;
    public GameObject arma;
    public IkController ikController;
    public Transform head;

    private int golpesConsecutivos = 0;
    private float tiempoEntreGolpes = 4f;
    private float cooldownEntreGolpes = 1f;
    private int damageBase = 10;
    private int damageExtra = 20;

    private float ultimoGolpeTiempo;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemic"))
        {
            enemic = other.gameObject;
            head = enemic.GetComponentInChildren<Target>().transform;
        }
    }

    void Update()
    {
        if (enemic != null)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                HealthSystem healthSystem = enemic.GetComponentInParent<HealthSystem>();

                if (healthSystem != null)
                {
                    if (arma.activeSelf)
                    {
                        if (Time.time - ultimoGolpeTiempo > tiempoEntreGolpes)
                        {
                            golpesConsecutivos = 0;
                        }

                        if (Time.time - ultimoGolpeTiempo > cooldownEntreGolpes)
                        {
                            golpesConsecutivos++;

                            if (golpesConsecutivos == 3)
                            {
                                healthSystem.TakeDamage(damageBase + damageExtra);
                            }
                            else
                            {
                                healthSystem.TakeDamage(damageBase);
                            }

                            ultimoGolpeTiempo = Time.time;

                            if (head != null)
                            {
                                ikController.SetEnemyTarget(head);
                                Debug.Log("cap de l'enemic");
                                Invoke("treureIk", 1.5f);
                            }
                            else
                            {
                                Debug.LogError("No s'ha trobat el cap de l'enemic.");
                            }
                        }
                        else
                        {
                            Debug.Log("Espera un momento antes de atacar de nuevo.");
                        }
                    }
                    else
                    {
                        Debug.Log("No puedes atacar con este arma.");
                    }
                }
                else
                {
                    Debug.LogError("El enemigo no tiene un componente HealthSystem.");
                }
            }
        }
    }

    void treureIk()
    {
        ikController.SetEnemyTargetOut(head);
    }
}
