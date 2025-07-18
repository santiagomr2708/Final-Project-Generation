using UnityEngine;

public class spawn : MonoBehaviour
{
    public GameObject ojos;
    void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            Vector3 position = new Vector3(
                transform.position.x,
                Random.Range(-10.0f, 10.0f),
                Random.Range(-10.0f, 10.0f)
            );

            GameObject instance = Instantiate(ojos, position, Quaternion.identity);
        }
    }
}
