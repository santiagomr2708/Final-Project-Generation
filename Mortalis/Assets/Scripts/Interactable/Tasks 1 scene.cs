using UnityEngine;

public class Tasks1scene : MonoBehaviour
{
    public bool lucesApagadas = false;
    public int cantidadLuces;
  
    void Update()
    {
        if (cantidadLuces == 2)
        {
            lucesApagadas = true;
        }
    }
}
