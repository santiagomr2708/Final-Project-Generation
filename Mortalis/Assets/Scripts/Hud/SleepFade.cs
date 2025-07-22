using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SleepFade : MonoBehaviour
{
    public Image fadeImage; 
    public float fadeSpeed = 1f; 
    private bool sleeping = false;
    private bool sceneLoading = false;
    Tasks1scene tasks1Scene;
    [SerializeField] string sceneToLoad;
    void Start()
    {
        tasks1Scene = GameObject.Find("GameManager").GetComponent<Tasks1scene>();
    }
    void Update()
    {
        if (sleeping && fadeImage != null)
        {
            Color currentColor = fadeImage.color;
            float newAlpha = Mathf.MoveTowards(currentColor.a, 1f, Time.deltaTime * fadeSpeed);
            fadeImage.color = new Color(currentColor.r, currentColor.g, currentColor.b, newAlpha);

            if (newAlpha >= 1f && !sceneLoading)
            {
                sceneLoading = true;
                SceneManager.LoadScene(sceneToLoad);
            }
        }
        
    }

    public void GoingToSleep()
    {
        if (tasks1Scene.lucesApagadas)
        {
            sleeping = true;
        }
    }
}