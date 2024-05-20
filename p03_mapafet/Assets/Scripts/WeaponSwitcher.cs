using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    public GameObject SwissKnife;
    public GameObject Gun;
    private bool isSwissKnifeActive = false; 

    void Start()
    {
        if (isSwissKnifeActive)
        {
            SwissKnife.SetActive(true);
            Gun.SetActive(false);
        }
        else
        {
            SwissKnife.SetActive(false);
            Gun.SetActive(true);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            CambiarArma();
        }
    }

    void CambiarArma()
    {
        SwissKnife.SetActive(!isSwissKnifeActive);
        Gun.SetActive(isSwissKnifeActive);

        isSwissKnifeActive = !isSwissKnifeActive;
    }
}
