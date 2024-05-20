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
    "Soc feliç vivint en aquesta illa, però l'altre dia va haver un assassinat.",
    "Estic espantat perquè l'altre dia va haver un assassinat a l'illa.",
    "M'agrada viure aquí, però l'últim esdeveniment m'ha posat nerviós.",
    "Tot semblava perfecte fins que va succeir l'incident.",
    "Vaig pensar que aquesta illa era segura fins al dia de l'assassinat.",
    "No puc deixar de pensar en el que va passar fa uns dies.",
    "Encara no m'ho crec que hagi passat un assassinat en un lloc com aquest.",
    "Mira, aquesta illa sempre ha estat molt calmada però des de l'assassinat ja res és com era.",
    "Tothom del barri parla sobre l'assassinat, ja no sé ni amb qui puc confiar."
    };

    public string[] Dialegs2Testimonis =
    {
    "Jo estava caminant pel carrer quan vaig sentir els crits.",
    "Vaig veure algú corrent en la direcció contrària just després de sentir el soroll.",
    "No vaig veure la cara de la persona, però portava una espècie de gorra.",
    "Recordo que era al voltant de les 9 del matí, encara hi havia molta gent al carrer.",
    "Vaig trucar immediatament a la policia quan vaig adonar-me de la situació.",
    "Jo estava a casa al moment de l'incident, no vaig sortir fins que vaig sentir els crits.",
    "Vaig escoltar algú cridar per ajuda, però quan vaig sortir al carrer, ja era massa tard.",
    "Vaig notar un home estrany rondant pel barri uns dies abans. Semblava nerviós, com si amagués alguna cosa.",
    "Vaig veure una figura sospitosa aprop del mar. No sé si està relacionat amb l'assassinat, però em va posar els pèls de punta."
    };

    public string[] Dialegs3MinijocTestigos =
    {
    "És possible que tingui més informació sobre el que va passar. Tot i així, no t'ho diré tan fàcilment. Primer necessito que em facis un favor.",
    "No puc revelar-te res fins que em demostris la teva confiança. Necessito que primer, m'ajudis en una feina que tinc per a tu.",
    "Tinc informació, però no la obtindràs tan fàcilment. Has de guanyar-te-la.",
    "Estic disposat a dir-te el que sé, però primer hauràs de demostrar el teu compromís.",
    "Si vols saber més, hauràs de superar una prova primer.",
    "En el cas que sàpiga algo, no t'ho diré de manera gratuïta. Hauràs de fer alguna cosa per a mi primer.",
    "Puc ajudar-te sobre el cas, però necessito la teva ajuda primer.",
    "Sí que vaig veure algo al moment de l'incident, però les meves paraules valen or així que primer m'hauràs d'ajudar amb la meva botiga.",
    "A canvi de revelar-te informació sobre el cas, primer m'has de fer un favor."
    };

    public string[] Dialegs3MinijocInocents=
    {
    "No puc revelar-te res fins que em demostris la teva confiança. Necessito que primer, m'ajudis en una feina que tinc per a tu.",
    "No tinc res a dir-te ara mateix, però si em fas un favor, potser després puc ajudar-te.",
    "Em sap greu, però primer hauràs de superar una prova abans de que pugui dir-te res.",
    "No sé si tinc l'informació que tu necessites. Hauràs de demostrar el teu compromís abans.",
    "Potser podria ajudar-te, però necessito la teva ajuda primer. Només així podré ser útil.",
    "Estic disposat a dir-te el que sé, però primer hauràs de demostrar que ets confiable.",
    "No estic segur si seré de gaire ajuda. En qualsevol cas, parlaré si superes una prova que tinc per a tu.",
    "No sé res sobre el cas, però si m'ajudes ara amb la meva botiga potser m'enrecordo d'algo. És que tinc mala memòria...",
    "No crec que et serveixi de molt el què et dire. Tot i així, fes-me un favor primer i després si vull, et diré tot el que sé."
    };

    public string[] Dialegs4PistesInocents =
    {
    "Gràcies per ajudar-me. No obstant, em sap greu dir-te que el pensava que havia recordat, se m'ha tornat a oblidar.",
    "Ho has fet prou bé, merci. Tot i així, sento dir-te que no vaig veure res extrany en el moment de l'assassinat.",
    "Has fet una bona feina ajudant-me, però no recordo cap detall addicional sobre aquell dia.",
    "M'hauria agradat poder ajudar-te, però sincerament, no tinc cap informació addicional sobre l'assassinat.",
    "És frustrant, però no puc recordar res més que pugui ser rellevant per a la investigació.",
    "Em sap greu decebre't, però no puc oferir-te cap pista nova en aquest moment.",
    "Crec que he intentat recordar, però no hi ha cap detall que pugui aportar a la investigació.",
    "Ho sento però no vaig veure res. Em sap greu no poder ajudar-te.",
    "Sóc totalment innocent, no vaig veure res extrany, de veritat. "
    };

    public string[] Dialegs4PistesTestimonisFruiter =
    {
    "Gràcies per fer-me el favor. Jo crec que ha estat un habitant que sempre va tacat de colors.",
    "Gràcies per ajudar-me, a canvi et tornaré el favor. El meu possible assassí ajuda als altres habitants a mantenir-se molt sans.",
    "Ara que m’has ajudat ja t’ho puc dir. Crec que el sospitós sempre va amb ganivets llargs a sobre per si els necessita.",
    "Com que m’has ajudat molt, et revelaré el que sé sobre el sospitós. M’han dit sempre que el seu somni frustrat era ser cuiner."
    };

    public string[] Dialegs4PistesTestimonisCuiner =
    {
    "Ara que m’has ajudat ja t’ho puc dir. Sempre mira Masterchef.",
    "Gràcies per ajudar-me, a canvi et tornaré el favor. La persona culpable té bastants ganivets al seu local.",
    "Merci per tot el que has fet, a canvi et diré que el meu sospitós treballa moltes hores al dia i no descansa quasi mai.",
    "Gràcies per fer-me el favor. El meu possible assassí sempre fa olor a oli."
    };

    public string[] Dialegs4PistesTestimonisMecanic =
    {
    "Ara que m’has ajudat ja t’ho puc dir. La persona qui crec que és sospitosa va sempre brut.",
    "Com que m’has fet un gran favor, et diré la veritat. L’assassí és un manetes.",
    "Gràcies per ajudar-me. El principal culpable és conegut per arreglar coses.",
    "Merci per tot el que has fet, a canvi et diré que el meu sospitós té moltes eines."
    };

    public string[] Dialegs4PistesTestimonisPolicia =
    {
    "Ara que ja m’has ajudat et revelaré tot el que sé sobre el cas. Quan veig el sospitós pel carrer sempre imposa molt i és molt seriós.",
    "Com que m’has fet un gran favor, et diré la veritat. Em sembla estrany que l’assassí sigui la persona que crec. Seria hipòcrita de part seva.",
    "Merci per tot el que has fet, a canvi et diré que el meu possible sospitós sempre tracta amb males influències.",
    "Gràcies pel favor. Només et puc revelar que el meu possible assassí coneix a tot el poble i segueix els habitants molt d’aprop."
    };

    public string[] Dialegs4PistesTestimonisPastisser =
    {
    "Ara que ja has fet la feina que t’havia demanat, et revelaré el que sé. Si no m’equivoco, el possible assassí fa menjar molt bo.",
    "Gràcies pel favor. Només et puc revelar que el meu possible assassí es desperta molt d'hora, cap a les 6 del matí per obrir el seu local.",
    "Com que m’has fet un gran favor et diré que els productes que ven fan molt bona olor.",
    "Merci pel que has fet, a canvi et diré que el meu possible sospitós no para de menjar ja que sempre està envoltat d’aliments."
    };

    public string[] Dialegs4PistesTestimonisDependent =
    {
    "Ben jugat! Ara ja et puc confessar el que sé. La persona que considero més sospitosa sempre segueix les tendències.",
    "Ara que ja has fet la feina que t’havia demanat, et revelaré el que sé. Si no m’equivoco, el possible assassí es fixa molt amb l'estil de la gent.",
    "Gràcies per l’ajuda, per tornar-te el favor i poder resoldre el cas et diré que el somni frustrat de l'assassí era estudiar disseny de moda.",
    "Wow, m’has servit de gran ajuda, a canvi et diré que la persona sospitosa és molt presumida."
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
        if (Inocentes.Count == 0) // Verifica si la lista Inocentes está vacía
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
                codigoPersona.Dialogos[0] = "Hola, encantat de conèixer-te. En aquesta illa soc " + codigoPersona.gameObject.name + ".";
                codigoPersona.Dialogos[1] = Dialegs2Inocents[Random.Range(0, Dialegs2Inocents.Length)];
                codigoPersona.Dialogos[2] = Dialegs3MinijocInocents[Random.Range(0, Dialegs3MinijocInocents.Length)];
                //Dialegs 3 son les instruccions del joc
                codigoPersona.Dialogos[4] = Dialegs4PistesInocents[Random.Range(0, Dialegs4PistesInocents.Length)];
            }
            else
            {
                codigoPersona.Dialogos[0] = "Hola, encantat de conèixer-te. En aquesta illa soc " + codigoPersona.gameObject.name + ".";
                codigoPersona.Dialogos[1] = Dialegs2Testimonis[Random.Range(0, Dialegs2Testimonis.Length)];
                codigoPersona.Dialogos[2] = Dialegs3MinijocTestigos[Random.Range(0, Dialegs3MinijocTestigos.Length)];
                //Dialegs 3 son les instruccions del joc
                if (Asesino.name == "fruiter")
                {
                    codigoPersona.Dialogos[4] = Dialegs4PistesTestimonisFruiter[Random.Range(0, Dialegs4PistesTestimonisFruiter.Length)]; 
                }
                if (Asesino.name == "mecànic")
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
                if (Asesino.name == "policía")
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
