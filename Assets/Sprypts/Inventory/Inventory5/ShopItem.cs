using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopItem : MonoBehaviour
{
    public InventoryItemData itemData;
    [SerializeField] private TextMeshProUGUI itemDescryption;
    [SerializeField] private TextMeshProUGUI itemNameText;
    [SerializeField] private TextMeshProUGUI itemPrice;
    [SerializeField] private GameObject itemIcon;
    public GameObject refusalToBuyPanel;
    public GameObject kredytsManager;
    public GameObject shopItemsManager;
    public GameObject inventory5Manager;
    public float price;
    public string itemCategory;
    private float yourKredyts;

    public void GetShopItemData()
    {
        if (itemData != null)
        {
            InventoryItemData currentItemData = itemData;
            var descryption = currentItemData.discreption;
            var itemName = currentItemData.displayName;
            itemCategory = currentItemData.itemCategory;
            price = (float)currentItemData.itemCost;
            itemDescryption.text = descryption;
            itemNameText.text = itemName;
            itemPrice.text = price.ToString();

            itemIcon.GetComponent<Image>().sprite = currentItemData.itemIcon;
        }
    }

    public void BuyItem()
    {
        if (CheckItemCost(price))
        {
            shopItemsManager.GetComponent<ShopItemsManager5>().RemoveItem(shopItemsManager.GetComponent<ShopItemsManager5>().ShopItems, itemData);
            shopItemsManager.GetComponent<ShopItemsManager5>().CreateShopSlots(itemCategory);
            inventory5Manager.GetComponent<Inventory5Manager>().AddItem(itemData);
            inventory5Manager.GetComponent<Inventory5Manager>().CreateInventorySlots();
            Debug.Log("You bought item!");
        }
        
    }

    private bool CheckItemCost(float price)
    {
        if (yourKredyts >= price)
        {
            
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
        GetShopItemData();
    }


}
