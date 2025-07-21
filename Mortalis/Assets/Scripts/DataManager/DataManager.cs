using UnityEngine;
using System.IO;
using Artemis;

public class DataManager : MonoBehaviour
{
    public Player player;
    public string dataGuardado;
    public DatosDejuego datosDejuego = new DatosDejuego();
    private void Awake()
    {
        dataGuardado = Application.dataPath + "/GameData.json";
        player = GameObject.Find("Player").GetComponent<Player>();

    }
    public void CargarDatos()
    {
        if (File.Exists(dataGuardado))
        {
            string contenido = File.ReadAllText(dataGuardado);
            datosDejuego = JsonUtility.FromJson<DatosDejuego>(contenido);

        }
        else
        {
            Debug.Log("No existe");
        }
    }
    public void GuardarDatos()
    {
        DatosDejuego nuevosDatos = new DatosDejuego()
        {
            cantidadVidas = player.cantidadVidas
        };
        string cadenaJSON = JsonUtility.ToJson(nuevosDatos);

        File.WriteAllText(dataGuardado, cadenaJSON);
        Debug.Log("Archivo Guardado");
    }

}
