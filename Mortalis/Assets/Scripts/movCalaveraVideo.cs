using UnityEngine;

public class movCalaveraVideo : MonoBehaviour
{
    public float velocidad = 5f;
    void Update()
    {
        transform.Translate(Vector3.back * velocidad * Time.deltaTime);
    }
}