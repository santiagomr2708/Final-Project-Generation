using UnityEngine;

public class SoundFXManager : MonoBehaviour
{
    public static SoundFXManager instance;

    [SerializeField] AudioSource soundFXobject;

    void Awake()
    {
        if (instance == null) instance = this;
    }

    public void PlaySoundFXClip(AudioClip audioClip, Transform spawnTransform, float volume)
    {
        // Spawn in gameObject
        AudioSource audioSource = Instantiate(soundFXobject, spawnTransform.position, Quaternion.identity);

        // assing the audioClip
        audioSource.clip = audioClip;

        // assing volume
        audioSource.volume = volume;

        // Play sound
        audioSource.Play();

        // Get lenght of sound FX clip
        float clipLength = audioSource.clip.length;

        // Destroy the clip after it is done playing
        Destroy(audioSource.gameObject, clipLength);
    }

    public void PlayRandomSoundFXClip(AudioClip[] audioClip, Transform spawnTransform, float volume)
    {
        // Assing a random index
        int rand = Random.Range(0, audioClip.Length);

        // Spawn in gameObject
        AudioSource audioSource = Instantiate(soundFXobject, spawnTransform.position, Quaternion.identity);

        // assing the audioClip
        audioSource.clip = audioClip[rand];

        // assing volume
        audioSource.volume = volume;

        // Play sound
        audioSource.Play();

        // Get lenght of sound FX clip
        float clipLength = audioSource.clip.length;

        // Destroy the clip after it is done playing
        Destroy(audioSource.gameObject, clipLength);
    }
}
