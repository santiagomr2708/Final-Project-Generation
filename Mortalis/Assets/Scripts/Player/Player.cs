using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

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
        [SerializeField] GameObject screamerCalavera;
        [SerializeField] string nameScene;

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

            dataManager = GameObject.FindAnyObjectByType<DataManager>();

            // Obtener las vidas guardadas del DataManager
            cantidadVidas = dataManager.datosDejuego.cantidadVidas;

        }

        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                cantidadVidas--;

                // Actualizar en DataManager
                dataManager.datosDejuego.cantidadVidas = cantidadVidas;
                dataManager.GuardarDatos();

                SceneManager.LoadScene(nameScene);
            }
        }
        #endregion
    }
}
