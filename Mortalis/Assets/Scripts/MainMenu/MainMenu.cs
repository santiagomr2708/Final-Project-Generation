using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string gameSceneName = "NombreDeTuEscena";

    public void StartGame()
    {
        SceneManager.LoadScene(gameSceneName);
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
}
