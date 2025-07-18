using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [Header("Scene Settings")]
    [SerializeField] string gameSceneName;


    [Header("Panels")]
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject panelSettings;

    [Header("Selectable Buttoms")]
    [SerializeField] GameObject continueButtom;
    [SerializeField] GameObject settingsButtom;
    [SerializeField] GameObject masterButtom;

    public bool isPaused = false;

    void Start()
    {
        isPaused = false;
        pauseMenu.SetActive(false);
        panelSettings.SetActive(false);
    }

    public void TogglePause()
    {
        isPaused = !isPaused;

        if (!isPaused)
        {
            panelSettings.SetActive(false);
        }

        pauseMenu.SetActive(isPaused);
        Time.timeScale = isPaused ? 0f : 1f;

        if (isPaused)
        {
            EventSystem.current.SetSelectedGameObject(continueButtom);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    public void ToggleSettings()
    {
        panelSettings.SetActive(!panelSettings.activeSelf);
        pauseMenu.SetActive(!pauseMenu.activeSelf);

        if (!panelSettings.activeSelf)
        {
            EventSystem.current.SetSelectedGameObject(settingsButtom);
        }
        else
        {
            EventSystem.current.SetSelectedGameObject(masterButtom);
        }
    }

    public void ReturnMainMenu()
    {
        SceneManager.LoadScene(gameSceneName);
    }
}
