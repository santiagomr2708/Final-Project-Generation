
using UnityEngine;



public class EyeSpawner : MonoBehaviour
{
    public GameObject ojo;                        
    public Collider[] zonas;                      
    public int cantidadTotalDeOjos;        
    public float separacionDesdeSuperficie = 0.3f;
    public int cantidadRealOjos;
    public float radioColision = 0.2f;
    public LayerMask capasDetectables;            

    void Start()
    {
        cantidadTotalDeOjos = Random.Range(10, 20);
        int ojosPorZona = Mathf.Max(1, cantidadTotalDeOjos / zonas.Length);
        Debug.Log("Ojos por zona " + ojosPorZona);
        
       

        foreach (Collider zona in zonas)
        {
            for (int i = 0; i < ojosPorZona; i++)
            {
                Vector3 posicion = ObtenerPosicionAleatoriaDentroDelCollider(zona);
                Vector3 direccionFrontal = zona.transform.forward;
                Vector3 posicionFinal = posicion + direccionFrontal * separacionDesdeSuperficie;

                Quaternion rotacionAleatoria = Random.rotation;

                if (!Physics.CheckSphere(posicionFinal, radioColision, capasDetectables))
                {
                    Instantiate(ojo, posicionFinal, rotacionAleatoria);
                    cantidadRealOjos++;
                }
                else
                {
                    Debug.Log("Ojo no instanciado por colisión.");
                }
            }
        }
    }
   

    Vector3 ObtenerPosicionAleatoriaDentroDelCollider(Collider col)
    {
        Bounds bounds = col.bounds;
        Vector3 punto;
        int intentos = 0;

        do
        {
            float x = Random.Range(bounds.min.x, bounds.max.x);
            float y = Random.Range(bounds.min.y, bounds.max.y);
            float z = Random.Range(bounds.min.z, bounds.max.z);

            punto = new Vector3(x, y, z);
            intentos++;
        }
        while (!col.bounds.Contains(punto) && intentos < 10);

        return punto;
    }
}