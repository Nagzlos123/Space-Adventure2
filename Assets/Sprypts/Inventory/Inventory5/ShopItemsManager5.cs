using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using TMPro;

public class ShopItemsManager5 : MonoBehaviour
{
    public List<InventoryItemData> ShopItems = new List<InventoryItemData>();
    [SerializeField] private TextMeshProUGUI panelName;
    [SerializeField] private GameObject shopItem;
    [SerializeField] private Transform shopSlotList;
    [SerializeField] private GameObject refusalToBuyPanel;
    [SerializeField] private GameObject kredytsManager;
    [SerializeField] private GameObject shopItemsManager;
    [SerializeField] private GameObject inventory5Manager;
    [SerializeField] private GameObject noItemsPanel;
    public List<InventoryItemData> itemsTMP = new List<InventoryItemData>();
    private float yourKredyts;

    public void CreateShopSlots(string itemCategory)
    {
        panelName.text = itemCategory;
        foreach (Transform item in shopSlotList)
        {
            Destroy(item.gameObject);
        }
        foreach (var item in ShopItems)
        {
            if (item.itemCategory == itemCategory)
            {
                itemsTMP.Add(item);
                GameObject newItemSlot = Instantiate(shopItem, shopSlotList);
                var itemIcon = newItemSlot.transform.Find("ItemIcon").GetComponent<Image>();

                SetShopItemData(item, newItemSlot, refusalToBuyPanel, kredytsManager, shopItemsManager, inventory5Manager);
                itemIcon.sprite = item.itemIcon;

            }
        }
        if (itemsTMP.Count == 0) noItemsPanel.SetActive(true);
        if (itemsTMP.Count > 0) noItemsPanel.SetActive(false);
        itemsTMP.Clear();
        if (ShopItems.Count == 0)
        {
            noItemsPanel.SetActive(true);
        }
    }
    public void DestroyShopSlots()
    {

        foreach (Transform item in shopSlotList)
        {
            Destroy(item.gameObject);
        }
    }
    public void SetShopItemData(InventoryItemData itemData, GameObject itemSlotUI)
    {
        itemSlotUI.GetComponent<ShopItem>().itemData = itemData;

    }

    public void SetShopItemData(InventoryItemData itemData, GameObject itemSlotUI, GameObject refusalToBuyPanel,
                                    GameObject kredytsManager, GameObject shopItemsManager, GameObject inventory5Manager)
    {
        itemSlotUI.GetComponent<ShopItem>().itemData = itemData;
        itemSlotUI.GetComponent<ShopItem>().refusalToBuyPanel = refusalToBuyPanel;
        itemSlotUI.GetComponent<ShopItem>().kredytsManager = kredytsManager;
        itemSlotUI.GetComponent<ShopItem>().shopItemsManager = shopItemsManager;
        itemSlotUI.GetComponent<ShopItem>().inventory5Manager = inventory5Manager;


    }
    public void AddItem(List<InventoryItemData> itemList, InventoryItemData itemData)
    {

        itemList.Add(itemData);
    }
    public void RemoveItem(List<InventoryItemData> itemList, InventoryItemData itemData)
    {
        itemList.Remove(itemData);
    }

    public void SortItemList(List<InventoryItemData> itemList)
    {
        //Items.Sort();
        var sortedList = itemList.OrderBy(go => go.name).ToList();
        itemList = sortedList;

    }



    private bool CheckItemCost(float price)
    {
        if (yourKredyts >= price)
        {
            Debug.Log("You bought chest ");
            kredytsManager.GetComponent<KredytsManager>().SubtractKredyts(price);
            
            //inventory2.GetComponent<InventoryItemManager>().ChestRandomItemSet(itemNumber);

            return true;
        }
        else
        {
            Debug.Log("You don't have enough kredyts");
            refusalToBuyPanel.SetActive(true);
            return false;
        }
    }

    private void Update()
    {
        yourKredyts = PlayerPrefs.GetFloat("yourKredytNumber");
    }
}
