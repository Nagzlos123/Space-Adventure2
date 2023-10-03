using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class ActiveInventorySaveData : MonoBehaviour
{
    [SerializeField] private Inventory2Manager inventoty2Manager;
    [SerializeField] private Inventory3Maneger inventoty3Manager;
    [SerializeField] private Inventory4Manager inventoty4Manager;
    [SerializeField] private Inventory5Manager inventoty5Manager;

    [SerializeField] private ShopSellBuyManager4 shopSellBuyManager;
    [SerializeField] private ShopItemsManager5 shopItemsManager5;
    [SerializeField] private InventoryItemManager inventoryItemManager;

    public List<PlayerInvemtorySlot> playerSlotsInventory2List = new List<PlayerInvemtorySlot>();
    public List<GameObject> playerUpgradesInventory3List = new List<GameObject>();
    public List<PlayerInvemtorySlot4> playerSlotsInventory4List = new List<PlayerInvemtorySlot4>();
    public List<InventoryItemData> playerSlotsInventory2ItemData = new List<InventoryItemData>();
    public List<InventoryItemData> playerSlotsInventory4ItemData = new List<InventoryItemData>();
    public List<int> playerSlotsInventory3ItemData = new List<int>();
   

    [SerializeField] private Button saveButton;
    [SerializeField] private GameObject saveGameInfoPanel;
    [SerializeField] private GameObject loadGameInfoPanel;

    private ActiveInventoryData MyActiveInventoryData = new ActiveInventoryData();
    private KredytsData MyKredytsData = new KredytsData();
    private InventorySystem2Data MyInventorySystem2Data = new InventorySystem2Data();
    private InventorySystem3Data MyInventorySystem3Data = new InventorySystem3Data();
    private InventorySystem4Data MyInventorySystem4Data = new InventorySystem4Data();
    private InventorySystem5Data MyInventorySystem5Data = new InventorySystem5Data();
    private bool isSaveOn = false;
    private int isLoadOn = 0;
    private int autoLoadOn;
    private int autoSaveOn;
    private bool getItemDataValue = true;
    public int inventorySystemActive;

    private void Start()
    {
        //AddElemetsToDictionary();
     
    }
    private void SetSaveOn()
    {
        isSaveOn = true;
    }

    private void SetLoadOn()
    {
        isLoadOn = PlayerPrefs.GetInt("GameLoaded");
    }
    public void SetAutoSaveOn()
    {
        PlayerPrefs.SetInt("AutoSaveOn", 0);
    }

    private void GetItemDataInventor2Value()
    {
        if (playerSlotsInventory2ItemData.Count == 11)
        {
            playerSlotsInventory2ItemData.Clear();
        }
        foreach (var item in playerSlotsInventory2List)
        {
            
            playerSlotsInventory2ItemData.Add(item.GetComponent<PlayerInvemtorySlot>().itemData);
        }
    }

    private void GetItemDataInventor3Value()
    {
        if (playerSlotsInventory3ItemData.Count == 10)
        {
            playerSlotsInventory3ItemData.Clear();
        }
        foreach (var item in playerUpgradesInventory3List)
        {

            playerSlotsInventory3ItemData.Add(item.GetComponent<InventoryUpgradeManager>().itemDataID);
        }
    }

    private void GetItemDataInventor4Value()
    {
        if (playerSlotsInventory4ItemData.Count == 10)
        {
            playerSlotsInventory4ItemData.Clear();
        }
        foreach (var item in playerSlotsInventory4List)
        {

            playerSlotsInventory4ItemData.Add(item.GetComponent<PlayerInvemtorySlot4>().itemData);
        }
    }

    private void SetPlayerInventory2SlotsData()
    {
        List<InventoryItemData> tmpList = new List<InventoryItemData>();
        tmpList = MyInventorySystem2Data.playerSlotsInventory2ItemData;
        InventoryItemData[] arrayOfItemData = tmpList.ToArray();
        int itemDataID = 0;
        foreach (var item in playerSlotsInventory2List)
        {
           
            item.itemData = arrayOfItemData[itemDataID];
            if (item.itemData != null)
                item.itemIcon.GetComponent<Image>().sprite = item.itemData.itemIcon;
            itemDataID++;

        }
    }
    private void SetPlayerInventory3SlotsData()
    {
        List<int> tmpList = new List<int>();
        tmpList = MyInventorySystem3Data.playerSlotsInventory3ItemData;
        int [] arrayOfItemData = tmpList.ToArray();
        int itemDataID = 0;
        foreach (var item in playerUpgradesInventory3List)
        {
            item.GetComponent<InventoryUpgradeManager>().itemDataID = arrayOfItemData[itemDataID];
            item.GetComponent<InventoryUpgradeManager>().ExecuteChanges2();
            
            itemDataID++;

        }
    }

    private void SetPlayerInventory4SlotsData()
    {
        List<InventoryItemData> tmpList = new List<InventoryItemData>();
        tmpList = MyInventorySystem4Data.playerSlotsInventory4ItemData;
        InventoryItemData[] arrayOfItemData = tmpList.ToArray();
        int itemDataID = 0;
        foreach (var item in playerSlotsInventory4List)
        {
            //if(arrayOfItemData[itemDataID] != null) 
            item.itemData = arrayOfItemData[itemDataID];
            if (item.itemData != null)
                item.itemIcon.GetComponent<Image>().sprite = item.itemData.itemIcon;
            itemDataID++;

        }
    }
    public void AutoSave()
    {
        SaveGameManeger.CurrentGameSaveData.ActiveInventorySaveData = MyActiveInventoryData;
        SaveGameManeger.CurrentGameSaveData.KredytsData = MyKredytsData;
        SaveGameManeger.CurrentGameSaveData.InventorySystem2Data = MyInventorySystem2Data;
        SaveGameManeger.CurrentGameSaveData.InventorySystem3Data = MyInventorySystem3Data;
        SaveGameManeger.CurrentGameSaveData.InventorySystem4Data = MyInventorySystem4Data;
        SaveGameManeger.CurrentGameSaveData.InventorySystem5Data = MyInventorySystem5Data;
        SaveGameManeger.Save();
    }

    public void AutoLoad()
    {
        SaveGameManeger.Load();
        MyActiveInventoryData = SaveGameManeger.CurrentGameSaveData.ActiveInventorySaveData;
        PlayerPrefs.SetInt("InventorySystemActive", MyActiveInventoryData.activeInventorySystemID);

        MyKredytsData = SaveGameManeger.CurrentGameSaveData.KredytsData;
        PlayerPrefs.SetFloat("yourKredytNumber", MyKredytsData.yourKredytsNumber);

        MyInventorySystem2Data = SaveGameManeger.CurrentGameSaveData.InventorySystem2Data;
        inventoty2Manager.Items = MyInventorySystem2Data.inventory2;
        playerSlotsInventory2ItemData = MyInventorySystem2Data.playerSlotsInventory2ItemData;
        //SetPlayerInventory2SlotsData();
        inventoty2Manager.CreateInventorySlots();
        PlayerPrefs.SetInt("PlayerFullHP", MyInventorySystem2Data.playerFullHP);
        PlayerPrefs.SetInt("PlayerFullArmor", MyInventorySystem2Data.playerFullArmor);
        PlayerPrefs.SetInt("PlayerFullAttack", MyInventorySystem2Data.playerFullAttack);
        PlayerPrefs.SetInt("SpaceshipFullAttack", MyInventorySystem2Data.spaceshipFullAttack);
        PlayerPrefs.SetInt("SpaceshipFullHP", MyInventorySystem2Data.spaceshipFullHP);




        MyInventorySystem3Data = SaveGameManeger.CurrentGameSaveData.InventorySystem3Data;
        //inventoryItemManager.RemoveAllItems(inventoty3Manager);
        inventoty3Manager.Items = MyInventorySystem3Data.inventory3;
        //inventoryItemManager.AddOwnedItems();
        //inventoryItemManager.UpdateInventory();
        if (inventorySystemActive == 3)
        {
            //playerSlotsInventory3ItemData = MyInventorySystem3Data.playerSlotsInventory3ItemData;
            //SetPlayerInventory3SlotsData();
        }



        MyInventorySystem4Data = SaveGameManeger.CurrentGameSaveData.InventorySystem4Data;
        inventoty4Manager.InventoryItems = MyInventorySystem4Data.inventory4;
        shopSellBuyManager.InventorySellItems = MyInventorySystem4Data.inventorySellItems;
        shopSellBuyManager.ShopItems = MyInventorySystem4Data.shopItems;
        //SetPlayerInventory4SlotsData();
        PlayerPrefs.SetInt("PlayerFullHP", MyInventorySystem4Data.playerFullHP);
        PlayerPrefs.SetInt("PlayerFullArmor", MyInventorySystem4Data.playerFullArmor);
        PlayerPrefs.SetInt("PlayerFullAttack", MyInventorySystem4Data.playerFullAttack);
        PlayerPrefs.SetInt("SpaceshipFullAttack", MyInventorySystem4Data.spaceshipFullAttack);
        PlayerPrefs.SetInt("SpaceshipFullHP", MyInventorySystem4Data.spaceshipFullHP);



        MyInventorySystem5Data = SaveGameManeger.CurrentGameSaveData.InventorySystem5Data;
        inventoty5Manager.InventoryItems = MyInventorySystem5Data.inventory5;
        shopItemsManager5.ShopItems = MyInventorySystem5Data.shopItems;



        loadGameInfoPanel.SetActive(true);
        //PlayerPrefs.SetInt("GameLoaded", 0);
    
}
    private void Update()
    {
        inventorySystemActive = PlayerPrefs.GetInt("InventorySystemActive");
        MyActiveInventoryData.activeInventorySystemID = PlayerPrefs.GetInt("InventorySystemActive");
        MyKredytsData.yourKredytsNumber = PlayerPrefs.GetFloat("yourKredytNumber");

        MyInventorySystem2Data.inventory2 = inventoty2Manager.Items;
        GetItemDataInventor2Value();
        MyInventorySystem2Data.playerSlotsInventory2ItemData = playerSlotsInventory2ItemData;
        MyInventorySystem2Data.playerFullHP = PlayerPrefs.GetInt("PlayerFullHP");
        MyInventorySystem2Data.playerFullArmor = PlayerPrefs.GetInt("PlayerFullArmor");
        MyInventorySystem2Data.playerFullAttack = PlayerPrefs.GetInt("PlayerFullAttack");
        MyInventorySystem2Data.spaceshipFullAttack = PlayerPrefs.GetInt("SpaceshipFullAttack");
        MyInventorySystem2Data.spaceshipFullHP = PlayerPrefs.GetInt("SpaceshipFullHP");
        
        MyInventorySystem3Data.inventory3 = inventoty3Manager.Items;
        //GetItemDataInventor3Value();
        MyInventorySystem3Data.playerSlotsInventory3ItemData = playerSlotsInventory3ItemData;

        MyInventorySystem4Data.inventory4 = inventoty4Manager.InventoryItems;
        //GetItemDataInventor4Value();
        MyInventorySystem4Data.inventorySellItems = shopSellBuyManager.InventorySellItems;
        MyInventorySystem4Data.shopItems = shopSellBuyManager.ShopItems;
        MyInventorySystem4Data.playerFullHP = PlayerPrefs.GetInt("PlayerFullHP");
        MyInventorySystem4Data.playerFullArmor = PlayerPrefs.GetInt("PlayerFullArmor");
        MyInventorySystem4Data.playerFullAttack = PlayerPrefs.GetInt("PlayerFullAttack");
        MyInventorySystem4Data.spaceshipFullAttack = PlayerPrefs.GetInt("SpaceshipFullAttack");
        MyInventorySystem4Data.spaceshipFullHP = PlayerPrefs.GetInt("SpaceshipFullHP");

        MyInventorySystem5Data.inventory5 = inventoty5Manager.InventoryItems;
        MyInventorySystem5Data.shopItems = shopItemsManager5.ShopItems;

        autoLoadOn = PlayerPrefs.GetInt("AutoLoadOn");
        autoSaveOn = PlayerPrefs.GetInt("AutoSaveOn");
        saveButton.onClick.AddListener(SetSaveOn);
        SetLoadOn();

        if (Input.GetKeyDown("s") || isSaveOn == true)
        {
            SaveGameManeger.CurrentGameSaveData.ActiveInventorySaveData = MyActiveInventoryData;
            SaveGameManeger.CurrentGameSaveData.KredytsData = MyKredytsData;
            SaveGameManeger.CurrentGameSaveData.InventorySystem2Data = MyInventorySystem2Data;
            SaveGameManeger.CurrentGameSaveData.InventorySystem3Data = MyInventorySystem3Data;
            SaveGameManeger.CurrentGameSaveData.InventorySystem4Data = MyInventorySystem4Data;
            SaveGameManeger.CurrentGameSaveData.InventorySystem5Data = MyInventorySystem5Data;
            SaveGameManeger.Save();
            saveGameInfoPanel.SetActive(true);
            isSaveOn = false;
        }

        if (Input.GetKeyDown("l") || isLoadOn == 1)
        {
            SaveGameManeger.Load();
            MyActiveInventoryData = SaveGameManeger.CurrentGameSaveData.ActiveInventorySaveData;
            PlayerPrefs.SetInt("InventorySystemActive", MyActiveInventoryData.activeInventorySystemID);

            MyKredytsData = SaveGameManeger.CurrentGameSaveData.KredytsData;
            PlayerPrefs.SetFloat("yourKredytNumber", MyKredytsData.yourKredytsNumber);
           
                MyInventorySystem2Data = SaveGameManeger.CurrentGameSaveData.InventorySystem2Data;
                inventoty2Manager.Items = MyInventorySystem2Data.inventory2;
                playerSlotsInventory2ItemData = MyInventorySystem2Data.playerSlotsInventory2ItemData;
                //SetPlayerInventory2SlotsData();
                inventoty2Manager.CreateInventorySlots();
                PlayerPrefs.SetInt("PlayerFullHP", MyInventorySystem2Data.playerFullHP);
                PlayerPrefs.SetInt("PlayerFullArmor", MyInventorySystem2Data.playerFullArmor);
                PlayerPrefs.SetInt("PlayerFullAttack", MyInventorySystem2Data.playerFullAttack);
                PlayerPrefs.SetInt("SpaceshipFullAttack", MyInventorySystem2Data.spaceshipFullAttack);
                PlayerPrefs.SetInt("SpaceshipFullHP", MyInventorySystem2Data.spaceshipFullHP);
            
       

          
                MyInventorySystem3Data = SaveGameManeger.CurrentGameSaveData.InventorySystem3Data;
                //inventoryItemManager.RemoveAllItems(inventoty3Manager);
                inventoty3Manager.Items = MyInventorySystem3Data.inventory3;
                //inventoryItemManager.AddOwnedItems();
                //inventoryItemManager.UpdateInventory();
            if (inventorySystemActive == 3)
            {
                //playerSlotsInventory3ItemData = MyInventorySystem3Data.playerSlotsInventory3ItemData;
                //SetPlayerInventory3SlotsData();
            }


           
                MyInventorySystem4Data = SaveGameManeger.CurrentGameSaveData.InventorySystem4Data;
                inventoty4Manager.InventoryItems = MyInventorySystem4Data.inventory4;
                shopSellBuyManager.InventorySellItems = MyInventorySystem4Data.inventorySellItems;
                shopSellBuyManager.ShopItems = MyInventorySystem4Data.shopItems;
                //SetPlayerInventory4SlotsData();
                PlayerPrefs.SetInt("PlayerFullHP", MyInventorySystem4Data.playerFullHP);
                PlayerPrefs.SetInt("PlayerFullArmor", MyInventorySystem4Data.playerFullArmor);
                PlayerPrefs.SetInt("PlayerFullAttack", MyInventorySystem4Data.playerFullAttack);
                PlayerPrefs.SetInt("SpaceshipFullAttack", MyInventorySystem4Data.spaceshipFullAttack);
                PlayerPrefs.SetInt("SpaceshipFullHP", MyInventorySystem4Data.spaceshipFullHP);
            

          
                MyInventorySystem5Data = SaveGameManeger.CurrentGameSaveData.InventorySystem5Data;
                inventoty5Manager.InventoryItems = MyInventorySystem5Data.inventory5;
                shopItemsManager5.ShopItems = MyInventorySystem5Data.shopItems;
            


            loadGameInfoPanel.SetActive(true);
            PlayerPrefs.SetInt("GameLoaded", 0);
        }

        if (autoLoadOn == 1)
        {
            //AutoLoad();
            PlayerPrefs.SetInt("AutoLoadOn", 0);
        }

        if (autoSaveOn == 1)
        {
            //AutoSave();
            PlayerPrefs.SetInt("AutoSaveOn", 0);
        }
    }
}

