using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoonSpawInitial : MonoBehaviour
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
        templates = GameObject.FindGameObjectWithTag("RoomsInitial").GetComponent<RoomTemplates>();
        Invoke("Spawn", 0.2f);
        Destroy(gameObject, 4f);
    }

    void Spawn()
   {
    if (spawned == false)
    {
        GameObject sala = null;

        if (openSide == 1)
        {
            // need bottom door
            rand = Random.Range(0, templates.bottomRooms.Length);
            sala = Instantiate(templates.bottomRooms[rand], transform.position, templates.bottomRooms[rand].transform.rotation);
        }
        else if (openSide == 2)
        {
            // need top door
            rand = Random.Range(0, templates.topRooms.Length);
            sala = Instantiate(templates.topRooms[rand], transform.position, templates.topRooms[rand].transform.rotation);
        }
        else if (openSide == 3)
        {
            // need right door
            rand = Random.Range(0, templates.rightRooms.Length);
            sala = Instantiate(templates.rightRooms[rand], transform.position, templates.rightRooms[rand].transform.rotation);
        }
        else if (openSide == 4)
        {
            // need left door
            rand = Random.Range(0, templates.leftRooms.Length);
            sala = Instantiate(templates.leftRooms[rand], transform.position, templates.leftRooms[rand].transform.rotation);
        }

        if (sala != null && templates.salasContenedor != null)
        {
            sala.transform.SetParent(templates.salasContenedor.transform);
        }

        spawned = true;
    }
}


   
}