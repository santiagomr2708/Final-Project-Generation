using System.Collections;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.InputSystem;

using UnityEngine.UI;
public class FlashLight : MonoBehaviour
{
    public GameObject lightObject;
    public AudioClip lightSound;
    public float EnergiaActual = 100;
    public float EnergiaMaxima = 100;

    public float consumeSpeed = 10;

    public float rechargeSpeed;

    public Image barraBateria;
    private bool energiaExtraPendiente = false;

    // Update is called once per frame
    void Update()
    {
        if (lightObject.activeSelf)
        {
            EnergiaActual -= Time.deltaTime * consumeSpeed;
            if (EnergiaActual <= 0)
            {
                EnergiaActual = 0;
                lightObject.SetActive(false);
            }
        }
        else if (!lightObject.activeSelf && !energiaExtraPendiente)
        {
            EnergiaActual += Time.deltaTime * 2;
            if (EnergiaActual > EnergiaMaxima)
            {
                EnergiaActual = EnergiaMaxima;

            }
        }
        barraBateria.fillAmount = EnergiaActual / EnergiaMaxima;
    }
    public void LightManager()
    {
        lightObject.SetActive(!lightObject.activeSelf && EnergiaActual > 20);
        SoundFXManager.instance.PlaySoundFXClip(lightSound, transform, 1f, false);
    }
    public void AgregarEnergia(float cantidad)
    {
        energiaExtraPendiente = true;
        EnergiaActual = Mathf.Min(EnergiaActual + cantidad, EnergiaMaxima);

        StartCoroutine(DesbloquearRegeneracion());
    }

    private IEnumerator DesbloquearRegeneracion()
    {

        yield return new WaitForEndOfFrame();
        energiaExtraPendiente = false;
    }
}

