using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplates : MonoBehaviour
{
    public List<Vector3Int> posicionesOcupadas = new List<Vector3Int>();
    public GameObject salasContenedor;

    public bool bossRoomSpawned = false;

    public bool salaConectadaGenerada = false;

    public int salasGeneradas = 0;
    public int numeroMaximoSalas = 10;

    public GameObject[] topRooms;
    public GameObject[] bottomRooms;
    public GameObject[] leftRooms;
    public GameObject[] rightRooms;

    public GameObject[] topCloseRooms;
    public GameObject[] bottomCloseRooms;
    public GameObject[] leftCloseRooms;
    public GameObject[] rightCloseRooms;

    public GameObject[] allRooms;

    public GameObject bossRoomTop;
    public GameObject bossRoomBottom;
    public GameObject bossRoomLeft;
    public GameObject bossRoomRight;

    public GameObject closedRoom;

    public Transform salaInicialTransform;

    void Start()
    {
        if (salaInicialTransform != null)
        {
            Vector3Int posInicial = Vector3Int.RoundToInt(salaInicialTransform.position);
            posicionesOcupadas.Add(posInicial);
        }
        else
        {
            Debug.LogWarning("No hay sala incial, toca asignarla mijo");
        }
    }
}