[System.Serializable]
public struct ActiveInventoryData
{
    public int activeInventorySystemID;
}

[System.Serializable]
public struct KredytsData
{
    public float yourKredytsNumber;
}

[System.Serializable]
public struct InventorySystem2Data
{
    public List<InventoryItemData> inventory2;
    public List<InventoryItemData> playerSlotsInventory2ItemData;
    public int playerFullHP;
    public int playerFullArmor;
    public int playerFullAttack;
    public int spaceshipFullAttack;
    public int spaceshipFullHP;

}
[System.Serializable]
public struct InventorySystem3Data
{
    public List<InventoryItemData> inventory3;
    public List<int> playerSlotsInventory3ItemData;
}

[System.Serializable]
public struct InventorySystem4Data
{
    public List<InventoryItemData> inventory4;
    public List<InventoryItemData> inventorySellItems;
    public List<InventoryItemData> shopItems;
    public List<InventoryItemData> playerSlotsInventory4ItemData;
    public int playerFullHP;
    public int playerFullArmor;
    public int playerFullAttack;
    public int spaceshipFullAttack;
    public int spaceshipFullHP;
}

[System.Serializable]
public struct InventorySystem5Data
{
    public List<InventoryItemData> inventory5;
    public List<InventoryItemData> shopItems;
    public int playerFullHP;
    public int playerFullArmor;
    public int playerFullAttack;

}
