using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class AddRemoveShopItemGetter : IteamDataGetter
{
    public override void GetItemData()
    {
        if (itemData != null)
        {
            InventoryItemData currentItemData = itemData;
            string name = currentItemData.displayName;
            itemCategory = currentItemData.itemCategory;
            itemName.text = name;
            
            itemIcon.GetComponent<Image>().sprite = currentItemData.itemIcon;
            underlayColor = currentItemData.underlayColor;
            underlay.GetComponent<Image>().color = currentItemData.underlayColor;
        }
    }
}
