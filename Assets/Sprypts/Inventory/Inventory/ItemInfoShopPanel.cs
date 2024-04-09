using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemInfoShopPanel : MonoBehaviour
{
    public InventoryItemData itemData;
    [SerializeField] private TextMeshProUGUI itemName;
    [SerializeField] private TextMeshProUGUI itemDescryption;
    [SerializeField] private TextMeshProUGUI itemPrice;
    [SerializeField] private GameObject itemIcon;

    public void GetItemData()
    {
        InventoryItemData currentItemData = itemData;
        string name = currentItemData.displayName; 
        string descryption = currentItemData.discreption;
        float price = currentItemData.itemCost;
        itemName.text = name;
        itemDescryption.text = descryption;
        itemPrice.text = price.ToString();
        itemIcon.GetComponent<Image>().sprite = currentItemData.itemIcon;
    }
}
