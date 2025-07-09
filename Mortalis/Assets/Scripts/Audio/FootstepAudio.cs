using UnityEngine;

namespace Artemis
{
    public class FootstepAudio : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] FirstPersonController fpController;
        [SerializeField] AudioSource footstepsSource;

        [Header("Footstep Settings")]
        [SerializeField] AudioClip[] footstepClips;
        [SerializeField] float footsetpInterval = 0.5f;

        float footstepsTimer;

        void Update()
        {
            if (fpController.CurrentSpeed > 0.8f)
            {
                footstepsTimer -= Time.deltaTime;
                if (footstepsTimer <= 0)
                {
                    PlayFootstep();
                    footstepsTimer = footsetpInterval;
                }
            }
            else
            {
                footstepsTimer = 0f;
            }
        }

        private void PlayFootstep()
        {
            if (footstepClips.Length == 0) return;

            AudioClip clip = footstepClips[Random.Range(0, footstepClips.Length)];
            footstepsSource.PlayOneShot(clip);
        }
    }
}
