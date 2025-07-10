using Unity.Cinemachine;
using UnityEngine;

namespace Artemis
{
    [RequireComponent(typeof(CharacterController))]
    public class FirstPersonController : MonoBehaviour
    {
        [Header("Movement Parameters")]
        public float maxSpeed = 3.5f;
        public float acceleration = 15f;

        public Vector3 CurrentVelocity { get; private set; }
        public float CurrentSpeed { get; private set; }

        [Header("Looking Parameters")]
        public Vector2 lookSensitivity = new Vector2(0.1f, 0.1f);

        public float PitchLimit = 85f;

        [SerializeField] float currentPitch = 0f;

        public float CurrentPitch
        {
            get => currentPitch;

            set
            {
                currentPitch = Mathf.Clamp(value, -PitchLimit, PitchLimit);
            }
        }

        [Header("Input")]
        public Vector2 moveInput;
        public Vector2 lookInput;

        [Header("Components")]
        [SerializeField] CinemachineCamera fpCamera;
        [SerializeField] CharacterController characterController;

        #region Unity Methods

        void OnValidate()
        {
            if (characterController == null)
            {
                characterController = GetComponent<CharacterController>();
            }
        }

        void Update()
        {
            MoveUpdate();
            LookUpdate();
        }

        #endregion

        #region Controller Methods

        void MoveUpdate()
        {
            Vector3 motion = transform.forward * moveInput.y + transform.right * moveInput.x;
            motion.y = 0f;
            motion.Normalize();

            if (motion.sqrMagnitude >= 0.01f)
            {
                CurrentVelocity = Vector3.MoveTowards(CurrentVelocity, motion * maxSpeed, acceleration * Time.deltaTime);
            }
            else
            {
                CurrentVelocity = Vector3.MoveTowards(CurrentVelocity, Vector3.zero, acceleration * Time.deltaTime);
            }

            float verticalVelocity = Physics.gravity.y * 20f * Time.deltaTime;

            Vector3 fullVelocity = new Vector3(CurrentVelocity.x, verticalVelocity, CurrentVelocity.z);

            characterController.Move(fullVelocity * Time.deltaTime);

            CurrentSpeed = CurrentVelocity.magnitude;
        }

        void LookUpdate()
        {
            Vector2 input = new Vector2(lookInput.x * lookSensitivity.x, lookInput.y * lookSensitivity.y);

            // Mirando arriba y abajo
            CurrentPitch -= input.y;

            fpCamera.transform.localRotation = Quaternion.Euler(currentPitch, 0f, 0f);

            // Mirando izquierda y derecha
            transform.Rotate(Vector3.up * input.x);
        }

        #endregion
    }
}