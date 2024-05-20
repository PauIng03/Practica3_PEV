using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Volum : MonoBehaviour
{
    public Slider slider;
    public float sliderValue;
    public Image imatgeMute;

    // Start is called before the first frame update
    void Start()
    {
        slider.value = PlayerPrefs.GetFloat("volumenAudio", 0.5f);
        AudioListener.volume = slider.value;
        RevisarSiEsticMute();
    }

    public void ChangeSlider(float valor)
    {
        sliderValue = valor;
        PlayerPrefs.SetFloat("volumenAudio", sliderValue);
        AudioListener.volume = slider.value;
        RevisarSiEsticMute();
    }
    
    public void RevisarSiEsticMute()
    {
        if(sliderValue == 0)
        {
            imatgeMute.enabled = true;
        }
        else
        {
            imatgeMute.enabled = false;
        }
    }
}