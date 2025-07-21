using UnityEngine;
using Unity.UI;
using Microsoft.Unity.VisualStudio.Editor;
using Artemis;
using Unity.VisualScripting;

public class DeathsManager : MonoBehaviour
{
    [SerializeField] GameObject[] corazones;
    [SerializeField] GameObject miniMap;
    [SerializeField] GameObject endGame;

    private FirstPersonController firstPersonController;
    private Player player;
    private DatosDejuego datosDejuego;
    private FlashLight flashLight;
    void Awake()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        datosDejuego = new DatosDejuego();
        firstPersonController = GameObject.Find("Player").GetComponent<FirstPersonController>();
        flashLight = GameObject.Find("FlashLight").GetComponent<FlashLight>();
    }
    void Update()
    {
        if (datosDejuego.cantidadVidas == 3)
        {
            miniMap.SetActive(false);
            firstPersonController.maxSpeed = 15;
            flashLight.consumeSpeed = 10;
            flashLight.rechargeSpeed = 2;


        }
        else if (datosDejuego.cantidadVidas == 2)
        {
            miniMap.SetActive(false);
            firstPersonController.maxSpeed = 10;
            flashLight.consumeSpeed = 8;
            flashLight.rechargeSpeed = 5;
            corazones[0].SetActive(false);

        }
        else if (datosDejuego.cantidadVidas == 1)
        {
            miniMap.SetActive(true);
            firstPersonController.maxSpeed = 5;
            flashLight.consumeSpeed = 5;
            flashLight.rechargeSpeed = 10;
            corazones[1].SetActive(false);
            corazones[0].SetActive(false);

        }
        else if (datosDejuego.cantidadVidas == 0)
        {
            endGame.SetActive(true);
        }
        
    }

}
