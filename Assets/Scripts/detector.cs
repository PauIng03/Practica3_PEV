using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class detector : MonoBehaviour
{
    private PlayerController_senseimputsystem pC;
    public GameObject PersonajeCerca;
    public cajaTexto Texto;

    public Dictionary<string, Animator> animadores = new Dictionary<string, Animator>();
    public Animator NPC;
    public Animator player;
    public Conversation Conversation;

    private void Awake()
    {
        pC = GetComponentInParent<PlayerController_senseimputsystem>();

        animadores.Add("NPC", NPC);
        animadores.Add("player", player);
    }

    private void Update()
    {
        if (PersonajeCerca != null) // Verifica si hay un personaje cerca
        {
            persona CodigoPersona = PersonajeCerca.GetComponent<persona>();
            if (pC.PuedeHablar)
            {
                pC.PuedeHablar = false;
                pC.PuedeAndar = false;

                // Aqu� se obtiene el tag del personaje cercano
                string personajeTag = PersonajeCerca.tag;

                if (personajeTag == "asesino")
                {
                    DialogueManager.Instance.StartDialogue(Conversation, gameObject);
                }
                else if (personajeTag == "inocente")
                {
                    DialogueManager.Instance.StartDialogue(Conversation, gameObject);
                }
                else if (personajeTag == "testigo")
                {
                    DialogueManager.Instance.StartDialogue(Conversation, gameObject);
                }
            }
            else
            {
                StopAllCoroutines();
                Texto.CloseText();
                pC.PuedeHablar = true;
                pC.PuedeAndar = true;
            }
        }
    }


    IEnumerator dialogo(string Texto1)
    {
        Texto.OpenText(Texto1, 0.05f, 1.0f, 0.75f);

        yield return new WaitForSeconds(20);
        Texto.CloseText();
        pC.PuedeHablar = true;
        pC.PuedeAndar = true;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("personaje") || other.CompareTag("asesino") || other.CompareTag("inocente") || other.CompareTag("testigo"))
        {
            PersonajeCerca = other.gameObject;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("personaje") || other.CompareTag("asesino") || other.CompareTag("inocente") || other.CompareTag("testigo"))
        {
            PersonajeCerca = null;
        }
    }
}
