using System.Collections;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;


public class VideoManager : MonoBehaviour
{
    [System.Serializable]
    public class VideoSlot
    {
        public VideoPlayer videoPlayer;
        public RawImage rawImage;
    }

    public VideoSlot[] videoSlots;
    public float minTimeBetweenFlashes = 1f;
    public float maxTimeBetweenFlashes = 5f;
    public float flashDuration = 1f;

    void Start()
    {
        // Asegúrate de que todos estén ocultos y pausados al inicio
        foreach (var slot in videoSlots)
        {
            slot.rawImage.gameObject.SetActive(false);
            slot.videoPlayer.Stop();
        }

        StartCoroutine(FlashRandomVideoRoutine());
    }

    IEnumerator FlashRandomVideoRoutine()
    {
        while (true)
        {
            float wait = Random.Range(minTimeBetweenFlashes, maxTimeBetweenFlashes);
            yield return new WaitForSeconds(wait);

            int index = Random.Range(0, videoSlots.Length);
            var slot = videoSlots[index];

            // Mostrar imagen y reproducir video
            slot.rawImage.gameObject.SetActive(true);
            slot.videoPlayer.Play();

            yield return new WaitForSeconds(flashDuration);

            // Ocultar imagen y detener video
            slot.videoPlayer.Stop();
            slot.rawImage.gameObject.SetActive(false);
        }
    }
}

