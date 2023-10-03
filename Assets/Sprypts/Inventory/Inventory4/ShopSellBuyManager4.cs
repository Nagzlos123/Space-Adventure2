using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class ShopSellBuyManager4 : MonoBehaviour
{


    [Header("Shop Items List")]
    public List<InventoryItemData> ShopItems = new List<InventoryItemData>();

    [SerializeField] private GameObject shopSlotParent;
    [SerializeField] private Transform shopSlotList;
    [SerializeField] private GameObject emptyListText1 = null;

    [Header("Inventory Sell Items List")]
    public List<InventoryItemData> InventorySellItems = new List<InventoryItemData>();
    [SerializeField] private GameObject inventortSlotParent;
    [SerializeField] private Transform inventortSlotList;
    [SerializeField] private GameObject emptyListText2 = null;

    [Header(" Sell Items List")]
    public List<InventoryItemData> SellItems = new List<InventoryItemData>();
    [SerializeField] private GameObject sellPanel;
    [SerializeField] private Transform sellSlotList;
    [SerializeField] private GameObject addSellItemPanel = null;
    [SerializeField] private GameObject removeSellItemPanel = null;

    [Header(" Buy Items List")]
    public List<InventoryItemData> BuyItems = new List<InventoryItemData>();
    [SerializeField] private GameObject buyPanel;
    [SerializeField] private Transform buySlotList;
    [SerializeField] private GameObject bigSlotParent;
    [SerializeField] private GameObject addBuyItemPanel = null;
    [SerializeField] private GameObject removeBuyItemPanel = null;
    public List<InventoryItemData> itemsInCategory = new List<InventoryItemData>();

    private void Start()
    {
        CreateShopSlots("Armor");
    }
    public void SortItemList(List<InventoryItemData> itemList)
    {
            //Items.Sort();
        var sortedList = itemList.OrderBy(go => go.name).ToList();
        itemList = sortedList;

    }

    public void AddItemPrice(InventoryItemData itemData)
    {
       
       InventoryItemData currentItemData = itemData;
       var price = currentItemData.itemCost;
       PlayerPrefs.SetFloat("ItemCost", price);

       PlayerPrefs.SetFloat("ItemsTotalCost", PlayerPrefs.GetFloat("ItemsTotalCost") + PlayerPrefs.GetFloat("ItemCost"));  
    }

    public void SubtractItemPrice(InventoryItemData itemData)
    {
      
       InventoryItemData currentItemData = itemData;
       var price = currentItemData.itemCost;
       PlayerPrefs.SetFloat("ItemCost", price);

       PlayerPrefs.SetFloat("ItemsTotalCost", PlayerPrefs.GetFloat("ItemsTotalCost") - PlayerPrefs.GetFloat("ItemCost"));
    }

    public void AddItem(List<InventoryItemData> itemList, InventoryItemData itemData)
    {

        itemList.Add(itemData);
    }

    public void RemoveItem(List<InventoryItemData> itemList, InventoryItemData itemData)
    {
        itemList.Remove(itemData);
    }

    public void AddItemToInventory(InventoryItemData itemData, GameObject itemSlotUI, GameObject addItemPanel, GameObject buyOrSellPanel)
    {
        itemSlotUI.transform.GetChild(0).GetComponent<Inventory4ItemSlotUI>().itemData = itemData;
        itemSlotUI.transform.GetChild(0).GetComponent<Inventory4ItemSlotUI>().addItemPanel = addItemPanel;
        itemSlotUI.transform.GetChild(0).GetComponent<Inventory4ItemSlotUI>().buyOrSellPanel = buyOrSellPanel;
    }
    public void AddItemToInventory(InventoryItemData itemData, GameObject itemSlotUI, GameObject addItemPanel)
    {
        itemSlotUI.transform.GetChild(0).GetComponent<Inventory4ItemSlotUI>().itemData = itemData;
        itemSlotUI.transform.GetChild(0).GetComponent<Inventory4ItemSlotUI>().addItemPanel = addItemPanel;
    }
    public void SetBigSlotItemData(InventoryItemData itemData, GameObject itemSlotUI)
    {
        itemSlotUI.GetComponent<Inventory4BigSlotUI>().itemData = itemData;
        
    }
    public void SetBigSlotItemData(InventoryItemData itemData, GameObject itemSlotUI, GameObject removeItemPanel)
    {
        itemSlotUI.GetComponent<Inventory4BigSlotUI>().itemData = itemData;
        itemSlotUI.GetComponent<Inventory4BigSlotUI>().removeItemPanel = removeItemPanel;
    }
    public void AddItemToInventory(InventoryItemData itemData, GameObject itemSlotUI)
    {
        itemSlotUI.transform.GetChild(1).GetComponent<Inventory4ItemSlotUI>().itemData = itemData;
       
    }

    public void CreateShopSlots(string itemCategory)
    {
        foreach (Transform item in shopSlotList)
        {
            Destroy(item.gameObject);
        }
        foreach (var item in ShopItems)
        {
            if(item.itemCategory == itemCategory)
            {
                itemsInCategory.Add(item);
                GameObject newItemSlot = Instantiate(shopSlotParent, shopSlotList);
                var itemIcon = newItemSlot.transform.GetChild(0).transform.Find("ItemIcon").GetComponent<Image>();
                //var currentItemData = newItemSlot.transform.GetChild(0).GetComponent<ItemInfoShopPanel>().itemData;
                newItemSlot.transform.GetChild(1).GetComponent<ItemInfoShopPanel>().itemData = item;
                AddItemToInventory(item, newItemSlot, addBuyItemPanel, buyPanel);
                itemIcon.sprite = item.itemIcon;
               
            }
            
        }
        if (itemsInCategory.Count == 0) emptyListText1.SetActive(true);
        if (itemsInCategory.Count > 0) emptyListText1.SetActive(false);
        itemsInCategory.Clear();

        if (ShopItems.Count == 0)
        {
            emptyListText1.SetActive(true);
        }
    }

    public void CreateInventorySlots(string itemCategory)
    {
        foreach (Transform item in inventortSlotList)
        {
            Destroy(item.gameObject);
        }

        foreach (var item in InventorySellItems)
        {
            if (item.itemCategory == itemCategory)
            {
                //List<InventoryItemData> itemsInCategory = new List<InventoryItemData>();
                itemsInCategory.Add(item);
               
                GameObject newItemSlot = Instantiate(inventortSlotParent, inventortSlotList);
                var itemIcon = newItemSlot.transform.GetChild(0).transform.Find("ItemIcon").GetComponent<Image>();
                //var currentItemData = newItemSlot.transform.GetChild(0).GetComponent<ItemInfoShopPanel>().itemData;
                newItemSlot.transform.GetChild(1).GetComponent<ItemInfoShopPanel>().itemData = item;
                AddItemToInventory(item, newItemSlot, addSellItemPanel, addSellItemPanel);
                itemIcon.sprite = item.itemIcon;

            }

        }
        if (itemsInCategory.Count == 0) emptyListText2.SetActive(true);
        if (itemsInCategory.Count > 0) emptyListText2.SetActive(false);
        itemsInCategory.Clear();
        if (InventorySellItems.Count == 0)
        {
            emptyListText2.SetActive(true);
        }
    }

    public void CreateInventorySlots()
    {
        foreach (Transform item in inventortSlotList)
        {
            Destroy(item.gameObject);
        }

        foreach (var item in InventorySellItems)
        {
          
           GameObject newItemSlot = Instantiate(inventortSlotParent, inventortSlotList);
           var itemIcon = newItemSlot.transform.GetChild(0).transform.Find("ItemIcon").GetComponent<Image>();
           //var currentItemData = newItemSlot.transform.GetChild(0).GetComponent<ItemInfoShopPanel>().itemData;
           newItemSlot.transform.GetChild(1).GetComponent<ItemInfoShopPanel>().itemData = item;
           AddItemToInventory(item, newItemSlot, addSellItemPanel, addSellItemPanel);
           itemIcon.sprite = item.itemIcon;

        }
        if (InventorySellItems.Count == 0)
        {
            emptyListText2.SetActive(true);
        }
    }

    public void CreateBuySlots()
    {
        foreach (Transform item in buySlotList)
        {
            Destroy(item.gameObject);
        }

        foreach (var item in BuyItems)
        {

            GameObject newItemSlot = Instantiate(bigSlotParent, buySlotList);
            var itemIcon = newItemSlot.transform.Find("ItemIcon").GetComponent<Image>();
            SetBigSlotItemData(item, newItemSlot, removeBuyItemPanel);
          //newItemSlot.GetComponent<AddRemoveItemPanel>().itemData = item;
          itemIcon.sprite = item.itemIcon;

            

        }
    }

    public void CreateSellSlots()
    {
        foreach (Transform item in sellSlotList)
        {
            Destroy(item.gameObject);
        }

        foreach (var item in SellItems)
        {

            GameObject newItemSlot = Instantiate(bigSlotParent, sellSlotList);
            var itemIcon = newItemSlot.transform.Find("ItemIcon").GetComponent<Image>();
            SetBigSlotItemData(item, newItemSlot, removeSellItemPanel);
            //newItemSlot.transform.GetChild(0).GetComponent<ItemInfoShopPanel>().itemData = item;
            itemIcon.sprite = item.itemIcon;



        }
    }
    private void Update()
    {
        /*
        if(buyPanel.activeSelf == true)
        {
            CreateBuySlots();
        }

        if (sellPanel.activeSelf == true)
        {
            CreateSellSlots();
        }
        */
    }
}
