using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItemManager : MonoBehaviour
{

    [SerializeField] private InventoryItemData[] ringsItems;
    [SerializeField] private InventoryItemData[] earringsItems;
    [SerializeField] private InventoryItemData[] necklacesItems;


    [SerializeField] private InventoryItemData[] helmetsItems;
    [SerializeField] private InventoryItemData[] bodyArmorItems;
    [SerializeField] private InventoryItemData[] pantsItems;
    [SerializeField] private InventoryItemData[] bootsItems;
    [SerializeField] private InventoryItemData[] glovesItems;
    [SerializeField] private InventoryItemData[] bracersItems;
    [SerializeField] private InventoryItemData[] shouldersTtems;

    [SerializeField] private InventoryItemData[] spaceshipItems;
    public List<PlayerInvemtorySlot> playerSlots;
    
    

    public InventoryItemData[] chestItemSet;

    [SerializeField] private GameObject[] itemsSlotsUI;
    [SerializeField] private GameObject mainPanel;
    [SerializeField] private GameObject shopPanel;
    public List<InventoryItemData> inventoryItems;
    [SerializeField] private GameObject shopSellBuyManage;
    [SerializeField] private GameObject shopItemsManager5;
    
    public Inventory2Manager inventory2;
    public Inventory3ItemSlotUI slotUI;


    public int itemsLength = 10;
    public int chestItemSetNumber;
    
    private enum TypeOfOperation
    {
        AddToShop,
        AddToInventory
    }
    private void Start()
    {
        
    }

    private void AddItems(InventoryItemData[] items, TypeOfOperation operation)
    {
        switch (operation)
        {
            case TypeOfOperation.AddToShop:
                for (int i = 0; i < items.Length; i++)
                {
                    shopSellBuyManage.GetComponent<ShopSellBuyManager>()
                        .AddItem(shopSellBuyManage.GetComponent<ShopSellBuyManager>().ShopItems, items[i]);
                }
                break;
            case TypeOfOperation.AddToInventory:
                for (int i = 0; i < items.Length; i++)
                {
                    inventory2.AddItem(items[i]);
                    shopSellBuyManage.GetComponent<ShopSellBuyManager>()
                        .AddItem(shopSellBuyManage.GetComponent<ShopSellBuyManager>().InventorySellItems, items[i]);
                }
                break;
            default:
                break;
        }
   
    }

  
    public void AddShopItemsInventory()
    {
        AddItems(ringsItems, TypeOfOperation.AddToShop);
        AddItems(earringsItems, TypeOfOperation.AddToShop);
        AddItems(necklacesItems, TypeOfOperation.AddToShop);
        AddItems(helmetsItems, TypeOfOperation.AddToShop);
        AddItems(bodyArmorItems, TypeOfOperation.AddToShop);
        AddItems(pantsItems, TypeOfOperation.AddToShop);
        AddItems(bootsItems, TypeOfOperation.AddToShop);
        AddItems(glovesItems, TypeOfOperation.AddToShop);
        AddItems(bracersItems, TypeOfOperation.AddToShop);
        AddItems(shouldersTtems, TypeOfOperation.AddToShop);
        AddItems(spaceshipItems, TypeOfOperation.AddToShop);

  
        shopSellBuyManage.GetComponent<ShopSellBuyManager>().SortItemList(shopSellBuyManage.GetComponent<ShopSellBuyManager>().ShopItems);
        shopSellBuyManage.GetComponent<ShopSellBuyManager>().CreateShopSlots("Armor");
    }

    public void AddAllItems()
    {
        Debug.Log("All items in Inventory System added!");

        AddItems(ringsItems, TypeOfOperation.AddToInventory);
        AddItems(earringsItems, TypeOfOperation.AddToInventory);
        AddItems(necklacesItems, TypeOfOperation.AddToInventory);
        AddItems(helmetsItems, TypeOfOperation.AddToInventory);
        AddItems(bodyArmorItems, TypeOfOperation.AddToInventory);
        AddItems(pantsItems, TypeOfOperation.AddToInventory);
        AddItems(bootsItems, TypeOfOperation.AddToInventory);
        AddItems(glovesItems, TypeOfOperation.AddToInventory);
        AddItems(bracersItems, TypeOfOperation.AddToInventory);
        AddItems(shouldersTtems, TypeOfOperation.AddToInventory);
        AddItems(spaceshipItems, TypeOfOperation.AddToInventory);
      
        inventory2.SortItemList();
        inventory2.CreateInventorySlots();
        shopSellBuyManage.GetComponent<ShopSellBuyManager>().SortItemList(shopSellBuyManage.GetComponent<ShopSellBuyManager>().InventorySellItems);
        shopSellBuyManage.GetComponent<ShopSellBuyManager>().CreateInventorySlots("Armor");
        shopSellBuyManage.GetComponent<ShopSellBuyManager>().ShopItems.Clear();
        shopSellBuyManage.GetComponent<ShopSellBuyManager>().CreateShopSlots("Armor");
    }

  

    public void RemoveAllItems(Inventory2Manager inventory2)
    {
        inventory2.ClearItemsList();
        inventory2.CreateInventorySlots();
        Debug.Log(" All items in Inventory System 2 was removed!");
        foreach (var item in playerSlots)
        {
            item.ResetPlayerSlot();
        }
        PlayerPrefs.SetInt("PlayerFullHP", 1000);
        PlayerPrefs.SetInt("PlayerFullArmor", 500);
        PlayerPrefs.SetInt("PlayerFullAttack", 20);
        PlayerPrefs.SetInt("SpaceshipFullAttack", 5);
        PlayerPrefs.SetInt("SpaceshipFullHP", 600);
    }





    public void RemoveAllItems()
    {
        inventory2.ClearItemsList();
        inventory2.CreateInventorySlots();
        shopSellBuyManage.GetComponent<ShopSellBuyManager>().InventorySellItems.Clear();
        shopSellBuyManage.GetComponent<ShopSellBuyManager>().CreateInventorySlots();
        shopSellBuyManage.GetComponent<ShopSellBuyManager>().ShopItems.Clear();
        AddShopItemsInventory();
        foreach (var item in playerSlots)
        {
            item.ResetPlayerSlot();
        }
        PlayerPrefs.SetInt("PlayerFullHP", 1000);
        PlayerPrefs.SetInt("PlayerFullArmor", 500);
        PlayerPrefs.SetInt("PlayerFullAttack", 20);
        PlayerPrefs.SetInt("SpaceshipFullAttack", 5);
        PlayerPrefs.SetInt("SpaceshipFullHP", 600);

        Debug.Log(" All items in Inventory System was removed!");
    }



    







    //Function for Inventory number 2
    public void ChestRandomItemSet( int itemNumber)
    {
        chestItemSetNumber = itemNumber;
        var randomHelmetsItems = Random.Range(0, itemsLength);
        var randomBodyArmorItems = Random.Range(0, itemsLength);
        var randomPantsItems = Random.Range(0, itemsLength);
        var randomBootsItems = Random.Range(0, itemsLength);
        var randomGlovesItems = Random.Range(0, itemsLength);
        var randomBracersItems = Random.Range(0, itemsLength);
        var randomShouldersTtems = Random.Range(0, itemsLength);
        var randomRingsItem = Random.Range(0, itemsLength);
        var randomEarringsItem = Random.Range(0, itemsLength);
        var randomNecklacesItem = Random.Range(0, itemsLength);
        var randomspaceshipItem = Random.Range(0, itemsLength);
        InventoryItemData[] randomItems = { helmetsItems[randomHelmetsItems], bodyArmorItems[randomBodyArmorItems], pantsItems[randomPantsItems],
       bootsItems[randomBootsItems], glovesItems[randomGlovesItems], bracersItems[randomBracersItems], shouldersTtems[randomShouldersTtems],
        ringsItems[randomRingsItem], earringsItems[randomEarringsItem], necklacesItems[randomNecklacesItem], spaceshipItems[randomspaceshipItem]};

        chestItemSet = new InventoryItemData[itemNumber];
        for (int i = 0; i < itemNumber; i++)
        {
            var itemsLength = randomItems.Length;

            var randomInventoryItem = Random.Range(0, itemsLength);
            chestItemSet[i] = randomItems[randomInventoryItem];
            mainPanel.SetActive(true);
            inventory2.AddItem(randomItems[randomInventoryItem]);
            inventory2.SortItemList();
            inventory2.CreateInventorySlots();
            mainPanel.SetActive(false);
        }

    }

    


}
