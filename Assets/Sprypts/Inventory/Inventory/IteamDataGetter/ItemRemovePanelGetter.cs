using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class ItemRemovePanelGetter : IteamDataGetter
{
    [SerializeField] private TextMeshProUGUI itemDescryption;
    [SerializeField] private TextMeshProUGUI itemPrice;
    public string itemSubCategory;
    public override void GetItemData()
    {
        if (itemData != null)
        {
            InventoryItemData currentItemData = itemData;
            var descryption = currentItemData.discreption;
            var price = currentItemData.itemCost;
            itemCategory = currentItemData.itemCategory;
            itemSubCategory = currentItemData.itemSubCategory;
            itemDescryption.text = descryption;
            itemPrice.text = price.ToString();

            itemIcon.GetComponent<Image>().sprite = currentItemData.itemIcon;
            underlayColor = currentItemData.underlayColor;
            underlay.GetComponent<Image>().color = currentItemData.underlayColor;
        }

  
    }
}
