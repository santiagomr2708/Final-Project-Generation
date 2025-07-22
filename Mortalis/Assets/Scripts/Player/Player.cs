using UnityEngine;
using UnityEngine.InputSystem;

namespace Artemis
{
    [RequireComponent(typeof(FirstPersonController))]
    public class Player : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] FirstPersonController FPController;
        [SerializeField] PauseMenu pauseMenu;
        [SerializeField] FlashLight flashLight;

        #region Input Handling

        void OnMove(InputValue value)
        {
            FPController.moveInput = value.Get<Vector2>();
        }

        void OnLook(InputValue value)
        {
            if (pauseMenu.isPaused) return;
            FPController.lookInput = value.Get<Vector2>();
        }

        void OnPause()
        {
            pauseMenu.TogglePause();
        }

        void OnFlashlight()
        {
            flashLight.LightManager();
        }

        #endregion

        #region Unity Methods

        void OnValidate()
        {
            if (FPController == null) FPController = GetComponent<FirstPersonController>();
        }

        void Start()
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

        #endregion
    }
}
