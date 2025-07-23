using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    public int openSide;

    private RoomTemplates templates;
    private int rand;
    private bool spawned = false;

    void Start()
    {
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();

        Vector3Int posicionGrid = Vector3Int.RoundToInt(transform.position);

        if (templates.posicionesOcupadas.Contains(posicionGrid))
        {
            spawned = true;
            Destroy(gameObject);
            return;
        }

        templates.posicionesOcupadas.Add(posicionGrid);

        Invoke("Spawn", 0.2f);
        Destroy(gameObject, 4f);
    }

    void Spawn()
    {
        if (spawned) return;

        GameObject sala = null;

        /// la primera sala, despues de la sala inicial claro
        if (!templates.salaConectadaGenerada)
        {
            int index = Random.Range(0, templates.allRooms.Length);
            sala = Instantiate(templates.allRooms[index], transform.position, Quaternion.identity);
            templates.salaConectadaGenerada = true;
        }
        /// generaciuon de slaa de enemigo (no pregunten por que dice boss, lo comence asi y asi quedo)
        else if (!templates.bossRoomSpawned && templates.salasGeneradas >= templates.numeroMaximoSalas - 1)
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
        /// generacion de las demas salas
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
        /// cerrar las habitacione que quedaron abiertas.
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
}
