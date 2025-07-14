using UnityEngine;

public class EnemieDesapear : MonoBehaviour
{
    [SerializeField] GameObject enemie;
    [SerializeField] float maxTimer = 4f;
    float timer;

    void Start()
    {
        timer = maxTimer;
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            timer = maxTimer;
            enemie.SetActive(!enemie.activeSelf);
        }
    }
}
