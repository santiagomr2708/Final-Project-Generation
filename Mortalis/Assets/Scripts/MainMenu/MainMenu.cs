using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [Header("Scene settings")]
    [SerializeField] string gameSceneName;

    [Header("Panels")]
    [SerializeField] GameObject mainPanelButtons;
    [SerializeField] GameObject panelSettings;

    [Header("Selectable buttons")]
    [SerializeField] GameObject masterButtom;
    [SerializeField] GameObject settingsButtom;

    void Start()
    {
        panelSettings.SetActive(false);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Nicolas 1");
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        // Esto detiene el juego en el Editor
        UnityEditor.EditorApplication.isPlaying = false;
#else
            // Esto cierra el juego en la build
            Application.Quit();
#endif
    }

    public void SettingsGame()
    {
        panelSettings.SetActive(!panelSettings.activeSelf);
        mainPanelButtons.SetActive(!mainPanelButtons.activeSelf);

        if (!panelSettings.activeSelf)
        {
            EventSystem.current.SetSelectedGameObject(settingsButtom);
        }
        else
        {
            EventSystem.current.SetSelectedGameObject(masterButtom);
        }
    }
}
