using System.Diagnostics;
using UnityEngine;
using UnityEngine.InputSystem;

public class FlashLight : MonoBehaviour
{
    public GameObject lightObject;
    public AudioClip lightSound;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            LightManager();

        }
    }
    void LightManager()
    {
        lightObject.SetActive(!lightObject.activeSelf);
        SoundFXManager.instance.PlaySoundFXClip(lightSound, transform, 1f, false);
    }
}
