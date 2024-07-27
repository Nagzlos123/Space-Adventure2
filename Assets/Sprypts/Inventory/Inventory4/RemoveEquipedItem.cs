using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RemoveEquipedItem : MonoBehaviour
{
    public InventoryItemData itemData;

    [SerializeField] private GameObject mouseItem;
    [SerializeField] private GameObject mouseParent;
    [SerializeField] private StatsUpgradeManager upgradeManager;
    [SerializeField] private Inventory4Manager inventory4;
    public GameObject[] playerSlots;

    [SerializeField] private TextMeshProUGUI itemDescryption;
    [SerializeField] private TextMeshProUGUI itemPrice;
    [SerializeField] private TextMeshProUGUI itemNameText;
    [SerializeField] private GameObject itemIcon;



    public string itemCategory;
    public string itemSubCategory;

    public void RemoveItem()
    {

        for (int i = 0; i < playerSlots.Length; i++)
        {
            if (itemCategory == playerSlots[i].GetComponent<PlayerInvemtorySlot4>().acceptableSlotCategory
                && itemSubCategory == playerSlots[i].GetComponent<PlayerInvemtorySlot4>().acceptableSlotSubCategory && itemSubCategory != "")
            {
                inventory4.AddItem(itemData);
                inventory4.SortItemList();
                inventory4.CreateInventorySlots(itemCategory);
                playerSlots[i].GetComponent<PlayerInvemtorySlot4>().ResetPlayerSlot(itemCategory);
                upgradeManager.SubtractPlayerStats(itemCategory, itemSubCategory, itemData);
                Debug.Log("Item removed!");
            }
            if (itemCategory == playerSlots[i].GetComponent<PlayerInvemtorySlot4>().acceptableSlotCategory && itemSubCategory == "")
            {
                inventory4.AddItem(itemData);
                inventory4.SortItemList();
                inventory4.CreateInventorySlots(itemCategory);
                playerSlots[i].GetComponent<PlayerInvemtorySlot4>().ResetPlayerSlot(itemCategory);
                upgradeManager.SubtractPlayerStats(itemCategory, itemSubCategory, itemData);
                Debug.Log("Item removed!");
            }
        }
    }


    public void GetItemData()
    {
        if (itemData != null)
        {
            InventoryItemData currentItemData = itemData;
            var descryption = currentItemData.discreption;
            var price = currentItemData.itemCost;
            var itemName = currentItemData.displayName;
            itemCategory = currentItemData.itemCategory;
            itemSubCategory = currentItemData.itemSubCategory;
            itemDescryption.text = descryption;
            itemPrice.text = price.ToString();
            itemNameText.text = itemName;
            itemIcon.GetComponent<Image>().sprite = currentItemData.itemIcon;
        }
    }

    private void Update()
    {
        GetItemData();
    }
}
