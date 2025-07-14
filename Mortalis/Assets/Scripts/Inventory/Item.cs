using Artemis;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private string itemName;
    [SerializeField] private int cantidad;
    [SerializeField] private Sprite sprite;

    private InventoryManager inventoryManager;

    
    void Start()
    {
        inventoryManager = GameObject.Find("Canvas").GetComponent<InventoryManager>();
        
    }

    // Update is called once per frame
    public void AddInventory()
    {
        inventoryManager.AddItem(itemName, cantidad, sprite);
        Destroy(gameObject);
        
    }
}
