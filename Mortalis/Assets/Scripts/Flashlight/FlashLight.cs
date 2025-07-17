using System.Collections;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.InputSystem;

using UnityEngine.UI;
public class FlashLight : MonoBehaviour
{
    public GameObject lightObject;
    public AudioClip lightSound;
    private AudioSource audioSource;
    public float EnergiaActual = 100;
    public float EnergiaMaxima = 100;
    public float consumeSpeed = 10;
    public Image barraBateria;
    private bool energiaExtraPendiente = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            LightManager();

        }

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
            EnergiaActual += Time.deltaTime;
            if (EnergiaActual > EnergiaMaxima)
            {
                EnergiaActual = EnergiaMaxima;

            }
        }
        barraBateria.fillAmount = EnergiaActual / EnergiaMaxima;
    }
    void LightManager()
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

