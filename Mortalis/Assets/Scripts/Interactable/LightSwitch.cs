using UnityEngine;

public class LightSwitch : MonoBehaviour
{
    public Light lightToToggle;
    AudioSource audioSource;
    public AudioClip audioClipSwitch;
    Tasks1scene tasks1Scene;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        tasks1Scene = GameObject.Find("GameManager").GetComponent<Tasks1scene>();
    }

    public void LightToggle()
    {
        
        if (lightToToggle != null)
        {
            lightToToggle.enabled = !lightToToggle.enabled;
            
            tasks1Scene.cantidadLuces++;
            audioSource.PlayOneShot(audioClipSwitch);
            Destroy(this);
        }
    }
}
