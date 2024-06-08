using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class ItemInfoShopPanelGetter : IteamDataGetter
{
    [SerializeField] private TextMeshProUGUI itemDescryption;
    [SerializeField] private TextMeshProUGUI itemPrice;
    public override void GetItemData()
    {
        if (itemData != null)
        {
            InventoryItemData currentItemData = itemData;
            string name = currentItemData.displayName;
            string descryption = currentItemData.discreption;
            float price = currentItemData.itemCost;
            itemName.text = name;
            itemDescryption.text = descryption;
            itemPrice.text = price.ToString();
            itemIcon.GetComponent<Image>().sprite = currentItemData.itemIcon;
            underlayColor = currentItemData.underlayColor;
            underlay.GetComponent<Image>().color = currentItemData.underlayColor;
        }
    }
}
