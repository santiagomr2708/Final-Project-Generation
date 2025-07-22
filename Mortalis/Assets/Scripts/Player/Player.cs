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
        [SerializeField] public int cantidadVidas = 3;
        private DatosDejuego datosDejuego;
        private DataManager dataManager;

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

        void OnFlashlight()
        {
            flashLight.LightManager();
        }

        void OnPause()
        {
            pauseMenu.TogglePause();
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
            datosDejuego = new DatosDejuego();
            dataManager = GameObject.Find("DataManager").GetComponent<DataManager>();
            dataManager.GuardarDatos();
            dataManager.CargarDatos();

        }
        void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                datosDejuego.cantidadVidas--;
                dataManager.GuardarDatos();
            }
        }


        #endregion
    }
}
