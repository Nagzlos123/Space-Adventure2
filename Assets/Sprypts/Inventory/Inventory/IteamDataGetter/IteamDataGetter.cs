using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class IteamDataGetter
{
    public InventoryItemData itemData;
    [SerializeField] protected TextMeshProUGUI itemName;
    [SerializeField] protected GameObject itemIcon;
    [SerializeField] protected GameObject underlay;

    public string itemCategory;
    public Color underlayColor;
    public virtual void GetItemData()
    {
        if (itemData != null)
        {
            InventoryItemData currentItemData = itemData;
            string name = currentItemData.displayName;
            itemCategory = currentItemData.itemCategory;
            itemName.text = name;
            //price = currentItemData.itemCost;


            itemIcon.GetComponent<Image>().sprite = currentItemData.itemIcon;
        }
    }
}
