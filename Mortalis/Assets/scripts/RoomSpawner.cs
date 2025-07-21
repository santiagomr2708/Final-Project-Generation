using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{

    public int openSide;

    //1 need bottom door
    //2 need top door
    //3 need left door
    //4 need right door

    private RoomTemplates templates;

    private int rand;

    private bool spawned = false;

    void Start()
    {
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        Invoke("Spawn", 0.2f);
        Destroy(gameObject, 4f);
    }

   void Spawn()
    {
        if (spawned) return;

        Vector3Int posicionGrid = Vector3Int.RoundToInt(transform.position);

        if (templates.posicionesOcupadas.Contains(posicionGrid))
        {
            spawned = true;
            Destroy(gameObject);
            return;
        }
     
        templates.posicionesOcupadas.Add(posicionGrid);

        GameObject sala = null;

        if (!templates.firstRoom)
        {
            int index = Random.Range(0, templates.allRooms.Length);
            sala = Instantiate(templates.allRooms[index], transform.position, Quaternion.identity);
            templates.firstRoom = true;
        }
        else if (!templates.bossRoomSpawned && templates.salasGeneradas == templates.numeroMaximoSalas - 1)
        {
            switch (openSide)
            {
                case 1:
                    sala = Instantiate(templates.bossRoomBottom, transform.position, Quaternion.identity);
                    break;
                case 2:
                    sala = Instantiate(templates.bossRoomTop, transform.position, Quaternion.identity);
                    break;
                case 3:
                    sala = Instantiate(templates.bossRoomLeft, transform.position, Quaternion.identity);
                    break;
                case 4:
                    sala = Instantiate(templates.bossRoomRight, transform.position, Quaternion.identity);
                    break;
            }

            templates.bossRoomSpawned = true;
        }
        else if (templates.salasGeneradas < templates.numeroMaximoSalas)
        {
            switch (openSide)
            {
                case 1:
                    rand = Random.Range(0, templates.bottomRooms.Length);
                    sala = Instantiate(templates.bottomRooms[rand], transform.position, templates.bottomRooms[rand].transform.rotation);
                    break;
                case 2:
                    rand = Random.Range(0, templates.topRooms.Length);
                    sala = Instantiate(templates.topRooms[rand], transform.position, templates.topRooms[rand].transform.rotation);
                    break;
                case 3:
                    rand = Random.Range(0, templates.rightRooms.Length);
                    sala = Instantiate(templates.rightRooms[rand], transform.position, templates.rightRooms[rand].transform.rotation);
                    break;
                case 4:
                    rand = Random.Range(0, templates.leftRooms.Length);
                    sala = Instantiate(templates.leftRooms[rand], transform.position, templates.leftRooms[rand].transform.rotation);
                    break;
            }
        }
        else
        {
            switch (openSide)
            {
                case 1:
                    rand = Random.Range(0, templates.bottomCloseRooms.Length);
                    sala = Instantiate(templates.bottomCloseRooms[rand], transform.position, templates.bottomCloseRooms[rand].transform.rotation);
                    break;
                case 2:
                    rand = Random.Range(0, templates.topCloseRooms.Length);
                    sala = Instantiate(templates.topCloseRooms[rand], transform.position, templates.topCloseRooms[rand].transform.rotation);
                    break;
                case 3:
                    rand = Random.Range(0, templates.rightCloseRooms.Length);
                    sala = Instantiate(templates.rightCloseRooms[rand], transform.position, templates.rightCloseRooms[rand].transform.rotation);
                    break;
                case 4:
                    rand = Random.Range(0, templates.leftCloseRooms.Length);
                    sala = Instantiate(templates.leftCloseRooms[rand], transform.position, templates.leftCloseRooms[rand].transform.rotation);
                    break;
            }
        }

        if (sala != null && templates.salasContenedor != null)
        {
            sala.transform.SetParent(templates.salasContenedor.transform);
            templates.salasGeneradas++;
        }

        spawned = true;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SpawPoint"))
        {
            RoomSpawner otherSpawner = other.GetComponent<RoomSpawner>();
            if (otherSpawner != null && !otherSpawner.spawned && !spawned)
            {
                Instantiate(templates.closedRoom, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            spawned = true;
        }
    }

}

