using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generador : MonoBehaviour
{
    public GameObject[] personajes;
    public int valorAsesino;
    public string nombreAsesino;
    public string[] Dialegs2Inocents =
    {
    "Soc feli� vivint en aquesta illa, per� l'altre dia va haver un assassinat.",
    "Estic espantat perqu� l'altre dia va haver un assassinat a l'illa.",
    "M'agrada viure aqu�, per� l'�ltim esdeveniment m'ha posat nervi�s.",
    "Tot semblava perfecte fins que va succeir l'incident.",
    "Vaig pensar que aquesta illa era segura fins al dia de l'assassinat.",
    "No puc deixar de pensar en el que va passar fa uns dies.",
    "Encara no m'ho crec que hagi passat un assassinat en un lloc com aquest.",
    "Mira, aquesta illa sempre ha estat molt calmada per� des de l'assassinat ja res �s com era.",
    "Tothom del barri parla sobre l'assassinat, ja no s� ni amb qui puc confiar."
    };

    public string[] Dialegs2Testimonis =
    {
    "Jo estava caminant pel carrer quan vaig sentir els crits.",
    "Vaig veure alg� corrent en la direcci� contr�ria just despr�s de sentir el soroll.",
    "No vaig veure la cara de la persona, per� portava una esp�cie de gorra.",
    "Recordo que era al voltant de les 9 del mat�, encara hi havia molta gent al carrer.",
    "Vaig trucar immediatament a la policia quan vaig adonar-me de la situaci�.",
    "Jo estava a casa al moment de l'incident, no vaig sortir fins que vaig sentir els crits.",
    "Vaig escoltar alg� cridar per ajuda, per� quan vaig sortir al carrer, ja era massa tard.",
    "Vaig notar un home estrany rondant pel barri uns dies abans. Semblava nervi�s, com si amagu�s alguna cosa.",
    "Vaig veure una figura sospitosa aprop del mar. No s� si est� relacionat amb l'assassinat, per� em va posar els p�ls de punta."
    };

    public string[] Dialegs3MinijocTestigos =
    {
    "�s possible que tingui m�s informaci� sobre el que va passar. Tot i aix�, no t'ho dir� tan f�cilment. Primer necessito que em facis un favor.",
    "No puc revelar-te res fins que em demostris la teva confian�a. Necessito que primer, m'ajudis en una feina que tinc per a tu.",
    "Tinc informaci�, per� no la obtindr�s tan f�cilment. Has de guanyar-te-la.",
    "Estic disposat a dir-te el que s�, per� primer haur�s de demostrar el teu comprom�s.",
    "Si vols saber m�s, haur�s de superar una prova primer.",
    "En el cas que s�piga algo, no t'ho dir� de manera gratu�ta. Haur�s de fer alguna cosa per a mi primer.",
    "Puc ajudar-te sobre el cas, per� necessito la teva ajuda primer.",
    "S� que vaig veure algo al moment de l'incident, per� les meves paraules valen or aix� que primer m'haur�s d'ajudar amb la meva botiga.",
    "A canvi de revelar-te informaci� sobre el cas, primer m'has de fer un favor."
    };

    public string[] Dialegs3MinijocInocents=
    {
    "No puc revelar-te res fins que em demostris la teva confian�a. Necessito que primer, m'ajudis en una feina que tinc per a tu.",
    "No tinc res a dir-te ara mateix, per� si em fas un favor, potser despr�s puc ajudar-te.",
    "Em sap greu, per� primer haur�s de superar una prova abans de que pugui dir-te res.",
    "No s� si tinc l'informaci� que tu necessites. Haur�s de demostrar el teu comprom�s abans.",
    "Potser podria ajudar-te, per� necessito la teva ajuda primer. Nom�s aix� podr� ser �til.",
    "Estic disposat a dir-te el que s�, per� primer haur�s de demostrar que ets confiable.",
    "No estic segur si ser� de gaire ajuda. En qualsevol cas, parlar� si superes una prova que tinc per a tu.",
    "No s� res sobre el cas, per� si m'ajudes ara amb la meva botiga potser m'enrecordo d'algo. �s que tinc mala mem�ria...",
    "No crec que et serveixi de molt el qu� et dire. Tot i aix�, fes-me un favor primer i despr�s si vull, et dir� tot el que s�."
    };

    public string[] Dialegs4PistesInocents =
    {
    "Gr�cies per ajudar-me. No obstant, em sap greu dir-te que el pensava que havia recordat, se m'ha tornat a oblidar.",
    "Ho has fet prou b�, merci. Tot i aix�, sento dir-te que no vaig veure res extrany en el moment de l'assassinat.",
    "Has fet una bona feina ajudant-me, per� no recordo cap detall addicional sobre aquell dia.",
    "M'hauria agradat poder ajudar-te, per� sincerament, no tinc cap informaci� addicional sobre l'assassinat.",
    "�s frustrant, per� no puc recordar res m�s que pugui ser rellevant per a la investigaci�.",
    "Em sap greu decebre't, per� no puc oferir-te cap pista nova en aquest moment.",
    "Crec que he intentat recordar, per� no hi ha cap detall que pugui aportar a la investigaci�.",
    "Ho sento per� no vaig veure res. Em sap greu no poder ajudar-te.",
    "S�c totalment innocent, no vaig veure res extrany, de veritat. "
    };

    public string[] Dialegs4PistesTestimonisFruiter =
    {
    "Gr�cies per fer-me el favor. Jo crec que ha estat un habitant que sempre va tacat de colors.",
    "Gr�cies per ajudar-me, a canvi et tornar� el favor. El meu possible assass� ajuda als altres habitants a mantenir-se molt sans.",
    "Ara que m�has ajudat ja t�ho puc dir. Crec que el sospit�s sempre va amb ganivets llargs a sobre per si els necessita.",
    "Com que m�has ajudat molt, et revelar� el que s� sobre el sospit�s. M�han dit sempre que el seu somni frustrat era ser cuiner."
    };

    public string[] Dialegs4PistesTestimonisCuiner =
    {
    "Ara que m�has ajudat ja t�ho puc dir. Sempre mira Masterchef.",
    "Gr�cies per ajudar-me, a canvi et tornar� el favor. La persona culpable t� bastants ganivets al seu local.",
    "Merci per tot el que has fet, a canvi et dir� que el meu sospit�s treballa moltes hores al dia i no descansa quasi mai.",
    "Gr�cies per fer-me el favor. El meu possible assass� sempre fa olor a oli."
    };

    public string[] Dialegs4PistesTestimonisMecanic =
    {
    "Ara que m�has ajudat ja t�ho puc dir. La persona qui crec que �s sospitosa va sempre brut.",
    "Com que m�has fet un gran favor, et dir� la veritat. L�assass� �s un manetes.",
    "Gr�cies per ajudar-me. El principal culpable �s conegut per arreglar coses.",
    "Merci per tot el que has fet, a canvi et dir� que el meu sospit�s t� moltes eines."
    };

    public string[] Dialegs4PistesTestimonisPolicia =
    {
    "Ara que ja m�has ajudat et revelar� tot el que s� sobre el cas. Quan veig el sospit�s pel carrer sempre imposa molt i �s molt seri�s.",
    "Com que m�has fet un gran favor, et dir� la veritat. Em sembla estrany que l�assass� sigui la persona que crec. Seria hip�crita de part seva.",
    "Merci per tot el que has fet, a canvi et dir� que el meu possible sospit�s sempre tracta amb males influ�ncies.",
    "Gr�cies pel favor. Nom�s et puc revelar que el meu possible assass� coneix a tot el poble i segueix els habitants molt d�aprop."
    };

    public string[] Dialegs4PistesTestimonisPastisser =
    {
    "Ara que ja has fet la feina que t�havia demanat, et revelar� el que s�. Si no m�equivoco, el possible assass� fa menjar molt bo.",
    "Gr�cies pel favor. Nom�s et puc revelar que el meu possible assass� es desperta molt d'hora, cap a les 6 del mat� per obrir el seu local.",
    "Com que m�has fet un gran favor et dir� que els productes que ven fan molt bona olor.",
    "Merci pel que has fet, a canvi et dir� que el meu possible sospit�s no para de menjar ja que sempre est� envoltat d�aliments."
    };

    public string[] Dialegs4PistesTestimonisDependent =
    {
    "Ben jugat! Ara ja et puc confessar el que s�. La persona que considero m�s sospitosa sempre segueix les tend�ncies.",
    "Ara que ja has fet la feina que t�havia demanat, et revelar� el que s�. Si no m�equivoco, el possible assass� es fixa molt amb l'estil de la gent.",
    "Gr�cies per l�ajuda, per tornar-te el favor i poder resoldre el cas et dir� que el somni frustrat de l'assass� era estudiar disseny de moda.",
    "Wow, m�has servit de gran ajuda, a canvi et dir� que la persona sospitosa �s molt presumida."
    };

    public GameObject Asesino;
    public List<GameObject> Inocentes = new List<GameObject>();
    public GameObject Testigo1;
    public GameObject Testigo2;
    [Space(10)]
    public float a;


    private string[] Inocents;
    private int Assassi;
    private string Testimoni1;
    private string Testimoni2;


    void Start()
    {
        if (!CarregarVariables())
        {
            Assassi = Random.Range(0, personajes.Length);
        }
        else
        {
            Debug.Log("Se han cargado los valores de los testigos guardados.");
        }

        GenerarAsesino();
    }

    void GenerarAsesino()
    {
        valorAsesino = Assassi;

        Asesino = personajes[valorAsesino];
        nombreAsesino = Asesino.name;
        Asesino.gameObject.tag = "asesino";
        GenerarTestigos();
    }

    void GenerarTestigos()
    {
        if (Inocentes.Count == 0) // Verifica si la lista Inocentes est� vac�a
        {
            Inocentes.AddRange(GameObject.FindGameObjectsWithTag("personaje"));
            if (Inocentes.Count >= 2)
            {
                Testigo1 = Inocentes[Random.Range(0, Inocentes.Count)];
                Inocentes.Remove(Testigo1);
                Testigo2 = Inocentes[Random.Range(0, Inocentes.Count)];
                Inocentes.Remove(Testigo2);
            }
            else
            {
                Debug.LogError("No hay suficientes personajes para generar testigos.");
                return;
            }
        }
        else
        {
            Debug.Log("Los inocentes ya se han generado previamente.");
            return;
        }

        foreach (GameObject go in Inocentes)
        {
            go.tag = "inocente";
        }
        Inocentes.Add(Asesino);
        GenerarDialogos();
    }


    public void guardarVariables()
    {
        PlayerPrefs.SetInt("Assassi", valorAsesino);
        List<string> InocentsNames = new List<string>();
        foreach (GameObject go in Inocentes)
        {
            InocentsNames.Add(go.name);
        }
        PlayerPrefs.SetString("Inocents", string.Join(",", InocentsNames));

        PlayerPrefs.SetString("Testimoni1", Testigo1.name);
        PlayerPrefs.SetString("Testimoni2", Testigo2.name);

        Debug.Log("S'han guardat les variables correctament");
        PlayerPrefs.Save();
    }

    public void NoguardarVariables()
    {
        PlayerPrefs.DeleteKey("Assassi");
        PlayerPrefs.DeleteKey("Inocents");
        PlayerPrefs.DeleteKey("Testimoni1");
        PlayerPrefs.DeleteKey("Testimoni2");
        Inocentes.Clear();
        Debug.Log("S'han esborrat les variables correctament");
        PlayerPrefs.Save();
    }

    public bool CarregarVariables()
    {
        if (PlayerPrefs.HasKey("Assassi"))
        {
            Assassi = PlayerPrefs.GetInt("Assassi");
            string[] InocentsNames = PlayerPrefs.GetString("Inocents").Split(',');
            foreach (string name in InocentsNames)
            {
                GameObject inocente = GameObject.Find(name);
                if (inocente != null)
                {
                    Inocentes.Add(inocente);
                }
            }
            Testimoni1 = PlayerPrefs.GetString("Testimoni1");
            Testimoni2 = PlayerPrefs.GetString("Testimoni2");
            Testigo1 = GameObject.Find(Testimoni1);
            Testigo2 = GameObject.Find(Testimoni2);
            Debug.Log("Se han cargado las variables correctamente.");
            return true;
        }
        else
        {
            Debug.Log("No se han encontrado variables guardadas.");
            return false;
        }
    }


    void GenerarDialogos()
    {
        foreach(GameObject personaje in personajes)
        {
            persona codigoPersona = personaje.GetComponent<persona>();
            if (Inocentes.Contains(personaje))
            {
                codigoPersona.Dialogos[0] = "Hola, encantat de con�ixer-te. En aquesta illa soc " + codigoPersona.gameObject.name + ".";
                codigoPersona.Dialogos[1] = Dialegs2Inocents[Random.Range(0, Dialegs2Inocents.Length)];
                codigoPersona.Dialogos[2] = Dialegs3MinijocInocents[Random.Range(0, Dialegs3MinijocInocents.Length)];
                //Dialegs 3 son les instruccions del joc
                codigoPersona.Dialogos[4] = Dialegs4PistesInocents[Random.Range(0, Dialegs4PistesInocents.Length)];
            }
            else
            {
                codigoPersona.Dialogos[0] = "Hola, encantat de con�ixer-te. En aquesta illa soc " + codigoPersona.gameObject.name + ".";
                codigoPersona.Dialogos[1] = Dialegs2Testimonis[Random.Range(0, Dialegs2Testimonis.Length)];
                codigoPersona.Dialogos[2] = Dialegs3MinijocTestigos[Random.Range(0, Dialegs3MinijocTestigos.Length)];
                //Dialegs 3 son les instruccions del joc
                if (Asesino.name == "fruiter")
                {
                    codigoPersona.Dialogos[4] = Dialegs4PistesTestimonisFruiter[Random.Range(0, Dialegs4PistesTestimonisFruiter.Length)]; 
                }
                if (Asesino.name == "mec�nic")
                {
                    codigoPersona.Dialogos[4] = Dialegs4PistesTestimonisMecanic[Random.Range(0, Dialegs4PistesTestimonisMecanic.Length)]; 
                }
                if (Asesino.name == "dependent")
                {
                    codigoPersona.Dialogos[4] = Dialegs4PistesTestimonisDependent[Random.Range(0, Dialegs4PistesTestimonisDependent.Length)]; 
                }
                if (Asesino.name == "pastisser")
                {
                    codigoPersona.Dialogos[4] = Dialegs4PistesTestimonisPastisser[Random.Range(0, Dialegs4PistesTestimonisPastisser.Length)]; 
                }
                if (Asesino.name == "polic�a")
                {
                    codigoPersona.Dialogos[4] = Dialegs4PistesTestimonisPolicia[Random.Range(0, Dialegs4PistesTestimonisPolicia.Length)];
                }
                if (Asesino.name == "cuiner")
                {
                    codigoPersona.Dialogos[4] = Dialegs4PistesTestimonisCuiner[Random.Range(0, Dialegs4PistesTestimonisCuiner.Length)];
                }
            }
        }
    }
}
