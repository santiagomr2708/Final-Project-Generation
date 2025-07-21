using System.Runtime.ExceptionServices;
using Artemis;
using UnityEngine;

public class BedSleep : MonoBehaviour
{
    FirstPersonController firstPersonController;
    GameObject player;
    bool sleeping = false;
    Vector3 targetPosition = new Vector3(-2.168f, 1.5f, 0.887f);
    Tasks1scene tasks1Scene;
    
    void Start()
    {
        player = GameObject.Find("Player");
        firstPersonController = player.GetComponent<FirstPersonController>();
        tasks1Scene = GameObject.Find("GameManager").GetComponent<Tasks1scene>();
        
        
    }

    void Update()
    {
        if (sleeping)
        {
            firstPersonController.enabled = false;
            var target = Quaternion.Euler(-90, 90, 0);
            player.transform.rotation = Quaternion.Slerp(player.transform.rotation, target, Time.deltaTime * 5);
            if (Quaternion.Angle(player.transform.rotation, target) < 1f)
            {
                player.transform.rotation = target;
            }
            player.transform.position = Vector3.Lerp(player.transform.position, targetPosition, Time.deltaTime * 1);
            if (Vector3.Distance(player.transform.position, targetPosition) < 0.01f)
            {
                player.transform.position = targetPosition;
            }        
		}
    }

    public void GoingToSleep()
    {
        if (tasks1Scene.lucesApagadas)
        {
            sleeping = true;

        }
    }

}
