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
        if (shopSellBuyManager.GetComponent<ShopSellBuyManager>().BuyItems.Count != 15)
        {
            shopSellBuyManager.GetComponent<ShopSellBuyManager>().AddItem(shopSellBuyManager.GetComponent<ShopSellBuyManager>().BuyItems, itemData);
            shopSellBuyManager.GetComponent<ShopSellBuyManager>().CreateBuySlots();
            shopSellBuyManager.GetComponent<ShopSellBuyManager>().AddItemPrice(itemData);
            shopSellBuyManager.GetComponent<ShopSellBuyManager>().RemoveItem(shopSellBuyManager.GetComponent<ShopSellBuyManager>().ShopItems, itemData);
            shopSellBuyManager.GetComponent<ShopSellBuyManager>().SortItemList(shopSellBuyManager.GetComponent<ShopSellBuyManager>().ShopItems);
            shopSellBuyManager.GetComponent<ShopSellBuyManager>().CreateShopSlots(itemCategory);
        }
        else
        {
            refuseToAddItemPanel.SetActive(true);
        }
        
        
    }

    public void RemoveItemBuy()
    {
        shopSellBuyManager.GetComponent<ShopSellBuyManager>().AddItem(shopSellBuyManager.GetComponent<ShopSellBuyManager>().ShopItems, itemData);
        shopSellBuyManager.GetComponent<ShopSellBuyManager>().SortItemList(shopSellBuyManager.GetComponent<ShopSellBuyManager>().ShopItems);
        shopSellBuyManager.GetComponent<ShopSellBuyManager>().CreateShopSlots(itemCategory);
        shopSellBuyManager.GetComponent<ShopSellBuyManager>().RemoveItem(shopSellBuyManager.GetComponent<ShopSellBuyManager>().BuyItems, itemData);
        shopSellBuyManager.GetComponent<ShopSellBuyManager>().CreateBuySlots();
        shopSellBuyManager.GetComponent<ShopSellBuyManager>().SubtractItemPrice(itemData);
    }

    public void AddItemSell()
    {
        if (shopSellBuyManager.GetComponent<ShopSellBuyManager>().SellItems.Count != 15)
        {
            shopSellBuyManager.GetComponent<ShopSellBuyManager>().AddItem(shopSellBuyManager.GetComponent<ShopSellBuyManager>().SellItems, itemData);
            shopSellBuyManager.GetComponent<ShopSellBuyManager>().CreateSellSlots();
            shopSellBuyManager.GetComponent<ShopSellBuyManager>().AddItemPrice(itemData);
            shopSellBuyManager.GetComponent<ShopSellBuyManager>().RemoveItem(shopSellBuyManager.GetComponent<ShopSellBuyManager>().InventorySellItems, itemData);
            shopSellBuyManager.GetComponent<ShopSellBuyManager>().SortItemList(shopSellBuyManager.GetComponent<ShopSellBuyManager>().InventorySellItems);
            shopSellBuyManager.GetComponent<ShopSellBuyManager>().CreateInventorySlots(itemCategory);
        }
        else
        {
            refuseToAddItemPanel.SetActive(true);
        }
    }

    public void RemoveItemSell()
    {
        shopSellBuyManager.GetComponent<ShopSellBuyManager>().AddItem(shopSellBuyManager.GetComponent<ShopSellBuyManager>().InventorySellItems, itemData);
        shopSellBuyManager.GetComponent<ShopSellBuyManager>().SortItemList(shopSellBuyManager.GetComponent<ShopSellBuyManager>().InventorySellItems);
        shopSellBuyManager.GetComponent<ShopSellBuyManager>().CreateInventorySlots(itemCategory);
        shopSellBuyManager.GetComponent<ShopSellBuyManager>().RemoveItem(shopSellBuyManager.GetComponent<ShopSellBuyManager>().SellItems, itemData);
        shopSellBuyManager.GetComponent<ShopSellBuyManager>().CreateSellSlots();
        shopSellBuyManager.GetComponent<ShopSellBuyManager>().SubtractItemPrice(itemData);
    }
    private void Update()
    {
        GetItemData();
    }
}
