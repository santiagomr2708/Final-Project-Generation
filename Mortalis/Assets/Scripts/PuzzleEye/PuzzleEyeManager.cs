using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PuzzleEyeManager : MonoBehaviour
{
    private EyeSpawner[] eyeSpawner;
    public int eyeCount;
    [SerializeField] string sceneName;

    void Start()
    {
        StartCoroutine(FindSpawnersAfterDelay(5f));
    }

    IEnumerator FindSpawnersAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        eyeSpawner = Object.FindObjectsByType<EyeSpawner>(FindObjectsSortMode.None);
    }

    void Update()
    {
        int totalEyes = 0;
        foreach (EyeSpawner spawner in eyeSpawner)
        {
            totalEyes += spawner.cantidadRealOjos;
        }

        if (totalEyes == eyeCount)
        {
            SceneManager.LoadScene(sceneName);
        }

    }
}
