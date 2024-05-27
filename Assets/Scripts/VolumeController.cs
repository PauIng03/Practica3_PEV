using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    [SerializeField]
    private Volume volume;
    [SerializeField]
    private Slider redValueSlider;

    private ChannelMixer channelMixer;

    void Start()
    {
        if (volume == null)
        {
            Debug.LogError("Volume is not assigned.");
            return;
        }

        if (redValueSlider == null)
        {
            Debug.LogError("Red Value Slider is not assigned.");
            return;
        }

        // Initialize the channel mixer reference
        if (volume.profile.TryGet(out channelMixer))
        {
            // Set initial slider value to match current channel mixer value
            redValueSlider.value = channelMixer.redOutRedIn.value;
            // Assign the method to be called when the slider value changes
            redValueSlider.onValueChanged.AddListener(OnRedValueChanged);
        }
        else
        {
            Debug.LogError("Channel Mixer is not found in the Volume profile.");
        }
    }

    void OnRedValueChanged(float value)
    {
        if (channelMixer != null)
        {
            channelMixer.redOutRedIn.value = value;
            Debug.Log($"Red channel value changed to: {value}");
        }
    }
}
