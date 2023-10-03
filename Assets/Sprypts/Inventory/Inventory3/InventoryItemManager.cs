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
    public List<PlayerInvemtorySlot> playerSlots2;
    public List<PlayerInvemtorySlot4> playerSlots4;
    public List<PlayerInvemtorySlot5> playerSlots5;

    public InventoryItemData[] chestItemSet;

    [SerializeField] private GameObject[] itemsSlotsUI;
    [SerializeField] private GameObject mainPanel;
    [SerializeField] private GameObject shopPanel;
    public List<InventoryItemData> inventoryItems;
    [SerializeField] private GameObject shopSellBuyManage4;
    [SerializeField] private GameObject shopItemsManager5;
    public Inventory3Maneger inventory3;
    public Inventory2Manager inventory2;
    public Inventory3ItemSlotUI slotUI;


    public int itemsLength = 10;
    private int numberOfItems = 5;
    private int randomRingsItem;
    private int randomEarringsItem;
    private int randomNecklacesItem;
    private int freeSlot;
    private int randomJewelryItem;

    public int chestItemSetNumber;
    

    private void Start()
    {
        inventoryItems = inventory3.Items;
    }
    //Function for Inventory number 3
    private void CheckInventorySlots()
    {

        for (int itemslot = itemsSlotsUI.Length - 1; itemslot >= 0; itemslot--)
        {

            InventoryItemData itemData = itemsSlotsUI[itemslot].GetComponent<Inventory3ItemSlotUI>().itemData;
            while (itemData == null)
            {
                freeSlot = itemslot;

                Debug.Log("ItemSlot" + itemslot);
                break;
            }

        }

    }
    //Function for Inventory number 3
    public void Add5RandomItems()
    {

        Debug.Log("Items set added!");
        for (int i = 0; i < numberOfItems; i++)
        {
            randomRingsItem = Random.Range(0, itemsLength);
            randomEarringsItem = Random.Range(0, itemsLength);
            randomNecklacesItem = Random.Range(0, itemsLength);

            InventoryItemData[] randomItems = { ringsItems[randomRingsItem], earringsItems[randomEarringsItem], necklacesItems[randomNecklacesItem] };

            var jewelryItemsLength = randomItems.Length;

            randomJewelryItem = Random.Range(0, jewelryItemsLength);
            if (inventory3.Items.Count < 49)
            {
                CheckInventorySlots();
                inventory3.AddItem(randomItems[randomJewelryItem]);
                inventory3.AddItemToInventory(randomItems[randomJewelryItem], itemsSlotsUI[freeSlot]);
            }
            if (inventory3.Items.Count >= 49)
            {
                Debug.Log("Inventory is full!");
            }

        }   
    }
    //Function for Inventory number 3
    public void AddOwnedItems()
    {
        foreach (var item in inventoryItems)
        {
            if (inventory3.Items.Count < 49)
            {
                CheckInventorySlots();
                inventory3.AddItem(item);
                inventory3.AddItemToInventory(item, itemsSlotsUI[freeSlot]);
            }
            if (inventory3.Items.Count >= 49)
            {
                Debug.Log("Inventory is full!");
            }
        }
    }
    //Function for Inventory number 3
    public void AddAllItems(Inventory3Maneger inventory3)
    {

        Debug.Log("All items in Inventory System 3 added!");
        
        for (int i = 0; i < ringsItems.Length; i++)
        {
           
            if (inventory3.Items.Count < 49)
            {
                CheckInventorySlots();
                inventory3.AddItem(ringsItems[i]);
                inventory3.AddItemToInventory(ringsItems[i], itemsSlotsUI[freeSlot]);
            }
            if(inventory3.Items.Count >= 49)
            {
                Debug.Log("Inventory is full!");
            }
           
        }

        for (int i = 0; i < earringsItems.Length; i++)
        {

            if (inventory3.Items.Count < 49)
            {
                CheckInventorySlots();
                inventory3.AddItem(earringsItems[i]);
                inventory3.AddItemToInventory(earringsItems[i], itemsSlotsUI[freeSlot]);
            }
            if (inventory3.Items.Count >= 49)
            {
                Debug.Log("Inventory is full!");
            }

            
        }

        for (int i = 0; i < necklacesItems.Length; i++)
        {
            if (inventory3.Items.Count < 49)
            {
                CheckInventorySlots();
                inventory3.AddItem(necklacesItems[i]);
                inventory3.AddItemToInventory(necklacesItems[i], itemsSlotsUI[freeSlot]);
            }
            if (inventory3.Items.Count >= 49)
            {
                Debug.Log("Inventory is full!");
            }

        }
    }

    public void AddAllItems(Inventory2Manager inventory2)
    {
        Debug.Log("All items in Inventory System 2 added!");
        for (int i = 0; i < ringsItems.Length; i++)
        {
            inventory2.AddItem(ringsItems[i]);
        }

        for (int i = 0; i < earringsItems.Length; i++)
        {
            inventory2.AddItem(earringsItems[i]);
        }

        for (int i = 0; i < necklacesItems.Length; i++)
        {
            inventory2.AddItem(necklacesItems[i]);
        }

        for (int i = 0; i < helmetsItems.Length; i++)
        {
            inventory2.AddItem(helmetsItems[i]);
        }

        for (int i = 0; i < bodyArmorItems.Length; i++)
        {
            inventory2.AddItem(bodyArmorItems[i]);
        }

        for (int i = 0; i < pantsItems.Length; i++)
        {
            inventory2.AddItem(pantsItems[i]);
        }

        for (int i = 0; i < bootsItems.Length; i++)
        {
            inventory2.AddItem(bootsItems[i]);
        }

        for (int i = 0; i < glovesItems.Length; i++)
        {
            inventory2.AddItem(glovesItems[i]);
        }

        for (int i = 0; i < bracersItems.Length; i++)
        {
            inventory2.AddItem(bracersItems[i]);
        }

        for (int i = 0; i < shouldersTtems.Length; i++)
        {
            inventory2.AddItem(shouldersTtems[i]);
        }

        for (int i = 0; i < spaceshipItems.Length; i++)
        {
            inventory2.AddItem(spaceshipItems[i]);
        }
        inventory2.SortItemList();
        inventory2.CreateInventorySlots();
    }
    public void AddShopItemsInventory4()
    {
        for (int i = 0; i < ringsItems.Length; i++)
        {
            shopSellBuyManage4.GetComponent<ShopSellBuyManager4>().AddItem(shopSellBuyManage4.GetComponent<ShopSellBuyManager4>().ShopItems, ringsItems[i]);
        }

        for (int i = 0; i < earringsItems.Length; i++)
        {
            shopSellBuyManage4.GetComponent<ShopSellBuyManager4>().AddItem(shopSellBuyManage4.GetComponent<ShopSellBuyManager4>().ShopItems, earringsItems[i]);
        }

        for (int i = 0; i < necklacesItems.Length; i++)
        {
            shopSellBuyManage4.GetComponent<ShopSellBuyManager4>().AddItem(shopSellBuyManage4.GetComponent<ShopSellBuyManager4>().ShopItems, necklacesItems[i]);
        }

        for (int i = 0; i < helmetsItems.Length; i++)
        {
           shopSellBuyManage4.GetComponent<ShopSellBuyManager4>().AddItem(shopSellBuyManage4.GetComponent<ShopSellBuyManager4>().ShopItems, helmetsItems[i]);
        }

        for (int i = 0; i < bodyArmorItems.Length; i++)
        {
           shopSellBuyManage4.GetComponent<ShopSellBuyManager4>().AddItem(shopSellBuyManage4.GetComponent<ShopSellBuyManager4>().ShopItems, bodyArmorItems[i]);
        }

        for (int i = 0; i < pantsItems.Length; i++)
        {
           shopSellBuyManage4.GetComponent<ShopSellBuyManager4>().AddItem(shopSellBuyManage4.GetComponent<ShopSellBuyManager4>().ShopItems, pantsItems[i]);
        }

        for (int i = 0; i < bootsItems.Length; i++)
        {
           shopSellBuyManage4.GetComponent<ShopSellBuyManager4>().AddItem(shopSellBuyManage4.GetComponent<ShopSellBuyManager4>().ShopItems, bootsItems[i]);
        }

        for (int i = 0; i < glovesItems.Length; i++)
        {
           shopSellBuyManage4.GetComponent<ShopSellBuyManager4>().AddItem(shopSellBuyManage4.GetComponent<ShopSellBuyManager4>().ShopItems, glovesItems[i]);
        }

        for (int i = 0; i < bracersItems.Length; i++)
        {
           shopSellBuyManage4.GetComponent<ShopSellBuyManager4>().AddItem(shopSellBuyManage4.GetComponent<ShopSellBuyManager4>().ShopItems, bracersItems[i]);
        }

        for (int i = 0; i < shouldersTtems.Length; i++)
        {
           shopSellBuyManage4.GetComponent<ShopSellBuyManager4>().AddItem(shopSellBuyManage4.GetComponent<ShopSellBuyManager4>().ShopItems, shouldersTtems[i]);
        }

        for (int i = 0; i < spaceshipItems.Length; i++)
        {
            shopSellBuyManage4.GetComponent<ShopSellBuyManager4>().AddItem(shopSellBuyManage4.GetComponent<ShopSellBuyManager4>().ShopItems, spaceshipItems[i]);
        }
        shopSellBuyManage4.GetComponent<ShopSellBuyManager4>().SortItemList(shopSellBuyManage4.GetComponent<ShopSellBuyManager4>().ShopItems);
        shopSellBuyManage4.GetComponent<ShopSellBuyManager4>().CreateShopSlots("Armor");
    }

    public void AddAllItems(Inventory4Manager inventory4)
    {
        Debug.Log("All items in Inventory System 4 added!");
        for (int i = 0; i < ringsItems.Length; i++)
        {
            inventory4.AddItem(ringsItems[i]);
            shopSellBuyManage4.GetComponent<ShopSellBuyManager4>().AddItem(shopSellBuyManage4.GetComponent<ShopSellBuyManager4>().InventorySellItems, ringsItems[i]);
        }

        for (int i = 0; i < earringsItems.Length; i++)
        {
            inventory4.AddItem(earringsItems[i]);
            shopSellBuyManage4.GetComponent<ShopSellBuyManager4>().AddItem(shopSellBuyManage4.GetComponent<ShopSellBuyManager4>().InventorySellItems, ringsItems[i]);
        }

        for (int i = 0; i < necklacesItems.Length; i++)
        {
            inventory4.AddItem(necklacesItems[i]);
            shopSellBuyManage4.GetComponent<ShopSellBuyManager4>().AddItem(shopSellBuyManage4.GetComponent<ShopSellBuyManager4>().InventorySellItems, necklacesItems[i]);
        }

        for (int i = 0; i < helmetsItems.Length; i++)
        {
            inventory4.AddItem(helmetsItems[i]);
            shopSellBuyManage4.GetComponent<ShopSellBuyManager4>().AddItem(shopSellBuyManage4.GetComponent<ShopSellBuyManager4>().InventorySellItems, helmetsItems[i]);
        }

        for (int i = 0; i < bodyArmorItems.Length; i++)
        {
            inventory4.AddItem(bodyArmorItems[i]);
            shopSellBuyManage4.GetComponent<ShopSellBuyManager4>().AddItem(shopSellBuyManage4.GetComponent<ShopSellBuyManager4>().InventorySellItems, bodyArmorItems[i]);
        }

        for (int i = 0; i < pantsItems.Length; i++)
        {
            inventory4.AddItem(pantsItems[i]);
            shopSellBuyManage4.GetComponent<ShopSellBuyManager4>().AddItem(shopSellBuyManage4.GetComponent<ShopSellBuyManager4>().InventorySellItems, pantsItems[i]);
        }

        for (int i = 0; i < bootsItems.Length; i++)
        {
            inventory4.AddItem(bootsItems[i]);
            shopSellBuyManage4.GetComponent<ShopSellBuyManager4>().AddItem(shopSellBuyManage4.GetComponent<ShopSellBuyManager4>().InventorySellItems, bootsItems[i]);
        }

        for (int i = 0; i < glovesItems.Length; i++)
        {
            inventory4.AddItem(glovesItems[i]);
            shopSellBuyManage4.GetComponent<ShopSellBuyManager4>().AddItem(shopSellBuyManage4.GetComponent<ShopSellBuyManager4>().InventorySellItems, glovesItems[i]);
        }

        for (int i = 0; i < bracersItems.Length; i++)
        {
            inventory4.AddItem(bracersItems[i]);
            shopSellBuyManage4.GetComponent<ShopSellBuyManager4>().AddItem(shopSellBuyManage4.GetComponent<ShopSellBuyManager4>().InventorySellItems, bracersItems[i]);
        }

        for (int i = 0; i < shouldersTtems.Length; i++)
        {
            inventory4.AddItem(shouldersTtems[i]);
            shopSellBuyManage4.GetComponent<ShopSellBuyManager4>().AddItem(shopSellBuyManage4.GetComponent<ShopSellBuyManager4>().InventorySellItems, shouldersTtems[i]);
        }

        for (int i = 0; i < spaceshipItems.Length; i++)
        {
            inventory4.AddItem(spaceshipItems[i]);
            shopSellBuyManage4.GetComponent<ShopSellBuyManager4>().AddItem(shopSellBuyManage4.GetComponent<ShopSellBuyManager4>().InventorySellItems, spaceshipItems[i]);
        }
        inventory4.SortItemList();
        inventory4.CreateInventorySlots("Armor");
        shopSellBuyManage4.GetComponent<ShopSellBuyManager4>().SortItemList(shopSellBuyManage4.GetComponent<ShopSellBuyManager4>().InventorySellItems);
        shopSellBuyManage4.GetComponent<ShopSellBuyManager4>().CreateInventorySlots("Armor");
        shopSellBuyManage4.GetComponent<ShopSellBuyManager4>().ShopItems.Clear();
        shopSellBuyManage4.GetComponent<ShopSellBuyManager4>().CreateShopSlots("Armor");
    }

    public void AddShopItemsInventory5()
    {
        for (int i = 0; i < ringsItems.Length; i++)
        {
            shopItemsManager5.GetComponent<ShopItemsManager5>().AddItem(shopItemsManager5.GetComponent<ShopItemsManager5>().ShopItems, ringsItems[i]);
        }

        for (int i = 0; i < earringsItems.Length; i++)
        {
            shopItemsManager5.GetComponent<ShopItemsManager5>().AddItem(shopItemsManager5.GetComponent<ShopItemsManager5>().ShopItems, earringsItems[i]);
        }

        for (int i = 0; i < necklacesItems.Length; i++)
        {
            shopItemsManager5.GetComponent<ShopItemsManager5>().AddItem(shopItemsManager5.GetComponent<ShopItemsManager5>().ShopItems, necklacesItems[i]);
        }

        for (int i = 0; i < helmetsItems.Length; i++)
        {
            shopItemsManager5.GetComponent<ShopItemsManager5>().AddItem(shopItemsManager5.GetComponent<ShopItemsManager5>().ShopItems, helmetsItems[i]);
        }

        for (int i = 0; i < bodyArmorItems.Length; i++)
        {
            shopItemsManager5.GetComponent<ShopItemsManager5>().AddItem(shopItemsManager5.GetComponent<ShopItemsManager5>().ShopItems, bodyArmorItems[i]);
        }

        for (int i = 0; i < pantsItems.Length; i++)
        {
            shopItemsManager5.GetComponent<ShopItemsManager5>().AddItem(shopItemsManager5.GetComponent<ShopItemsManager5>().ShopItems, pantsItems[i]);
        }

        for (int i = 0; i < bootsItems.Length; i++)
        {
            shopItemsManager5.GetComponent<ShopItemsManager5>().AddItem(shopItemsManager5.GetComponent<ShopItemsManager5>().ShopItems, bootsItems[i]);
        }

        for (int i = 0; i < glovesItems.Length; i++)
        {
            shopItemsManager5.GetComponent<ShopItemsManager5>().AddItem(shopItemsManager5.GetComponent<ShopItemsManager5>().ShopItems, glovesItems[i]);
        }

        for (int i = 0; i < bracersItems.Length; i++)
        {
            shopItemsManager5.GetComponent<ShopItemsManager5>().AddItem(shopItemsManager5.GetComponent<ShopItemsManager5>().ShopItems, bracersItems[i]);
        }

        for (int i = 0; i < shouldersTtems.Length; i++)
        {
            shopItemsManager5.GetComponent<ShopItemsManager5>().AddItem(shopItemsManager5.GetComponent<ShopItemsManager5>().ShopItems, shouldersTtems[i]);
        }

        shopItemsManager5.GetComponent<ShopItemsManager5>().SortItemList(shopItemsManager5.GetComponent<ShopItemsManager5>().ShopItems);
        //shopItemsManager5.GetComponent<ShopItemsManager5>().CreateShopSlots("Armor");
    }
    public void AddAllItems(Inventory5Manager inventory5)
    {
        Debug.Log("All items in Inventory System 5 added!");
        for (int i = 0; i < ringsItems.Length; i++)
        {
            inventory5.AddItem(ringsItems[i]);
        }

        for (int i = 0; i < earringsItems.Length; i++)
        {
            inventory5.AddItem(earringsItems[i]);
        }

        for (int i = 0; i < necklacesItems.Length; i++)
        {
            inventory5.AddItem(necklacesItems[i]);
        }

        for (int i = 0; i < helmetsItems.Length; i++)
        {
            inventory5.AddItem(helmetsItems[i]);
        }

        for (int i = 0; i < bodyArmorItems.Length; i++)
        {
            inventory5.AddItem(bodyArmorItems[i]);
        }

        for (int i = 0; i < pantsItems.Length; i++)
        {
            inventory5.AddItem(pantsItems[i]);
        }

        for (int i = 0; i < bootsItems.Length; i++)
        {
            inventory5.AddItem(bootsItems[i]);
        }

        for (int i = 0; i < glovesItems.Length; i++)
        {
            inventory5.AddItem(glovesItems[i]);
        }

        for (int i = 0; i < bracersItems.Length; i++)
        {
            inventory5.AddItem(bracersItems[i]);
        }

        for (int i = 0; i < shouldersTtems.Length; i++)
        {
            inventory5.AddItem(shouldersTtems[i]);
        }
        inventory5.SortItemList();
        inventory5.CreateInventorySlots();

        
        shopItemsManager5.GetComponent<ShopItemsManager5>().ShopItems.Clear();
        

    }
    public void RemoveAllItems(Inventory2Manager inventory2)
    {
        inventory2.ClearItemsList();
        inventory2.CreateInventorySlots();
        Debug.Log(" All items in Inventory System 2 was removed!");
        foreach (var item in playerSlots2)
        {
            item.ResetPlayerSlot();
        }
        PlayerPrefs.SetInt("PlayerFullHP", 1000);
        PlayerPrefs.SetInt("PlayerFullArmor", 500);
        PlayerPrefs.SetInt("PlayerFullAttack", 20);
        PlayerPrefs.SetInt("SpaceshipFullAttack", 5);
        PlayerPrefs.SetInt("SpaceshipFullHP", 600);
    }

 
    //Function for Inventory number 3
    public void RemoveAllItems(Inventory3Maneger inventory3)
    {
        inventory3.Items.Clear();
        UpdateInventory();
        Debug.Log(" All items in Inventory System 3 was removed!");
       
    }



    public void RemoveAllItems(Inventory4Manager inventory4)
    {
        inventory4.InventoryItems.Clear();
        inventory4.CreateInventorySlots();
        shopSellBuyManage4.GetComponent<ShopSellBuyManager4>().InventorySellItems.Clear();
        shopSellBuyManage4.GetComponent<ShopSellBuyManager4>().CreateInventorySlots();
        shopSellBuyManage4.GetComponent<ShopSellBuyManager4>().ShopItems.Clear();
        AddShopItemsInventory4();
        foreach (var item in playerSlots4)
        {
            item.ResetPlayerSlot();
        }
        PlayerPrefs.SetInt("PlayerFullHP", 1000);
        PlayerPrefs.SetInt("PlayerFullArmor", 500);
        PlayerPrefs.SetInt("PlayerFullAttack", 20);
        PlayerPrefs.SetInt("SpaceshipFullAttack", 5);
        PlayerPrefs.SetInt("SpaceshipFullHP", 600);

        Debug.Log(" All items in Inventory System 4 was removed!");
    }

    public void RemoveAllItems(Inventory5Manager inventory5)
    {
        inventory5.InventoryItems.Clear();
        inventory5.CreateInventorySlots();
        shopItemsManager5.GetComponent<ShopItemsManager5>().ShopItems.Clear();
        AddShopItemsInventory5();
        foreach (var item in playerSlots5)
        {
            item.ResetPlayerSlot();
        }
        PlayerPrefs.SetInt("PlayerFullHP", 1000);
        PlayerPrefs.SetInt("PlayerFullArmor", 500);
        PlayerPrefs.SetInt("PlayerFullAttack", 20);

        Debug.Log(" All items in Inventory System 4 was removed!");
    }

    
    //Function for Inventory number 3

    public void UpdateInventory()
    {
        for (int i = 0; i < itemsSlotsUI.Length; i++)
        {
            itemsSlotsUI[i].GetComponent<Inventory3ItemSlotUI>().ClearSlot();
            itemsSlotsUI[i].GetComponent<Inventory3ItemSlotUI>().itemData = null;
        }

        for (int i = 0; i < inventoryItems.Count; i++)
        {
            inventory3.AddItemToInventory(inventoryItems[i], itemsSlotsUI[i]);
            itemsSlotsUI[i].GetComponent<Inventory3ItemSlotUI>().SetToDefault();
        }
    }
    public void Update()
    {
        //inventoryItems = inventory3.Items;
    }
    public void GetItemDataFromUISlot(GameObject itemSlotUI)
    {
        InventoryItemData currentItemData = itemSlotUI.GetComponent<Inventory3ItemSlotUI>().itemData;

    }



    public void RemoweItem(InventoryItemData itemData)
    {
        inventory3.RemoveItem(itemData);
        //inventory3.RemoveItemFromInventory(itemData, );
        UpdateInventory();
        
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
