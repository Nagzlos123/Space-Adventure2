using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class ItemEquipSellPanelGetter : IteamDataGetter
{
    [SerializeField] private TextMeshProUGUI itemDescryption;
    [SerializeField] private TextMeshProUGUI itemPrice;

    public string itemSubCategory;
    public float price;

    [SerializeField] private StatsUpgradeManager upgradeManager;
    public override void GetItemData()
    {
        if (itemData != null)
        {
            InventoryItemData currentItemData = itemData;
            var descryption = currentItemData.discreption;
            itemCategory = currentItemData.itemCategory;
            itemSubCategory = currentItemData.itemSubCategory;
            price = currentItemData.itemCost;
            itemDescryption.text = descryption;
            itemPrice.text = price.ToString();

            itemIcon.GetComponent<Image>().sprite = currentItemData.itemIcon;
            underlayColor = currentItemData.underlayColor;
            underlay.GetComponent<Image>().color = currentItemData.underlayColor;
        }
    }
}
