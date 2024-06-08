using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemRemovePanel : MonoBehaviour
{
    [Header("Old")]
    
    public GameObject[] playerSlots;
    
    [SerializeField] private StatsUpgradeManager upgradeManager;
    public Inventory2Manager inventory2;
    
    [Header("Data Getter")]
    public ItemRemovePanelGetter itemDataGetter;
    private void Start()
    {
        itemDataGetter.GetItemData();
    }
    public void RemoveItem()
    {
        for (int i = 0; i < playerSlots.Length; i++)
        {

            if (itemDataGetter.itemCategory == playerSlots[i].GetComponent<PlayerInvemtorySlot>().acceptableSlotCategory 
                && itemDataGetter.itemSubCategory == playerSlots[i].GetComponent<PlayerInvemtorySlot>().acceptableSlotSubCategory
                && itemDataGetter.itemSubCategory != "")
            {
                inventory2.AddItem(itemDataGetter.itemData);
                inventory2.SortItemList();
                inventory2.CreateInventorySlots(itemDataGetter.itemCategory);
                playerSlots[i].GetComponent<PlayerInvemtorySlot>().ResetPlayerSlot(itemDataGetter.itemCategory, itemDataGetter.itemSubCategory);
                SubtractPlayerStats(itemDataGetter.itemCategory, itemDataGetter.itemSubCategory);
                Debug.Log("Item removed!");
            }
            if (itemDataGetter.itemCategory == playerSlots[i].GetComponent<PlayerInvemtorySlot>().acceptableSlotCategory 
                && itemDataGetter.itemSubCategory == "")
            {
                inventory2.AddItem(itemDataGetter.itemData);
                inventory2.SortItemList();
                inventory2.CreateInventorySlots(itemDataGetter.itemCategory);
                playerSlots[i].GetComponent<PlayerInvemtorySlot>().ResetPlayerSlot(itemDataGetter.itemCategory);
                SubtractPlayerStats(itemDataGetter.itemCategory, itemDataGetter.itemSubCategory);
                Debug.Log("Item removed!");
            }
            
        }
    }

    private void SubtractPlayerStats(string itemCategory, string itemSubCategory)
    {
        InventoryItemData currentItemData = itemDataGetter.itemData;
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
        itemDataGetter.GetItemData();
    }
}
