using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
public class Inventory4Manager : MonoBehaviour
{

    public List<InventoryItemData> InventoryItems = new List<InventoryItemData>();
    [SerializeField] private GameObject inventortSlotParent;
    [SerializeField] private Transform inventortSlotList;
    [SerializeField] private GameObject mouseItem;
    [SerializeField] private GameObject mouseParent;
    [SerializeField] private GameObject equipItemPanel;
    [SerializeField] private GameObject noItemMach;
    [SerializeField] private EquipItemManager equipRemoveItem;
    public string itemCategory;

    private void Start()
    {
        CreateInventorySlots();
    }
    public void AddItem(InventoryItemData itemData)
    {

        InventoryItems.Add(itemData);
    }

    public void RemoveItem(InventoryItemData itemData)
    {
        InventoryItems.Remove(itemData);
    }
    public void SortItemList()
    {
        
        var sortedList = InventoryItems.OrderBy(go => go.name).ToList();
        InventoryItems = sortedList;

    }

    public void CreateInventorySlots(string itemCategory)
    {
        foreach (Transform item in inventortSlotList)
        {
            Destroy(item.gameObject);
        }

        foreach (var item in InventoryItems)
        {
            if (item.itemCategory == itemCategory)
            {
                GameObject newItemSlot = Instantiate(inventortSlotParent, inventortSlotList);
                var itemIcon = newItemSlot.transform.GetChild(0).transform.Find("ItemIcon").GetComponent<Image>();
               
                newItemSlot.transform.GetChild(1).GetComponent<ItemInfoShopPanel>().itemData = item;
                SetSlot4ItemData(item, newItemSlot, mouseItem, mouseParent, equipRemoveItem);
                SetSlot4ItemPanels(newItemSlot, equipItemPanel, noItemMach);
                itemIcon.sprite = item.itemIcon;

            }

        }
    }

    public void CreateInventorySlots()
    {
        foreach (Transform item in inventortSlotList)
        {
            Destroy(item.gameObject);
        }

        foreach (var item in InventoryItems)
        {

            GameObject newItemSlot = Instantiate(inventortSlotParent, inventortSlotList);
            var itemIcon = newItemSlot.transform.GetChild(0).transform.Find("ItemIcon").GetComponent<Image>();
            
            newItemSlot.transform.GetChild(1).GetComponent<ItemInfoShopPanel>().itemData = item;
            SetSlot4ItemData(item, newItemSlot, mouseItem, mouseParent, equipRemoveItem);
            SetSlot4ItemPanels(newItemSlot, equipItemPanel, noItemMach);
            itemIcon.sprite = item.itemIcon;

        }
    }

    public void SetSlot4ItemPanels(GameObject itemSlotUI, GameObject equipItemPanel, GameObject noItemMach)
    {
        itemSlotUI.transform.GetChild(0).GetComponent<Inventory4ItemSlotUI>().equipItemPanel = equipItemPanel;
        itemSlotUI.transform.GetChild(0).GetComponent<Inventory4ItemSlotUI>().noItemMach = noItemMach;
    }

    public void SetSlot4ItemData(InventoryItemData itemData, GameObject itemSlotUI)
    {
        itemSlotUI.transform.GetChild(0).GetComponent<Inventory4ItemSlotUI>().itemData = itemData;
        
    }


    public void SetSlot4ItemData(InventoryItemData itemData, GameObject itemSlotUI, GameObject mouseItem)
    {
        itemSlotUI.transform.GetChild(0).GetComponent<Inventory4ItemSlotUI>().itemData = itemData;
        itemSlotUI.transform.GetChild(0).GetComponent<Inventory4ItemSlotUI>().mouseItem = mouseItem;
    }

    public void SetSlot4ItemData(InventoryItemData itemData, GameObject itemSlotUI, GameObject mouseItem, GameObject mouseParent, EquipItemManager equipRemoveItem)
    {
        itemSlotUI.transform.GetChild(0).GetComponent<Inventory4ItemSlotUI>().itemData = itemData;
        itemSlotUI.transform.GetChild(0).GetComponent<Inventory4ItemSlotUI>().mouseItem = mouseItem;
        itemSlotUI.transform.GetChild(0).GetComponent<Inventory4ItemSlotUI>().mouseParent = mouseParent;
        itemSlotUI.transform.GetChild(0).GetComponent<Inventory4ItemSlotUI>().equipRemoveItem = equipRemoveItem;
    }
    public void SlotClicked(Inventory4ItemSlotUI clickedUISlot)
    {
       
        Debug.Log("Slot clicked!" + clickedUISlot);
       

    }
}
