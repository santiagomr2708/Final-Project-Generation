using UnityEngine;

public class PuzzleEyeManager : MonoBehaviour
{
    private FlashLight flashLight;
    private EyeSpawner eyeSpawner;
    public int eyeCount;
    void Start()
    {
        eyeSpawner = GameObject.Find("Eye Spawner").GetComponent<EyeSpawner>();
        flashLight = GameObject.Find("FlashLight").GetComponent<FlashLight>();
    }

    void Update()
    {
        if (eyeSpawner.cantidadRealOjos == eyeCount )
        {
            flashLight.AgregarEnergia(20f);

                    
        }
    }
}
