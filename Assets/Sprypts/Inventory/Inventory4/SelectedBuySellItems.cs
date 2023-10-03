using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SelectedBuySellItems : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI itemsTotalCostText;
    [SerializeField] private GameObject shopSellBuyManager;
    [SerializeField] private GameObject kredytsManager;
    [SerializeField] private GameObject refusalToBuyPanel; // Not enouch money.
    [SerializeField] private GameObject refusalToBuyPanel2; // No item selectet to buy.

    [SerializeField] private GameObject mainPanel;
    [SerializeField] private GameObject mainSystem4;
    [SerializeField] private Inventory4Manager inventory4;
    private float yourKredyts;
    private float itemsTotalCost;
    public int buyItemsCount;


    private void Start()
    {
        PlayerPrefs.SetFloat("ItemsTotalCost", 0);
    }


    public void OnCancelBuyButton()
    {
        if (shopSellBuyManager.GetComponent<ShopSellBuyManager4>().BuyItems.Count == 0)
        {

            Debug.Log("Purchase canceled!");
        }
        else
        {
            foreach (var item in shopSellBuyManager.GetComponent<ShopSellBuyManager4>().BuyItems)
            {
                shopSellBuyManager.GetComponent<ShopSellBuyManager4>().AddItem(shopSellBuyManager.GetComponent<ShopSellBuyManager4>().ShopItems, item);
               
            }
            shopSellBuyManager.GetComponent<ShopSellBuyManager4>().BuyItems.Clear();
            shopSellBuyManager.GetComponent<ShopSellBuyManager4>().CreateBuySlots();
            shopSellBuyManager.GetComponent<ShopSellBuyManager4>().SortItemList(shopSellBuyManager.GetComponent<ShopSellBuyManager4>().ShopItems);
            shopSellBuyManager.GetComponent<ShopSellBuyManager4>().CreateShopSlots("Atmor");
            PlayerPrefs.SetFloat("ItemsTotalCost", 0);

            Debug.Log("Purchase canceled!");
        }
  
    }

    public void OnBuyButton()
    {
        if (CheckBuyItemCost(itemsTotalCost))
        {
            
            foreach (var item in shopSellBuyManager.GetComponent<ShopSellBuyManager4>().BuyItems)
            {
                shopSellBuyManager.GetComponent<ShopSellBuyManager4>().AddItem(shopSellBuyManager.
                    GetComponent<ShopSellBuyManager4>().InventorySellItems, item);
                mainPanel.SetActive(true);
                mainSystem4.SetActive(true);
                inventory4.AddItem(item);
                
            }
            shopSellBuyManager.GetComponent<ShopSellBuyManager4>().SortItemList(shopSellBuyManager.
                GetComponent<ShopSellBuyManager4>().InventorySellItems);
            shopSellBuyManager.GetComponent<ShopSellBuyManager4>().CreateInventorySlots("Armor");
            shopSellBuyManager.GetComponent<ShopSellBuyManager4>().BuyItems.Clear();
            shopSellBuyManager.GetComponent<ShopSellBuyManager4>().CreateBuySlots();
            inventory4.SortItemList();
            inventory4.CreateInventorySlots();
            mainSystem4.SetActive(false);
            mainPanel.SetActive(false);
            PlayerPrefs.SetFloat("ItemsTotalCost", 0);
            Debug.Log("You bought items!");
        }
   
    }

    public void OnCancelSellButton()
    {
        if (shopSellBuyManager.GetComponent<ShopSellBuyManager4>().SellItems.Count == 0)
        {

            Debug.Log("Sell canceled!");
        }
        else
        {
            
            foreach (var item in shopSellBuyManager.GetComponent<ShopSellBuyManager4>().SellItems)
            {
                
                shopSellBuyManager.GetComponent<ShopSellBuyManager4>().AddItem(shopSellBuyManager.GetComponent<ShopSellBuyManager4>().InventorySellItems, item);
                mainPanel.SetActive(true);
                mainSystem4.SetActive(true);
                inventory4.AddItem(item);
            }
            shopSellBuyManager.GetComponent<ShopSellBuyManager4>().CreateShopSlots("Armor");
            shopSellBuyManager.GetComponent<ShopSellBuyManager4>().SortItemList(shopSellBuyManager.GetComponent<ShopSellBuyManager4>().InventorySellItems);
            shopSellBuyManager.GetComponent<ShopSellBuyManager4>().CreateInventorySlots();
            shopSellBuyManager.GetComponent<ShopSellBuyManager4>().SellItems.Clear();
            shopSellBuyManager.GetComponent<ShopSellBuyManager4>().CreateSellSlots();
            inventory4.SortItemList();
            inventory4.CreateInventorySlots();
            mainSystem4.SetActive(false);
            mainPanel.SetActive(false);
            PlayerPrefs.SetFloat("ItemsTotalCost", 0);
            Debug.Log("Sell canceled!");
        }
    }

    public void OnSellButton()
    {
        if (CheckSellItemCost(itemsTotalCost))
        {
           
            foreach (var item in shopSellBuyManager.GetComponent<ShopSellBuyManager4>().SellItems)
            {
                shopSellBuyManager.GetComponent<ShopSellBuyManager4>().AddItem(shopSellBuyManager.GetComponent<ShopSellBuyManager4>().ShopItems, item);
                shopSellBuyManager.GetComponent<ShopSellBuyManager4>().RemoveItem(shopSellBuyManager.GetComponent<ShopSellBuyManager4>().InventorySellItems, item);
                mainPanel.SetActive(true);
                mainSystem4.SetActive(true);
                inventory4.RemoveItem(item);
            }
            
            shopSellBuyManager.GetComponent<ShopSellBuyManager4>().SellItems.Clear();
            shopSellBuyManager.GetComponent<ShopSellBuyManager4>().CreateSellSlots();
            shopSellBuyManager.GetComponent<ShopSellBuyManager4>().SortItemList(shopSellBuyManager.GetComponent<ShopSellBuyManager4>().ShopItems);
            shopSellBuyManager.GetComponent<ShopSellBuyManager4>().CreateShopSlots("Atmor");
            shopSellBuyManager.GetComponent<ShopSellBuyManager4>().SortItemList(shopSellBuyManager.GetComponent<ShopSellBuyManager4>().InventorySellItems);
            shopSellBuyManager.GetComponent<ShopSellBuyManager4>().CreateInventorySlots();
            inventory4.SortItemList();
            inventory4.CreateInventorySlots();
            mainSystem4.SetActive(false);
            mainPanel.SetActive(false);
            PlayerPrefs.SetFloat("ItemsTotalCost", 0);
            Debug.Log("You sold items!");
        }
    }

    private bool CheckBuyItemCost(float price)
    {

        if(price == 0)
        {
            refusalToBuyPanel2.SetActive(true);
            return false;
        }
        else if (yourKredyts >= price)
        {
            kredytsManager.GetComponent<KredytsManager>().SubtractKredyts(price);

            return true;
        }
        else
        {
            Debug.Log("You don't have enough kredyts");
            refusalToBuyPanel.SetActive(true);
            return false;
        }
    }

    private bool CheckSellItemCost(float price)
    {

        if (price == 0)
        {
            refusalToBuyPanel2.SetActive(true);
            return false;
        }
        else
        {
            kredytsManager.GetComponent<KredytsManager>().AddKredyts(price);

            return true;
        }
     
    }

    private void Update()
    {
        yourKredyts = PlayerPrefs.GetFloat("yourKredytNumber");
        itemsTotalCostText.text = PlayerPrefs.GetFloat("ItemsTotalCost").ToString();
        itemsTotalCost = PlayerPrefs.GetFloat("ItemsTotalCost");
        buyItemsCount = shopSellBuyManager.GetComponent<ShopSellBuyManager4>().BuyItems.Count;
    }
}
