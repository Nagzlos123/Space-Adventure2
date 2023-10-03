using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AddRemoveItemPanel : MonoBehaviour
{
    public InventoryItemData itemData;
    [SerializeField] private TextMeshProUGUI itemNameText;
    [SerializeField] private GameObject itemIcon;
    [SerializeField] private GameObject shopSellBuyManager;
    [SerializeField] private GameObject refuseToAddItemPanel;


    public string itemCategory;
    public void GetItemData()
    {
        if (itemData != null)
        {
            InventoryItemData currentItemData = itemData;
            var itemName = currentItemData.displayName;
            itemCategory = currentItemData.itemCategory;
            itemNameText.text = itemName;
            //price = currentItemData.itemCost;
       

            itemIcon.GetComponent<Image>().sprite = currentItemData.itemIcon;
        }

    
    }

    public void AddItemBuy()
    {
        if (shopSellBuyManager.GetComponent<ShopSellBuyManager4>().BuyItems.Count != 15)
        {
            shopSellBuyManager.GetComponent<ShopSellBuyManager4>().AddItem(shopSellBuyManager.GetComponent<ShopSellBuyManager4>().BuyItems, itemData);
            shopSellBuyManager.GetComponent<ShopSellBuyManager4>().CreateBuySlots();
            shopSellBuyManager.GetComponent<ShopSellBuyManager4>().AddItemPrice(itemData);
            shopSellBuyManager.GetComponent<ShopSellBuyManager4>().RemoveItem(shopSellBuyManager.GetComponent<ShopSellBuyManager4>().ShopItems, itemData);
            shopSellBuyManager.GetComponent<ShopSellBuyManager4>().SortItemList(shopSellBuyManager.GetComponent<ShopSellBuyManager4>().ShopItems);
            shopSellBuyManager.GetComponent<ShopSellBuyManager4>().CreateShopSlots(itemCategory);
        }
        else
        {
            refuseToAddItemPanel.SetActive(true);
        }
        
        
    }

    public void RemoveItemBuy()
    {
        shopSellBuyManager.GetComponent<ShopSellBuyManager4>().AddItem(shopSellBuyManager.GetComponent<ShopSellBuyManager4>().ShopItems, itemData);
        shopSellBuyManager.GetComponent<ShopSellBuyManager4>().SortItemList(shopSellBuyManager.GetComponent<ShopSellBuyManager4>().ShopItems);
        shopSellBuyManager.GetComponent<ShopSellBuyManager4>().CreateShopSlots(itemCategory);
        shopSellBuyManager.GetComponent<ShopSellBuyManager4>().RemoveItem(shopSellBuyManager.GetComponent<ShopSellBuyManager4>().BuyItems, itemData);
        shopSellBuyManager.GetComponent<ShopSellBuyManager4>().CreateBuySlots();
        shopSellBuyManager.GetComponent<ShopSellBuyManager4>().SubtractItemPrice(itemData);
    }

    public void AddItemSell()
    {
        if (shopSellBuyManager.GetComponent<ShopSellBuyManager4>().SellItems.Count != 15)
        {
            shopSellBuyManager.GetComponent<ShopSellBuyManager4>().AddItem(shopSellBuyManager.GetComponent<ShopSellBuyManager4>().SellItems, itemData);
            shopSellBuyManager.GetComponent<ShopSellBuyManager4>().CreateSellSlots();
            shopSellBuyManager.GetComponent<ShopSellBuyManager4>().AddItemPrice(itemData);
            shopSellBuyManager.GetComponent<ShopSellBuyManager4>().RemoveItem(shopSellBuyManager.GetComponent<ShopSellBuyManager4>().InventorySellItems, itemData);
            shopSellBuyManager.GetComponent<ShopSellBuyManager4>().SortItemList(shopSellBuyManager.GetComponent<ShopSellBuyManager4>().InventorySellItems);
            shopSellBuyManager.GetComponent<ShopSellBuyManager4>().CreateInventorySlots(itemCategory);
        }
        else
        {
            refuseToAddItemPanel.SetActive(true);
        }
    }

    public void RemoveItemSell()
    {
        shopSellBuyManager.GetComponent<ShopSellBuyManager4>().AddItem(shopSellBuyManager.GetComponent<ShopSellBuyManager4>().InventorySellItems, itemData);
        shopSellBuyManager.GetComponent<ShopSellBuyManager4>().SortItemList(shopSellBuyManager.GetComponent<ShopSellBuyManager4>().InventorySellItems);
        shopSellBuyManager.GetComponent<ShopSellBuyManager4>().CreateInventorySlots(itemCategory);
        shopSellBuyManager.GetComponent<ShopSellBuyManager4>().RemoveItem(shopSellBuyManager.GetComponent<ShopSellBuyManager4>().SellItems, itemData);
        shopSellBuyManager.GetComponent<ShopSellBuyManager4>().CreateSellSlots();
        shopSellBuyManager.GetComponent<ShopSellBuyManager4>().SubtractItemPrice(itemData);
    }
    private void Update()
    {
        GetItemData();
    }
}
