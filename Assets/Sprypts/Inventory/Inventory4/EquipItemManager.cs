using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class EquipItemManager : MonoBehaviour
{
    public InventoryItemData itemData;
    public InventoryItemData itemDataEquiped;
   [SerializeField] private GameObject mouseItem;
    [SerializeField] private GameObject mouseParent;
    [SerializeField] private StatsUpgradeManager upgradeManager;
    [SerializeField] private Inventory4Manager inventory4;
    public GameObject[] playerSlots;



    public string itemCategory;
    public string itemSubCategory;


    public void EquipItem()
    {
        for (int i = 0; i < playerSlots.Length; i++)
        {
            if(itemCategory == playerSlots[i].GetComponent<PlayerInvemtorySlot4>().acceptableSlotCategory 
                && itemSubCategory == playerSlots[i].GetComponent<PlayerInvemtorySlot4>().acceptableSlotSubCategory && itemSubCategory != "")
            {
                if (playerSlots[i].GetComponent<PlayerInvemtorySlot4>().itemData == null)
                {
                    Debug.Log("Item equiped!");
                    playerSlots[i].GetComponent<PlayerInvemtorySlot4>().SetEquiptItemIcon(itemCategory, itemSubCategory, itemData);
                    inventory4.RemoveItem(itemData);
                    inventory4.SortItemList();
                    inventory4.CreateInventorySlots(itemCategory);
                    upgradeManager.AddPlayerStats(itemCategory, itemSubCategory, itemData);
                    mouseItem.GetComponent<MouseItemData4>().itemData = null;
                    mouseItem.SetActive(false);
                }
                else
                {
                    inventory4.AddItem(playerSlots[i].GetComponent<PlayerInvemtorySlot4>().itemData);
                    inventory4.SortItemList();
                    upgradeManager.SubtractPlayerStats(itemCategory, itemSubCategory, itemData);
                    Debug.Log("Item equiped!");
                    playerSlots[i].GetComponent<PlayerInvemtorySlot4>().SetEquiptItemIcon(itemCategory, itemSubCategory, itemData);
                    inventory4.RemoveItem(itemData);
                    inventory4.SortItemList();
                    inventory4.CreateInventorySlots(itemCategory);
                    upgradeManager.AddPlayerStats(itemCategory, itemSubCategory, itemData);
                    mouseItem.GetComponent<MouseItemData4>().itemData = null;
                    mouseItem.SetActive(false);
                }
            }

          

            if (itemCategory == playerSlots[i].GetComponent<PlayerInvemtorySlot4>().acceptableSlotCategory && itemSubCategory == "")
            {
                if (playerSlots[i].GetComponent<PlayerInvemtorySlot4>().itemData == null)
                {
                    Debug.Log("Item equiped!");
                    playerSlots[i].GetComponent<PlayerInvemtorySlot4>().SetEquiptItemIcon(itemCategory, itemSubCategory, itemData);
                    inventory4.RemoveItem(itemData);
                    inventory4.SortItemList();
                    inventory4.CreateInventorySlots(itemCategory);
                    upgradeManager.AddPlayerStats(itemCategory, itemSubCategory, itemData);
                    mouseItem.GetComponent<MouseItemData4>().itemData = null;
                    mouseItem.SetActive(false);
                    mouseParent.SetActive(false);
                }
                else
                {
                    inventory4.AddItem(playerSlots[i].GetComponent<PlayerInvemtorySlot4>().itemData);
                    inventory4.SortItemList();
                    upgradeManager.SubtractPlayerStats(itemCategory, itemSubCategory, itemData);
                    Debug.Log("Item equiped!");
                    playerSlots[i].GetComponent<PlayerInvemtorySlot4>().SetEquiptItemIcon(itemCategory, itemSubCategory, itemData);
                    inventory4.RemoveItem(itemData);
                    inventory4.SortItemList();
                    inventory4.CreateInventorySlots(itemCategory);
                    upgradeManager.AddPlayerStats(itemCategory, itemSubCategory, itemData);
                    mouseItem.GetComponent<MouseItemData4>().itemData = null;
                    mouseItem.SetActive(false);
                    mouseParent.SetActive(false);
                }
            }

        
        }
            
            
    }

    public void GetItemDataCategory()
    {
        if (itemData != null)
        {
            InventoryItemData currentItemData = itemData;
            itemCategory = currentItemData.itemCategory;
            itemSubCategory = currentItemData.itemSubCategory;
        }
    }


    private void MouseOf()
    {
        if (Input.GetMouseButtonDown(1))
        {
            mouseItem.GetComponent<MouseItemData4>().itemData = null;
            mouseItem.SetActive(false);
            mouseParent.SetActive(false);
            if(mouseParent.activeSelf == false)
            {
                //mouseParent.transform.GetChild(1).gameObject.SetActive(false);
                //mouseParent.transform.GetChild(2).gameObject.SetActive(false);
            }
        }
    }

    private void Update()
    {
        MouseOf();
        GetItemDataCategory();
     

   
    }
}
