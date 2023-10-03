using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.Events;

public class Inventory3Maneger : MonoBehaviour
{
    public List<InventoryItemData> Items = new List<InventoryItemData>();

    [SerializeField] private GameObject[] itemsSlotsUI;

    public GameObject inventoryItem;
    public Transform itemContent;

    public GameObject currentSlotUI;
    public UnityAction<InventorySlot> OnInventoryChanged;
    public List<InventorySlot> inventorySlotsP;

    //[SerializeField] private GameObject itemIcon;

    public void AddItem(InventoryItemData itemData)
    {
        Items.Add(itemData);
    }

    public void RemoveItem(InventoryItemData itemData)
    {
        Items.Remove(itemData);
    }

    public void ListOfItems()
    {
        foreach (var item in Items)
        {
            for (int itemSlotUI = 0; itemSlotUI < Items.Count; itemSlotUI++)
            {
                AddItemToInventory(item, itemsSlotsUI[itemSlotUI]);
            }
            

            //GameObject itemObject = Instantiate(inventoryItem, itemContent);
            //var itemIcon = itemObject.transform.Find("ItemIcon").GetComponent<Image>();
            //itemIcon.sprite = 
        }
    }

    public void AddItemToInventory(InventoryItemData itemData, GameObject itemSlotUI)
    {
        itemSlotUI.GetComponent<Inventory3ItemSlotUI>().itemData = itemData;
        //itemSlotUI.GetComponent<Inventory3ItemSlotUI>().transform.GetChild(1).gameObject.SetActive(true);


        //itemData = itemSlotUI.GetComponent<Inventory3ItemSlotUI>().itemData;
    }

    public void RemoveItemFromInventory(InventoryItemData itemData, GameObject itemSlotUI)
    {
        if (itemSlotUI.GetComponent<Inventory3ItemSlotUI>().itemData == itemData)
        {
            itemSlotUI.GetComponent<Inventory3ItemSlotUI>().itemData = null;
        }
    }

    public void SlotClicked(Inventory3ItemSlotUI clickedUISlot)
    {
        //currentItemData = clickedUISlot.itemData; 
        Debug.Log("Slot clicked!" + clickedUISlot);
        //currentSlotUI.GetComponent<Inventory3ItemSlotUI>() = clickedUISlot;

    }

    public bool ContainsItem(InventoryItemData itemToAdd, out List<InventorySlot> inventorySlots)
    {
        inventorySlots = inventorySlotsP.Where(i => i.ItemData == itemToAdd).ToList();
        return inventorySlots == null ? false : true; // If list hava a at least 1 item return true else false 
    }

    public bool HaveFreeSlot(out InventorySlot freeSlot)
    {
        freeSlot = inventorySlotsP.FirstOrDefault(i => i.ItemData == null);
        return freeSlot == null ? false : true;
    }
}
