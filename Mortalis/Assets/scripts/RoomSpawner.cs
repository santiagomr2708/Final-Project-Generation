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
        if (spawned==false)
        {
            if(openSide==1)
            {
                //need bottom door
                rand = Random.Range(0, templates.bottomRooms.Length);
                Instantiate(templates.bottomRooms[rand], transform.position, templates.bottomRooms[rand].transform.rotation);
            }
            else if(openSide==2)
            {
                //need top door
                rand = Random.Range(0, templates.topRooms.Length);
                Instantiate(templates.topRooms[rand], transform.position, templates.topRooms[rand].transform.rotation);
            }
            else if(openSide==3)
            {
                //need right door
                rand = Random.Range(0, templates.rightRooms.Length);
                Instantiate(templates.rightRooms[rand], transform.position, templates.rightRooms[rand].transform.rotation);
            }
            else if(openSide==4)
            {          
                //need left door
                rand = Random.Range(0, templates.leftRooms.Length);
                Instantiate(templates.leftRooms[rand], transform.position, templates.leftRooms[rand].transform.rotation);
            }
            spawned = true;
        }

        
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