using UnityEngine;
using UnityEngine.UIElements;

public class InventoryManager : MonoBehaviour
{
    public GameObject inventory;
    public bool isInventoryOn;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && isInventoryOn)
        {
            inventory.SetActive(false);
            isInventoryOn = false;
        }
        else if (Input.GetKeyDown(KeyCode.Tab) && !isInventoryOn)
        {
            inventory.SetActive(true);
            isInventoryOn = true;
        }
    }
}
