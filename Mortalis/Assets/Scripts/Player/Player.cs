using UnityEngine;
using UnityEngine.InputSystem;

namespace Artemis
{
    [RequireComponent(typeof(FirstPersonController))]
    public class Player : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] FirstPersonController FPController;

        #region Input Handling

        void OnMove(InputValue value)
        {
            FPController.moveInput = value.Get<Vector2>();
        }

        void OnLook(InputValue value)
        {
            FPController.lookInput = value.Get<Vector2>();
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
