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
<<<<<<< HEAD
    public float consumeSpeed ;
    public float rechargeSpeed;
=======
    public float consumeSpeed = 1;
>>>>>>> parent of b0077b6 (MiniMapa Funcional, Arreglos,Audios calavera, Puzzle de ojos)
    public Image barraBateria;

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
        else if (!lightObject.activeSelf)
        {
<<<<<<< HEAD
            EnergiaActual += Time.deltaTime * rechargeSpeed;
=======
            EnergiaActual += Time.deltaTime * consumeSpeed;
>>>>>>> parent of b0077b6 (MiniMapa Funcional, Arreglos,Audios calavera, Puzzle de ojos)
            if (EnergiaActual > EnergiaMaxima)
            {
                EnergiaActual = EnergiaMaxima;
            }
        }
        barraBateria.fillAmount = EnergiaActual/EnergiaMaxima;
    }
    void LightManager()
    {
        lightObject.SetActive(!lightObject.activeSelf && EnergiaActual > 50);
        audioSource.PlayOneShot(lightSound);
    }
}
