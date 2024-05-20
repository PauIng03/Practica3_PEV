using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class detector : MonoBehaviour
{
    private PlayerController_senseimputsystem pC;
    public GameObject PersonajeCerca;
    public cajaTexto Texto;
   // public GameObject BotoJugar;
    private bool botonJugarPresionado = false;

    public Dictionary<string, Animator> animadores = new Dictionary<string, Animator>();
    public Animator cuiner;
    public Animator fruiter;
    public Animator pastisser;
    public Animator policía;
    public Animator mecànic;
    public Animator dependent;
    public Animator player;

    private void Awake()
    {
        pC = GetComponentInParent<PlayerController_senseimputsystem>();

        // Añade todos los animadores al diccionario
        animadores.Add("cuiner", cuiner);
        animadores.Add("fruiter", fruiter);
        animadores.Add("pastisser", pastisser);
        animadores.Add("policía", policía);
        animadores.Add("mecànic", mecànic);
        animadores.Add("dependent", dependent);
        animadores.Add("player", player);
    }

    private void Update()
    {
        if (PersonajeCerca != null) // Verifica si hi ha un personatge aprop
        {
            persona CodigoPersona = PersonajeCerca.GetComponent<persona>();
            if (pC.PuedeHablar)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    pC.PuedeHablar = false;
                    pC.PuedeAndar = false;

                    foreach (var animador in animadores)
                    {
                        if (animador.Key == PersonajeCerca.name)
                        {
                            animador.Value.SetBool("Saludar", CodigoPersona.DialogoValue == 0);
                            animador.Value.SetBool("Parlar", CodigoPersona.DialogoValue != 0);
                        }
                        else
                        {
                            animador.Value.SetBool("Saludar", false);
                            animador.Value.SetBool("Parlar", false);
                        }
                    }

                    if (CodigoPersona.DialogoValue == 3) // Verifica si el diálogo es el cuarto y el botón de jugar ha sido presionado
                    {
                        //BotoJugar.GetComponent<botoJugar>().PersonajeString = PersonajeCerca.name;
                       // BotoJugar.SetActive(true);
                        Debug.Log(CodigoPersona.DialogoValue);
                    }
                    
                    if (CodigoPersona.DialogoValue == 0)
                    {
                        player.SetBool("run", true);
                        StartCoroutine(dialogo(CodigoPersona.Dialogos[CodigoPersona.DialogoValue]));
                        Debug.Log("Saludar");
                        
                    }
                    if (CodigoPersona.DialogoValue != 4 && CodigoPersona.DialogoValue != 0)
                    {
                        StartCoroutine(dialogo(CodigoPersona.Dialogos[CodigoPersona.DialogoValue]));
                        Debug.Log(CodigoPersona.DialogoValue);
                        player.SetBool("run", false);
                    }
                    if (CodigoPersona.DialogoValue == 4 && botonJugarPresionado) // Verifica si el diálogo es el cuarto y el botón de jugar ha sido presionado
                    {
                        StartCoroutine(dialogo(CodigoPersona.Dialogos[CodigoPersona.DialogoValue]));
                        botonJugarPresionado = false;
                        Debug.Log(CodigoPersona.DialogoValue);
                    }
                    else if (CodigoPersona.DialogoValue == 4 && !botonJugarPresionado) // Verifica si el diálogo es el cuarto y el botón de jugar ha sido presionado
                    {
                        CodigoPersona.DialogoValue = 3;
                        StartCoroutine(dialogo(CodigoPersona.Dialogos[CodigoPersona.DialogoValue]));
                        //BotoJugar.GetComponent<botoJugar>().PersonajeString = PersonajeCerca.name;
                       // BotoJugar.SetActive(true);
                        Debug.Log(CodigoPersona.DialogoValue);
                    }
                    if (CodigoPersona.DialogoValue > 4)
                    {
                        CodigoPersona.DialogoValue = 4;
                        StartCoroutine(dialogo(CodigoPersona.Dialogos[CodigoPersona.DialogoValue]));
                        Debug.Log(CodigoPersona.DialogoValue);
                    }
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    StopAllCoroutines();
                    DialogoManager();
                    Texto.CloseText();
                    pC.PuedeHablar = true;
                    pC.PuedeAndar = true;
                }
            }
        }
    }

    public void DialogoManager()
    {
        persona CodigoPersona = PersonajeCerca.GetComponent<persona>();
        if (CodigoPersona.Fase == 0)
        {
            if (CodigoPersona.DialogoValue < CodigoPersona.Dialogos.Length - 1)
            {
                CodigoPersona.DialogoValue += 1;
            }
        }
    }

    IEnumerator dialogo(string Texto1)
    {
        Texto.OpenText(Texto1, 0.05f, 1.0f, 0.75f);

        yield return new WaitForSeconds(20);
        DialogoManager();

        Texto.CloseText();
        pC.PuedeHablar = true;
        pC.PuedeAndar = true;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "personaje" || other.tag == "asesino" || other.tag == "inocente")
        {
            PersonajeCerca = other.gameObject;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "personaje" || other.tag == "asesino" || other.tag == "inocente")
        {
            PersonajeCerca = null;
        }
    }

    public void BotonJugarPresionado()
    {
        botonJugarPresionado = true;
    }
}


