using Artemis;
using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEngine;

namespace Artemis
{
    public class HeadBobExtension : MonoBehaviour
    {
        [SerializeField] FirstPersonController fpController;
        [SerializeField] CinemachineCamera fpCamera;

        [Header("Headbob Settings")]
        [SerializeField] float walkingAmplitude = 0.15f;
        [SerializeField] float walkingFrequency = 1.5f;
        [SerializeField] float transitionSpeed = 3f;

        private CinemachineBasicMultiChannelPerlin noise;

        void Start()
        {
            noise = fpCamera.GetComponent<CinemachineBasicMultiChannelPerlin>();
        }

        void Update()
        {
            if (fpController.CurrentSpeed > 0.1f)
            {
                noise.AmplitudeGain = Mathf.Lerp(noise.AmplitudeGain, walkingAmplitude, Time.deltaTime * transitionSpeed);
                noise.FrequencyGain = Mathf.Lerp(noise.FrequencyGain, walkingFrequency, Time.deltaTime * transitionSpeed);
            }
            else
            {
                noise.AmplitudeGain = Mathf.Lerp(noise.AmplitudeGain, 0f, Time.deltaTime * transitionSpeed);
                noise.FrequencyGain = Mathf.Lerp(noise.FrequencyGain, 0f, Time.deltaTime * transitionSpeed);
            }
        }
    }
}
