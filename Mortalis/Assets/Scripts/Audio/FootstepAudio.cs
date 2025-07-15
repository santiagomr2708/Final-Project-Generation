using UnityEngine;

namespace Artemis
{
    public class FootstepAudio : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] FirstPersonController fpController;

        [Header("Footstep Settings")]
        [SerializeField] AudioClip footstepClip;
        [SerializeField] float footsetpInterval = 0.5f;

        float footstepsTimer;

        void Update()
        {
            if (fpController.CurrentSpeed > 0.8f)
            {
                footstepsTimer -= Time.deltaTime;
                if (footstepsTimer <= 0)
                {
                    SoundFXManager.instance.PlaySoundFXClip(footstepClip, transform, 1f, false);
                    footstepsTimer = footsetpInterval;
                }
            }
            else
            {
                footstepsTimer = 0f;
            }
        }
    }
}
