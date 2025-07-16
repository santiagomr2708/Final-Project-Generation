using UnityEngine;

public class EyeSpawner : MonoBehaviour
{
    public GameObject[] ojos;
   
    public int minPorPared = 1;
    public int maxPorPared = 5;

    void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            Vector3 position = new Vector3(
                transform.position.x,
                Random.Range(-10.0f, 10.0f),
                Random.Range(-10.0f, 10.0f)
            );

            GameObject instance = Instantiate(ojos[0], position, Quaternion.identity);
        }
    }
}
