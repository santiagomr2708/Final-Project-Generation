using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;
using UnityEngine.SceneManagement;

public class InventoryManager : MonoBehaviour
{
    public GameObject inventory;
    public bool isInventoryOn;
    public List<ItemSlot> itemSlot = new List<ItemSlot>();
    public Transform hudSlotParent;
    public GameObject slotPrefab;
    
    private ItemSlot itemSlotScript;


    public So[] ItemSos;

    void Start()
    {
        
        itemSlotScript = GameObject.Find("ConditionsManager").GetComponent<ItemSlot>();
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
        for (int i = 0; i < itemSlot.Count && i < 9; i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1 + i))
            {
                SelectSlot(i);
            }
        }
    }
    public void UseItem(string itemName)
    {
        for (int i = 0; i < ItemSos.Length; i++)
        {
            if (ItemSos[i].itemName == itemName)
            {
                ItemSos[i].UseItem();
            }
        }
    }
    public void AddItem(string itemName, int cantidad, Sprite sprite)
    {

        for (int i = 0; i < itemSlot.Count; i++)
        {
            if (!itemSlot[i].estaLleno)
            {
                itemSlot[i].AddItem(itemName, cantidad, sprite);
                return;
            }
        }

        GameObject newSlotGo = Instantiate(slotPrefab, hudSlotParent);
        ItemSlot newSlot = newSlotGo.GetComponent<ItemSlot>();

        if (newSlot != null)
        {

            newSlot.AddItem(itemName, cantidad, sprite);
            itemSlot.Add(newSlot);
            newSlot.SetIndex(itemSlot.Count);
        }
    }
    public void DeselectAllSlots()
    {
        for (int i = 0; i < itemSlot.Count; i++)
        {
            itemSlot[i].selectedSprite.SetActive(false);
            itemSlot[i].thisItemSelected = false;
        }
    }

    void SelectSlot(int index)
    {
        for (int i = 0; i < itemSlot.Count; i++)
        {
            if (i == index)
            {
                itemSlot[i].Select();
             
            }
            else
            {
                
                itemSlot[i].Deselect();
            }
        }
    }
    public void UpdateSlotIndices()
    {
    for (int i = 0; i < itemSlot.Count; i++)
    {
        itemSlot[i].SetIndex(i + 1); // Mostrar como 1, 2, 3...
    }
    }
   
}
