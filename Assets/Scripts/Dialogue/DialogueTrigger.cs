using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    private PlayerController_senseimputsystem pC;
    public GameObject PersonajeActual;
    public cajaTexto Texto;

    public Dictionary<string, Animator> animadores = new Dictionary<string, Animator>();
    public Animator NPC;
    public Animator player;
    public Conversation ConversationAssasi;
    public Conversation ConversationTestimoni;
    public Conversation ConversationInocent;


    private void Awake()
    {
        animadores.Add("NPC", NPC);
        animadores.Add("player", player);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            pC = other.GetComponent<PlayerController_senseimputsystem>();

            if (pC != null)
            {
                PersonajeActual = gameObject;

                if (pC.PuedeHablar)
                {
                    pC.PuedeHablar = false;
                    pC.PuedeAndar = false;

                    string personajeTag = gameObject.tag;

                    if (personajeTag == "asesino")
                    {
                        DialogueManager.Instance.StartDialogue(ConversationAssasi, gameObject);
                    }
                    else if (personajeTag == "inocente")
                    {
                        DialogueManager.Instance.StartDialogue(ConversationInocent, gameObject);
                    }
                    else if (personajeTag == "testigo")
                    {
                        DialogueManager.Instance.StartDialogue(ConversationTestimoni, gameObject);
                    }
                }
                else
                {
                    pC.PuedeHablar = true;
                    pC.PuedeAndar = true;
                }
            }
        }
    }
}
