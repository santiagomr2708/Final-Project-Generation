using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    private string itemName;
    private int cantidad;
    private Sprite itemSprite;
    public bool estaLleno;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField]
    private TMP_Text cantidadTexto;
    [SerializeField]
    private Image itemImage;

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

}
