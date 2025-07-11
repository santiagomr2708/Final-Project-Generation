using UnityEngine;
using UnityEngine.UIElements;

public class InventoryManager : MonoBehaviour
{
    public GameObject inventory;
    public bool isInventoryOn;
    public ItemSlot[] itemSlot;
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
    public void AddItem(string itemName, int cantidad, Sprite sprite)
    {
        for (int i = 0; i < itemSlot.Length; i++)
        {
            if (itemSlot[i].estaLleno == false)
            {
                itemSlot[i].AddItem(itemName, cantidad, sprite);
                return;
            }
        }
    }
}
