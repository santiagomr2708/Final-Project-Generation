using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplates : MonoBehaviour
{
    [HideInInspector]
    public bool firstRoom = false;

    public GameObject bossRoomBottom;
    public GameObject bossRoomTop;
    public GameObject bossRoomLeft;
    public GameObject bossRoomRight;

    [HideInInspector]
    public bool bossRoomSpawned = false;

    public GameObject[] allRooms;

    public GameObject[] bottomRooms;
    public GameObject[] topRooms;
    public GameObject[] leftRooms;
    public GameObject[] rightRooms;

    public GameObject[] bottomCloseRooms;
    public GameObject[] topCloseRooms;
    public GameObject[] leftCloseRooms;
    public GameObject[] rightCloseRooms;

    public GameObject closedRoom;

    public GameObject salasContenedor;


    [Header("Límites de generación")]
    public int numeroMaximoSalas = 10;
    [HideInInspector]
    public int salasGeneradas = 0;

    void Start()
    {
        salasContenedor = new GameObject("SalasContenedor");
    }
}