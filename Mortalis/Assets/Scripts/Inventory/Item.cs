using Artemis;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private string itemName;
    [SerializeField] private int cantidad;
    [SerializeField] private Sprite sprite;

    private InventoryManager inventoryManager;

    private PlayerInteraction playerInteractionScript;
    void Start()
    {
        inventoryManager = GameObject.Find("Inventory HUD").GetComponent<InventoryManager>();
        playerInteractionScript = GameObject.Find("Player").GetComponent<PlayerInteraction>();
    }
   
    // Update is called once per frame
    void Update()
    {
        
    }
}
