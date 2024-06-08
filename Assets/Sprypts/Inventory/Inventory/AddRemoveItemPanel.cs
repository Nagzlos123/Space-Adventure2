using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AddRemoveItemPanel : MonoBehaviour
{
    [Header("Old")]
    [SerializeField] private GameObject shopSellBuyManager;
    [SerializeField] private GameObject refuseToAddItemPanel;

    public string itemCategory;

    [Header("Data Getter")]
    public AddRemoveShopItemGetter itemDataGetter;
    private void Start()
    {
        itemDataGetter.GetItemData();
    }

    public void AddItemBuy()
    {
        if (shopSellBuyManager.GetComponent<ShopSellBuyManager>().BuyItems.Count != 15)
        {
            shopSellBuyManager.GetComponent<ShopSellBuyManager>()
                .AddItem(shopSellBuyManager.GetComponent<ShopSellBuyManager>().BuyItems, itemDataGetter.itemData);
            shopSellBuyManager.GetComponent<ShopSellBuyManager>().CreateBuySlots();
            shopSellBuyManager.GetComponent<ShopSellBuyManager>().AddItemPrice(itemDataGetter.itemData);
            shopSellBuyManager.GetComponent<ShopSellBuyManager>()
                .RemoveItem(shopSellBuyManager.GetComponent<ShopSellBuyManager>().ShopItems, itemDataGetter.itemData);
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
        shopSellBuyManager.GetComponent<ShopSellBuyManager>()
            .AddItem(shopSellBuyManager.GetComponent<ShopSellBuyManager>().ShopItems, itemDataGetter.itemData);
        shopSellBuyManager.GetComponent<ShopSellBuyManager>().SortItemList(shopSellBuyManager.GetComponent<ShopSellBuyManager>().ShopItems);
        shopSellBuyManager.GetComponent<ShopSellBuyManager>().CreateShopSlots(itemCategory);
        shopSellBuyManager.GetComponent<ShopSellBuyManager>()
            .RemoveItem(shopSellBuyManager.GetComponent<ShopSellBuyManager>().BuyItems, itemDataGetter.itemData);
        shopSellBuyManager.GetComponent<ShopSellBuyManager>().CreateBuySlots();
        shopSellBuyManager.GetComponent<ShopSellBuyManager>().SubtractItemPrice(itemDataGetter.itemData);
    }

    public void AddItemSell()
    {
        if (shopSellBuyManager.GetComponent<ShopSellBuyManager>().SellItems.Count != 15)
        {
            shopSellBuyManager.GetComponent<ShopSellBuyManager>()
                .AddItem(shopSellBuyManager.GetComponent<ShopSellBuyManager>().SellItems, itemDataGetter.itemData);
            shopSellBuyManager.GetComponent<ShopSellBuyManager>().CreateSellSlots();
            shopSellBuyManager.GetComponent<ShopSellBuyManager>().AddItemPrice(itemDataGetter.itemData);
            shopSellBuyManager.GetComponent<ShopSellBuyManager>()
                .RemoveItem(shopSellBuyManager.GetComponent<ShopSellBuyManager>().InventorySellItems, itemDataGetter.itemData);
            shopSellBuyManager.GetComponent<ShopSellBuyManager>()
                .SortItemList(shopSellBuyManager.GetComponent<ShopSellBuyManager>().InventorySellItems);
            shopSellBuyManager.GetComponent<ShopSellBuyManager>().CreateInventorySlots(itemCategory);
        }
        else
        {
            refuseToAddItemPanel.SetActive(true);
        }
    }

    public void RemoveItemSell()
    {
        shopSellBuyManager.GetComponent<ShopSellBuyManager>()
            .AddItem(shopSellBuyManager.GetComponent<ShopSellBuyManager>().InventorySellItems, itemDataGetter.itemData);
        shopSellBuyManager.GetComponent<ShopSellBuyManager>()
            .SortItemList(shopSellBuyManager.GetComponent<ShopSellBuyManager>().InventorySellItems);
        shopSellBuyManager.GetComponent<ShopSellBuyManager>().CreateInventorySlots(itemCategory);
        shopSellBuyManager.GetComponent<ShopSellBuyManager>()
            .RemoveItem(shopSellBuyManager.GetComponent<ShopSellBuyManager>().SellItems, itemDataGetter.itemData);
        shopSellBuyManager.GetComponent<ShopSellBuyManager>().CreateSellSlots();
        shopSellBuyManager.GetComponent<ShopSellBuyManager>().SubtractItemPrice(itemDataGetter.itemData);
    }
    private void Update()
    {
        itemDataGetter.GetItemData();
    }
}
