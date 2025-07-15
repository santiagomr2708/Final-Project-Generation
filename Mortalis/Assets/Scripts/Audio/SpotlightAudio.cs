using UnityEngine;

public class SpotlightAudio : MonoBehaviour
{
    [SerializeField] AudioClip spotlightClip;

    void Start()
    {
        SoundFXManager.instance.PlaySoundFXClip(spotlightClip, transform, 1f, true);
    }
}
