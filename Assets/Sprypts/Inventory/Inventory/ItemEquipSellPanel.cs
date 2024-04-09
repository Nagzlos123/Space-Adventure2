using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemEquipSellPanel : MonoBehaviour
{
    public InventoryItemData itemData;
    public GameObject[] playerSlots;
    [SerializeField] private TextMeshProUGUI itemDescryption;
    [SerializeField] private TextMeshProUGUI itemPrice;
    [SerializeField] private TextMeshProUGUI yourKredytsAmount;
    [SerializeField] private GameObject itemIcon;
    [SerializeField] private GameObject kredytsManager;
    [SerializeField] private StatsUpgradeManager upgradeManager;
    public Inventory2Manager inventory2;
    

    private float yourKredyts;
    private float price;
    public string itemCategory;
    public string itemSubCategory;
    private void Start()
    {
        GetItemData();
    }
    public void EquipItem()
    {
       
        for (int i = 0; i < playerSlots.Length; i++)
        {
            
            if(itemCategory == playerSlots[i].GetComponent<PlayerInvemtorySlot>().acceptableSlotCategory 
                && itemSubCategory == playerSlots[i].GetComponent<PlayerInvemtorySlot>().acceptableSlotSubCategory && itemSubCategory != "")
            {
                if(playerSlots[i].GetComponent<PlayerInvemtorySlot>().itemData == null)
                {
                    Debug.Log("Item equiped!");
                    playerSlots[i].GetComponent<PlayerInvemtorySlot>().SetEquiptItemIcon(itemCategory, itemSubCategory, itemData);
                    inventory2.RemoveItem(itemData);
                    inventory2.SortItemList();
                    inventory2.CreateInventorySlots(itemCategory);
                    AddPlayerStats(itemCategory, itemSubCategory);
                }
                else
                {
                    inventory2.AddItem(playerSlots[i].GetComponent<PlayerInvemtorySlot>().itemData);
                    inventory2.SortItemList();
                    SubtractPlayerStats(itemCategory, itemSubCategory);
                    Debug.Log("Item equiped!");
                    playerSlots[i].GetComponent<PlayerInvemtorySlot>().SetEquiptItemIcon(itemCategory, itemSubCategory, itemData);
                    inventory2.RemoveItem(itemData);
                    inventory2.SortItemList();
                    inventory2.CreateInventorySlots(itemCategory);
                    AddPlayerStats(itemCategory, itemSubCategory);
                }
               
            }

            if (itemCategory == playerSlots[i].GetComponent<PlayerInvemtorySlot>().acceptableSlotCategory && itemSubCategory == "")
            {
                if (playerSlots[i].GetComponent<PlayerInvemtorySlot>().itemData == null)
                {
                    Debug.Log("Item equiped!");
                    playerSlots[i].GetComponent<PlayerInvemtorySlot>().SetEquiptItemIcon(itemCategory, itemSubCategory, itemData);
                    inventory2.RemoveItem(itemData);
                    inventory2.SortItemList();
                    inventory2.CreateInventorySlots(itemCategory);
                    AddPlayerStats(itemCategory, itemSubCategory);
                }
                else
                {
                    inventory2.AddItem(playerSlots[i].GetComponent<PlayerInvemtorySlot>().itemData);
                    inventory2.SortItemList();
                    SubtractPlayerStats(itemCategory, itemSubCategory);
                    Debug.Log("Item equiped!");
                    playerSlots[i].GetComponent<PlayerInvemtorySlot>().SetEquiptItemIcon(itemCategory, itemSubCategory, itemData);
                    inventory2.RemoveItem(itemData);
                    inventory2.SortItemList();
                    inventory2.CreateInventorySlots(itemCategory);
                    AddPlayerStats(itemCategory, itemSubCategory);
                }

            }
        }
    }

    public void SellItem()
    {
        Debug.Log("Item sold!");
        inventory2.RemoveItem(itemData);
        inventory2.SortItemList();
        kredytsManager.GetComponent<KredytsManager>().AddKredyts(price);
        inventory2.CreateInventorySlots(itemCategory);
    }

    public void GetItemData()
    {
        if (itemData != null)
        {
            InventoryItemData currentItemData = itemData;
            var descryption = currentItemData.discreption;
            itemCategory = currentItemData.itemCategory;
            itemSubCategory = currentItemData.itemSubCategory;
            price = currentItemData.itemCost;
            itemDescryption.text = descryption;
            itemPrice.text = price.ToString();

            itemIcon.GetComponent<Image>().sprite = currentItemData.itemIcon;
        }
    }

    private void AddPlayerStats(string itemCategory, string itemSubCategory)
    {
        InventoryItemData currentItemData = itemData;
        var playerNormalHP = PlayerPrefs.GetInt("PlayerNormalHP");


        var hpUpgrade = currentItemData.healthAmplifier;
        var armorUpgrade = currentItemData.armorAmplifier;
        var attackUpgrade = currentItemData.attackAmplifier;

        if(itemCategory == "Helmets")
        {
            upgradeManager.GetComponent<StatsUpgradeManager>().AddHelmetItemAmplifiers(armorUpgrade);
        }

        if (itemCategory == "Shoulders")
        {
            upgradeManager.GetComponent<StatsUpgradeManager>().AddShouldersItemAmplifiers(hpUpgrade, armorUpgrade, attackUpgrade);
        }

        if (itemCategory == "Armor")
        {
            upgradeManager.GetComponent<StatsUpgradeManager>().AddBodyArmorItemAmplifiers(hpUpgrade, armorUpgrade);
        }

        if (itemCategory == "Pants")
        {
            upgradeManager.GetComponent<StatsUpgradeManager>().AddPantsItemAmplifiers(hpUpgrade, armorUpgrade);
        }

        if (itemCategory == "Gloves")
        {
            upgradeManager.GetComponent<StatsUpgradeManager>().AddGlovesItemAmplifiers(armorUpgrade, attackUpgrade);
        }

        if (itemCategory == "Boots")
        {
            upgradeManager.GetComponent<StatsUpgradeManager>().AddBootsItemAmplifiers(armorUpgrade);
        }

        if (itemCategory == "Bracers")
        {
            upgradeManager.GetComponent<StatsUpgradeManager>().AddBracersItemAmplifiers(attackUpgrade);
        }

        if (itemCategory == "SpaceshipElements" && itemSubCategory == "Engine")
        {
            upgradeManager.GetComponent<StatsUpgradeManager>().AddEngineItemAmplifiers(hpUpgrade);
        }

        if (itemCategory == "SpaceshipElements" && itemSubCategory == "Liser1")
        {
            upgradeManager.GetComponent<StatsUpgradeManager>().AddLiser1ItemAmplifiers(attackUpgrade);
        }

        if (itemCategory == "SpaceshipElements" && itemSubCategory == "Liser2")
        {
            upgradeManager.GetComponent<StatsUpgradeManager>().AddLiser2ItemAmplifiers(attackUpgrade);
        }
    }

    private void SubtractPlayerStats(string itemCategory, string itemSubCategory)
    {
        InventoryItemData currentItemData = itemData;
        var playerNormalHP = PlayerPrefs.GetInt("PlayerNormalHP");


        var hpUpgrade = currentItemData.healthAmplifier;
        var armorUpgrade = currentItemData.armorAmplifier;
        var attackUpgrade = currentItemData.attackAmplifier;

        if (itemCategory == "Helmets")
        {
            upgradeManager.GetComponent<StatsUpgradeManager>().SubtractHelmetItemAmplifiers(armorUpgrade);
        }

        if (itemCategory == "Shoulders")
        {
            upgradeManager.GetComponent<StatsUpgradeManager>().SubtractShouldersItemAmplifiers(hpUpgrade, armorUpgrade, attackUpgrade);
        }

        if (itemCategory == "Armor")
        {
            upgradeManager.GetComponent<StatsUpgradeManager>().SubtractBodyArmorItemAmplifiers(hpUpgrade, armorUpgrade);
        }

        if (itemCategory == "Pants")
        {
            upgradeManager.GetComponent<StatsUpgradeManager>().SubtractPantsItemAmplifiers(hpUpgrade, armorUpgrade);
        }

        if (itemCategory == "Gloves")
        {
            upgradeManager.GetComponent<StatsUpgradeManager>().SubtractGlovesItemAmplifiers(armorUpgrade, attackUpgrade);
        }

        if (itemCategory == "Boots")
        {
            upgradeManager.GetComponent<StatsUpgradeManager>().SubtractBootsItemAmplifiers(armorUpgrade);
        }

        if (itemCategory == "Bracers")
        {
            upgradeManager.GetComponent<StatsUpgradeManager>().SubtractBracersItemAmplifiers(attackUpgrade);
        }

        if (itemCategory == "SpaceshipElements" && itemSubCategory == "Engine")
        {
            upgradeManager.GetComponent<StatsUpgradeManager>().SubtractEngineItemAmplifiers(hpUpgrade);
        }

        if (itemCategory == "SpaceshipElements" && itemSubCategory == "Liser1")
        {
            upgradeManager.GetComponent<StatsUpgradeManager>().SubtractLiser1ItemAmplifiers(attackUpgrade);
        }

        if (itemCategory == "SpaceshipElements" && itemSubCategory == "Liser2")
        {
            upgradeManager.GetComponent<StatsUpgradeManager>().SubtractLiser2ItemAmplifiers(attackUpgrade);
        }
    }
    private void Update()
    {
        yourKredyts = PlayerPrefs.GetFloat("yourKredytNumber");
        GetItemData();
    }
}
