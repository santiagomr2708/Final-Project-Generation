using System.Diagnostics;
using UnityEngine;
using UnityEngine.InputSystem;

public class FlashLight : MonoBehaviour
{
    public GameObject lightObject;
    public AudioClip lightSound;
    private AudioSource audioSource;
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
    }
    void LightManager()
    {
        lightObject.SetActive(!lightObject.activeSelf);
        audioSource.PlayOneShot(lightSound);
    }
}
