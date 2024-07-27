using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemRemovePanel : MonoBehaviour
{
    [Header("Old")]
    
    public GameObject[] playerSlots;
    
    [SerializeField] private StatsUpgradeManager upgradeManager;
    public Inventory2Manager inventory2;
    
    [Header("Data Getter")]
    public ItemRemovePanelGetter itemDataGetter;
    private void Start()
    {
        itemDataGetter.GetItemData();
    }
    public void RemoveItem()
    {
        for (int i = 0; i < playerSlots.Length; i++)
        {

            if (itemDataGetter.itemCategory == playerSlots[i].GetComponent<PlayerInvemtorySlot>().acceptableSlotCategory 
                && itemDataGetter.itemSubCategory == playerSlots[i].GetComponent<PlayerInvemtorySlot>().acceptableSlotSubCategory
                && itemDataGetter.itemSubCategory != "")
            {
                inventory2.AddItem(itemDataGetter.itemData);
                inventory2.SortItemList();
                inventory2.CreateCorrectInventorySlots(inventory2.categoryItem);
                playerSlots[i].GetComponent<PlayerInvemtorySlot>().ResetPlayerSlot(itemDataGetter.itemCategory, itemDataGetter.itemSubCategory);
                upgradeManager.SubtractPlayerStats(itemDataGetter.itemCategory, itemDataGetter.itemSubCategory, itemDataGetter.itemData);
                Debug.Log("Item removed!");
            }
            if (itemDataGetter.itemCategory == playerSlots[i].GetComponent<PlayerInvemtorySlot>().acceptableSlotCategory 
                && itemDataGetter.itemSubCategory == "")
            {
                inventory2.AddItem(itemDataGetter.itemData);
                inventory2.SortItemList();
                inventory2.CreateCorrectInventorySlots(inventory2.categoryItem);
                playerSlots[i].GetComponent<PlayerInvemtorySlot>().ResetPlayerSlot(itemDataGetter.itemCategory);
                upgradeManager.SubtractPlayerStats(itemDataGetter.itemCategory, itemDataGetter.itemSubCategory, itemDataGetter.itemData);
                Debug.Log("Item removed!");
            }
            
        }
    }

    

    private void Update()
    {
        itemDataGetter.GetItemData();
    }
}
