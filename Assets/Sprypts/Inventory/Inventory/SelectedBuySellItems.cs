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
    [SerializeField] private GameObject mainSystem2;
    [SerializeField] private Inventory2Manager inventory2;
    private float yourKredyts;
    private float itemsTotalCost;
    public int buyItemsCount;


    private void Start()
    {
        PlayerPrefs.SetFloat("ItemsTotalCost", 0);
    }


    public void OnCancelBuyButton()
    {
        if (shopSellBuyManager.GetComponent<ShopSellBuyManager>().BuyItems.Count == 0)
        {

            Debug.Log("Purchase canceled!");
        }
        else
        {
            foreach (var item in shopSellBuyManager.GetComponent<ShopSellBuyManager>().BuyItems)
            {
                shopSellBuyManager.GetComponent<ShopSellBuyManager>().AddItem(shopSellBuyManager.GetComponent<ShopSellBuyManager>().ShopItems, item);
               
            }
            shopSellBuyManager.GetComponent<ShopSellBuyManager>().BuyItems.Clear();
            shopSellBuyManager.GetComponent<ShopSellBuyManager>().CreateBuySlots();
            shopSellBuyManager.GetComponent<ShopSellBuyManager>().SortItemList(shopSellBuyManager.GetComponent<ShopSellBuyManager>().ShopItems);
            shopSellBuyManager.GetComponent<ShopSellBuyManager>().CreateShopSlots("Atmor");
            PlayerPrefs.SetFloat("ItemsTotalCost", 0);

            Debug.Log("Purchase canceled!");
        }
  
    }

    public void OnBuyButton()
    {
        if (CheckBuyItemCost(itemsTotalCost))
        {
            
            foreach (var item in shopSellBuyManager.GetComponent<ShopSellBuyManager>().BuyItems)
            {
                shopSellBuyManager.GetComponent<ShopSellBuyManager>().AddItem(shopSellBuyManager.
                    GetComponent<ShopSellBuyManager>().InventorySellItems, item);
                mainPanel.SetActive(true);
                mainSystem2.SetActive(true);
                inventory2.AddItem(item);
                
            }
            shopSellBuyManager.GetComponent<ShopSellBuyManager>().SortItemList(shopSellBuyManager.
                GetComponent<ShopSellBuyManager>().InventorySellItems);
            shopSellBuyManager.GetComponent<ShopSellBuyManager>().CreateInventorySlots("Armor");
            shopSellBuyManager.GetComponent<ShopSellBuyManager>().BuyItems.Clear();
            shopSellBuyManager.GetComponent<ShopSellBuyManager>().CreateBuySlots();
            inventory2.SortItemList();
            inventory2.CreateInventorySlots();
            mainSystem2.SetActive(false);
            mainPanel.SetActive(false);
            PlayerPrefs.SetFloat("ItemsTotalCost", 0);
            Debug.Log("You bought items!");
        }
   
    }

    public void OnCancelSellButton()
    {
        if (shopSellBuyManager.GetComponent<ShopSellBuyManager>().SellItems.Count == 0)
        {

            Debug.Log("Sell canceled!");
        }
        else
        {
            
            foreach (var item in shopSellBuyManager.GetComponent<ShopSellBuyManager>().SellItems)
            {
                
                shopSellBuyManager.GetComponent<ShopSellBuyManager>().AddItem(shopSellBuyManager.GetComponent<ShopSellBuyManager>().InventorySellItems, item);
                mainPanel.SetActive(true);
                mainSystem2.SetActive(true);
                inventory2.AddItem(item);
            }
            shopSellBuyManager.GetComponent<ShopSellBuyManager>().CreateShopSlots("Armor");
            shopSellBuyManager.GetComponent<ShopSellBuyManager>().SortItemList(shopSellBuyManager.GetComponent<ShopSellBuyManager>().InventorySellItems);
            shopSellBuyManager.GetComponent<ShopSellBuyManager>().CreateInventorySlots();
            shopSellBuyManager.GetComponent<ShopSellBuyManager>().SellItems.Clear();
            shopSellBuyManager.GetComponent<ShopSellBuyManager>().CreateSellSlots();
            inventory2.SortItemList();
            inventory2.CreateInventorySlots();
            mainSystem2.SetActive(false);
            mainPanel.SetActive(false);
            PlayerPrefs.SetFloat("ItemsTotalCost", 0);
            Debug.Log("Sell canceled!");
        }
    }

    public void OnSellButton()
    {
        if (CheckSellItemCost(itemsTotalCost))
        {
           
            foreach (var item in shopSellBuyManager.GetComponent<ShopSellBuyManager>().SellItems)
            {
                shopSellBuyManager.GetComponent<ShopSellBuyManager>().AddItem(shopSellBuyManager.GetComponent<ShopSellBuyManager>().ShopItems, item);
                shopSellBuyManager.GetComponent<ShopSellBuyManager>().RemoveItem(shopSellBuyManager.GetComponent<ShopSellBuyManager>().InventorySellItems, item);
                mainPanel.SetActive(true);
                mainSystem2.SetActive(true);
                inventory2.RemoveItem(item);
            }
            
            shopSellBuyManager.GetComponent<ShopSellBuyManager>().SellItems.Clear();
            shopSellBuyManager.GetComponent<ShopSellBuyManager>().CreateSellSlots();
            shopSellBuyManager.GetComponent<ShopSellBuyManager>().SortItemList(shopSellBuyManager.GetComponent<ShopSellBuyManager>().ShopItems);
            shopSellBuyManager.GetComponent<ShopSellBuyManager>().CreateShopSlots("Atmor");
            shopSellBuyManager.GetComponent<ShopSellBuyManager>().SortItemList(shopSellBuyManager.GetComponent<ShopSellBuyManager>().InventorySellItems);
            shopSellBuyManager.GetComponent<ShopSellBuyManager>().CreateInventorySlots();
            inventory2.SortItemList();
            inventory2.CreateInventorySlots();
            mainSystem2.SetActive(false);
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
        buyItemsCount = shopSellBuyManager.GetComponent<ShopSellBuyManager>().BuyItems.Count;
    }
}
