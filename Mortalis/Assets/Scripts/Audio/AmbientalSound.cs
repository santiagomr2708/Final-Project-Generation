using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    [SerializeField] AudioClip ambientalsound;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SoundFXManager.instance.PlaySoundFXClip(ambientalsound, transform, 1, true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
