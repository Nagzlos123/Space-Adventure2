using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class Inventory2Manager : MonoBehaviour
{
    
    public List<InventoryItemData> Items = new List<InventoryItemData>();
    public List<InventoryItemData> tmpList = new List<InventoryItemData>();

    [SerializeField] private GameObject[] itemsSlotsUI;
    [SerializeField] private GameObject emptyListInfo;

    [SerializeField] private GameObject itemEquipSellPanel = null;
    [SerializeField] private GameObject itemRemovePanel = null;

    public GameObject inventorySlotParent;
    public Transform itemContent;

    //[SerializeField] private GameObject itemIcon;
    private void Start()
    {
        CreateInventorySlots();
    }
    public void AddItem(InventoryItemData itemData)
    {
        
        Items.Add(itemData);
    }

    public void RemoveItem(InventoryItemData itemData)
    {
        Items.Remove(itemData);
    }

    public void ClearItemsList()
    {
        Items.Clear();
    }
       
    public void SortItemList()
    {
        //Items.Sort();
        var sortedList = Items.OrderBy(go => go.name).ToList();
        Items = sortedList;
      
    }
    public void ListOfItems()
    {
        foreach (var item in Items)
        {
            for (int itemSlotUI = 0; itemSlotUI < Items.Count; itemSlotUI++)
            {
                AddItemToInventory(item, itemsSlotsUI[itemSlotUI]);
            }

        }
    }

    public void CreateInventorySlots(string itemCategory)
    {
        tmpList.Clear();
        foreach (Transform item in itemContent)
        {
            Destroy(item.gameObject);
        }
        foreach (var item in Items)
        {
            if (item.itemCategory == itemCategory)
            {
                
                emptyListInfo.SetActive(false);
                GameObject newItemSlot = Instantiate(inventorySlotParent, itemContent);
                //var itemIcon = newItemSlot.transform.GetChild(1).transform.Find("ItemIcon").GetComponent<Image>();
                
                tmpList.Add(item);
                var itemIcon = newItemSlot.transform.Find("ItemIcon").GetComponent<Image>();
                AddItemToInventory(item, newItemSlot, itemEquipSellPanel);
                //var currentItemData = newItemSlot.transform.GetChild(0).GetComponent<ItemInfoShopPanel>().itemData;
                //newItemSlot.transform.GetChild(0).GetComponent<ItemInfoShopPanel>().itemData = item;
                itemIcon.sprite = item.itemIcon;

            }
            if(tmpList.Count == 0)
            {
                emptyListInfo.SetActive(true);
            }
         

        }
    }

    public void CreateInventorySlots()
    {
        foreach (Transform item in itemContent)
        {
            Destroy(item.gameObject);
        }
        foreach (var item in Items)
        {
            emptyListInfo.SetActive(false);
            GameObject newItemSlot = Instantiate(inventorySlotParent, itemContent);
            var itemIcon = newItemSlot.transform.Find("ItemIcon").GetComponent<Image>();

            AddItemToInventory(item, newItemSlot, itemEquipSellPanel);
            itemIcon.sprite = item.itemIcon;
        }

        if (Items.Count == 0)
        {
            emptyListInfo.SetActive(true);
        }
    }
    public void AddItemToInventory(InventoryItemData itemData, GameObject itemSlotUI)
    {
        itemSlotUI.GetComponent<Inventory2ItemSlotUI>().itemData = itemData;
       
    }
    public void AddItemToInventory(InventoryItemData itemData, GameObject itemSlotUI, GameObject itemEquipSellPanel)
    {
        itemSlotUI.GetComponent<Inventory2ItemSlotUI>().itemData = itemData;
        itemSlotUI.GetComponent<Inventory2ItemSlotUI>().itemEquipSellPanel = itemEquipSellPanel;
    }

    public void RemoveItemFromInventory(InventoryItemData itemData, GameObject itemSlotUI)
    {
        if (itemSlotUI.GetComponent<Inventory3ItemSlotUI>().itemData == itemData)
        {
            itemSlotUI.GetComponent<Inventory3ItemSlotUI>().itemData = null;
        }
    }

    private void Update()
    {
        if(Items.Count != 0)
        {
            SortItemList();

        }
           
    }
}

