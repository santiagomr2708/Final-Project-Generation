using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    public string itemName;
    private int cantidad;
    private Sprite itemSprite;
    public bool estaLleno;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField]
    private TMP_Text cantidadTexto;
    [SerializeField]
    private Image itemImage;

    public GameObject selectedSprite;
    public bool thisItemSelected;
    private InventoryManager inventoryManager;
    [SerializeField] private TMP_Text indexText;

    void Start()
    {
        inventoryManager = GameObject.Find("Canvas").GetComponent<InventoryManager>();
    }


    public void AddItem(string itemName, int cantidad, Sprite itemSprite)
    {
        this.itemName = itemName;
        this.cantidad = cantidad;
        this.itemSprite = itemSprite;
        estaLleno = true;

        cantidadTexto.text = cantidad.ToString();
        cantidadTexto.enabled = true;
        itemImage.sprite = itemSprite;
    }



    public void Select()
    {
        if (thisItemSelected)
        {
            inventoryManager.UseItem(itemName);
            this.cantidad -= 1;
            if (this.cantidad <= 0)
            {
                EmptySlot();
                
            }

        }
        else
        {
            inventoryManager.DeselectAllSlots();
            thisItemSelected = true;
            selectedSprite.SetActive(true);
        }

    }

    public void Deselect()
    {
        thisItemSelected = false;
        selectedSprite.SetActive(false);
        
    }
    public void SetIndex(int index)
    {
        if (indexText != null)
            indexText.text = index.ToString();
    }
    private void EmptySlot()
    {
        inventoryManager.itemSlot.Remove(this);

        Destroy(gameObject);
        inventoryManager.UpdateSlotIndices();
    }
 
}


