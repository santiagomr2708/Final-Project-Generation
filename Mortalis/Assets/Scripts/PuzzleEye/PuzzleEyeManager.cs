using UnityEngine;
using UnityEngine.SceneManagement;

public class PuzzleEyeManager : MonoBehaviour
{
    private FlashLight flashLight;
    private EyeSpawner eyeSpawner;
    public int eyeCount;
    [SerializeField] string sceneName;

    void Start()
    {
        eyeSpawner = GameObject.Find("Eye Spawner").GetComponent<EyeSpawner>();
        flashLight = GameObject.Find("FlashLight").GetComponent<FlashLight>();
    }

    void Update()
    {
        if (eyeSpawner.cantidadRealOjos == eyeCount )
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
