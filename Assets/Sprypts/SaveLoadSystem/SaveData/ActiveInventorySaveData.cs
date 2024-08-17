using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class ActiveInventorySaveData : MonoBehaviour
{
    [SerializeField] private Inventory2Manager inventoty2Manager;
    [SerializeField] private ShopSellBuyManager shopSellBuyManager;
    [SerializeField] private InventoryItemManager inventoryItemManager;

    public List<PlayerInvemtorySlot> playerSlotsInventory2List = new List<PlayerInvemtorySlot>();
    public List<InventoryItemData> playerSlotsInventory2ItemData = new List<InventoryItemData>();

    [SerializeField] private Button saveButton;
    [SerializeField] private GameObject saveGameInfoPanel;
    [SerializeField] private GameObject loadGameInfoPanel;

    private ActiveInventoryData MyActiveInventoryData = new ActiveInventoryData();
    private KredytsData MyKredytsData = new KredytsData();
    private InventorySystemData MyInventorySystem2Data = new InventorySystemData();

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
    private void SetPlayerInventorySlotsData()
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

    private void GetInventoryData()
    {
        inventorySystemActive = PlayerPrefs.GetInt("InventorySystemActive");
        MyActiveInventoryData.activeInventorySystemID = PlayerPrefs.GetInt("InventorySystemActive");
        MyKredytsData.yourKredytsNumber = PlayerPrefs.GetFloat("yourKredytNumber");

        MyInventorySystem2Data.inventory2 = inventoty2Manager.Items;
        GetItemDataInventor2Value();
        MyInventorySystem2Data.inventorySellItems = shopSellBuyManager.InventorySellItems;
        MyInventorySystem2Data.shopItems = shopSellBuyManager.ShopItems;
        MyInventorySystem2Data.playerSlotsInventory2ItemData = playerSlotsInventory2ItemData;
        MyInventorySystem2Data.playerFullHP = PlayerPrefs.GetInt("PlayerFullHP");
        MyInventorySystem2Data.playerFullArmor = PlayerPrefs.GetInt("PlayerFullArmor");
        MyInventorySystem2Data.playerFullAttack = PlayerPrefs.GetInt("PlayerFullAttack");
        MyInventorySystem2Data.spaceshipFullAttack = PlayerPrefs.GetInt("SpaceshipFullAttack");
        MyInventorySystem2Data.spaceshipFullHP = PlayerPrefs.GetInt("SpaceshipFullHP");
    }

    public void SaveData()
    {
        SaveGameManeger.CurrentGameSaveData.ActiveInventorySaveData = MyActiveInventoryData;
        SaveGameManeger.CurrentGameSaveData.KredytsData = MyKredytsData;
        SaveGameManeger.CurrentGameSaveData.InventorySystemData = MyInventorySystem2Data;
        SaveGameManeger.Save();
        saveGameInfoPanel.SetActive(true);
        isSaveOn = false;
        PlayerPrefs.SetInt("GameSaved", 1);
    }

    public void LoadData()
    {
        SaveGameManeger.Load();
        MyActiveInventoryData = SaveGameManeger.CurrentGameSaveData.ActiveInventorySaveData;
        PlayerPrefs.SetInt("InventorySystemActive", MyActiveInventoryData.activeInventorySystemID);

        MyKredytsData = SaveGameManeger.CurrentGameSaveData.KredytsData;
        PlayerPrefs.SetFloat("yourKredytNumber", MyKredytsData.yourKredytsNumber);

        MyInventorySystem2Data = SaveGameManeger.CurrentGameSaveData.InventorySystemData;
        inventoty2Manager.Items = MyInventorySystem2Data.inventory2;
        shopSellBuyManager.InventorySellItems = MyInventorySystem2Data.inventorySellItems;
        shopSellBuyManager.ShopItems = MyInventorySystem2Data.shopItems;
        playerSlotsInventory2ItemData = MyInventorySystem2Data.playerSlotsInventory2ItemData;
        SetPlayerInventorySlotsData();
        inventoty2Manager.CreateInventorySlots();
        PlayerPrefs.SetInt("PlayerFullHP", MyInventorySystem2Data.playerFullHP);
        PlayerPrefs.SetInt("PlayerFullArmor", MyInventorySystem2Data.playerFullArmor);
        PlayerPrefs.SetInt("PlayerFullAttack", MyInventorySystem2Data.playerFullAttack);
        PlayerPrefs.SetInt("SpaceshipFullAttack", MyInventorySystem2Data.spaceshipFullAttack);
        PlayerPrefs.SetInt("SpaceshipFullHP", MyInventorySystem2Data.spaceshipFullHP);


        loadGameInfoPanel.SetActive(true);
        PlayerPrefs.SetInt("GameLoaded", 0);
    }
    private void Update()
    {
        GetInventoryData();
        autoLoadOn = PlayerPrefs.GetInt("AutoLoadOn");
        autoSaveOn = PlayerPrefs.GetInt("AutoSaveOn");
        saveButton.onClick.AddListener(SetSaveOn);
        SetLoadOn();

        if (Input.GetKeyDown("s") || isSaveOn == true)
        {
            SaveData();
        }

        if (Input.GetKeyDown("l") || isLoadOn == 1)
        {
            LoadData();
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
public struct InventorySystemData
{
    public List<InventoryItemData> inventory2;
    public List<InventoryItemData> playerSlotsInventory2ItemData;
    public List<InventoryItemData> inventorySellItems;
    public List<InventoryItemData> shopItems;
    public List<InventoryItemData> playerSlotsInventory4ItemData;
    public int playerFullHP;
    public int playerFullArmor;
    public int playerFullAttack;
    public int spaceshipFullAttack;
    public int spaceshipFullHP;

}





