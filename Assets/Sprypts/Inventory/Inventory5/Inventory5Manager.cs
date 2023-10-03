using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class Inventory5Manager : MonoBehaviour
{
    public List<InventoryItemData> InventoryItems = new List<InventoryItemData>();
  
    [SerializeField] private GameObject[] itemSlots;
    [SerializeField] private GameObject itemSlot;
    [SerializeField] private Transform slotList;
    [SerializeField] private GameObject itemEquipPanel;
    [SerializeField] private GameObject noItemsPanel;
    public List<InventoryItemData> itemsTMP = new List<InventoryItemData>();
    public List<GameObject> itemsTMPGameObject = new List<GameObject>();
    public List<GameObject> itemsGameObject = new List<GameObject>();
    public List<bool> tmpBoolList = new List<bool>();

    private void Start()
    {
        //CreateShopSlots();
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
        //Items.Sort();
        var sortedList = InventoryItems.OrderBy(go => go.name).ToList();
        InventoryItems = sortedList;

    }
    public void CreateShopSlots()
    {
        
        foreach (Transform item in slotList)
        {
            Destroy(item.gameObject);
        }
        for (int i = 0; i < itemSlots.Length; i++)
        {

            itemSlots[i] = Instantiate(itemSlot, slotList);
                

            
        }
    }

    public void CreateInventorySlots()
    {

        foreach (Transform item in slotList)
        {
            Destroy(item.gameObject);
        }
        itemsTMPGameObject.Clear();
        //AddItemsSlots();
        foreach (var item in InventoryItems)
        {
            itemsTMP.Add(item);
            
            GameObject newItemSlot = Instantiate(itemSlot, slotList);
            itemsTMPGameObject.Add(newItemSlot);
            var itemIcon = newItemSlot.transform.Find("ItemIcon").GetComponent<Image>();

            SetSlot5ItemData(item, newItemSlot, itemEquipPanel);
            itemIcon.sprite = item.itemIcon;

        }
        if (itemsTMP.Count == 0) noItemsPanel.SetActive(true);
        if (itemsTMP.Count > 0) noItemsPanel.SetActive(false);
        itemsTMP.Clear();
        //SetEquipedItems();
        itemsGameObject = itemsTMPGameObject;
        if (InventoryItems.Count == 0)
        {
            noItemsPanel.SetActive(true);
        }
    }


    public void CreateInventorySlots(bool isEquiped)
    {

        foreach (Transform item in slotList)
        {
            Destroy(item.gameObject);
        }
        itemsTMPGameObject.Clear();
        foreach (var item in InventoryItems)
        {
            if(isEquiped == true)
            {
                itemsTMP.Add(item);
                GameObject newItemSlot = Instantiate(itemSlot, slotList);
                var itemIcon = newItemSlot.transform.Find("ItemIcon").GetComponent<Image>();

                SetSlot5ItemData(item, newItemSlot, itemEquipPanel);
                itemIcon.sprite = item.itemIcon;
            }
          

        }

        if (itemsTMP.Count == 0) noItemsPanel.SetActive(true);
        if (itemsTMP.Count > 0) noItemsPanel.SetActive(false);
        itemsTMP.Clear();
        GetEquipedItemsStatus();
        if (InventoryItems.Count == 0)
        {
            noItemsPanel.SetActive(true);
        }
    }

    public void SetSlot5ItemData(InventoryItemData itemData, GameObject itemSlotUI)
    {
        itemSlotUI.GetComponent<Inventory5ItemSlotUI>().itemData = itemData;

    }

    public void SetSlot5ItemData(InventoryItemData itemData, GameObject itemSlotUI, GameObject itemEquipPanel)
    {
        itemSlotUI.GetComponent<Inventory5ItemSlotUI>().itemData = itemData;
        itemSlotUI.GetComponent<Inventory5ItemSlotUI>().itemEquipPanel = itemEquipPanel;
    }

    private void GetEquipedItemsStatus()
    {
         tmpBoolList = new List<bool>();
     

        if (itemsTMPGameObject.Count == slotList.childCount)
        {
            tmpBoolList.Clear();
        }

     
        foreach (var item in itemsGameObject)
        {
            tmpBoolList.Add(item.GetComponent<Inventory5ItemSlotUI>().isEquip);
        }


        
    }

    private void SetEquipedItemsStatus()
    {
        List<bool> tmpList = new List<bool>();
        tmpList = tmpBoolList;
        bool[] arrayOfItemData = tmpList.ToArray();
        int itemDataID = 0;

        foreach (var item in itemsGameObject)
        {
            item.GetComponent<Inventory5ItemSlotUI>().isEquip = arrayOfItemData[itemDataID];

            itemDataID++;

        }
    }
    private void Update()
    {
        //SetEquipedItems();
        GetEquipedItemsStatus();
    }
}
