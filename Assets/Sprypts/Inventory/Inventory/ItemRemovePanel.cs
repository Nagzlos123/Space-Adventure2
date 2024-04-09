using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemRemovePanel : MonoBehaviour
{
    public InventoryItemData itemData;
    public GameObject[] playerSlots;
    [SerializeField] private TextMeshProUGUI itemDescryption;
    [SerializeField] private TextMeshProUGUI itemPrice;
    [SerializeField] private GameObject itemIcon;
    [SerializeField] private StatsUpgradeManager upgradeManager;
    public Inventory2Manager inventory2;
    
    public string itemCategory;
    public string itemSubCategory;

    public void RemoveItem()
    {
        for (int i = 0; i < playerSlots.Length; i++)
        {

            if (itemCategory == playerSlots[i].GetComponent<PlayerInvemtorySlot>().acceptableSlotCategory && itemSubCategory == playerSlots[i].GetComponent<PlayerInvemtorySlot>().acceptableSlotSubCategory
                && itemSubCategory != "")
            {
                inventory2.AddItem(itemData);
                inventory2.SortItemList();
                inventory2.CreateInventorySlots(itemCategory);
                playerSlots[i].GetComponent<PlayerInvemtorySlot>().ResetPlayerSlot(itemCategory);
                SubtractPlayerStats(itemCategory, itemSubCategory);
                Debug.Log("Item removed!");
            }
            if (itemCategory == playerSlots[i].GetComponent<PlayerInvemtorySlot>().acceptableSlotCategory && itemSubCategory == "")
            {
                inventory2.AddItem(itemData);
                inventory2.SortItemList();
                inventory2.CreateInventorySlots(itemCategory);
                playerSlots[i].GetComponent<PlayerInvemtorySlot>().ResetPlayerSlot(itemCategory);
                SubtractPlayerStats(itemCategory, itemSubCategory);
                Debug.Log("Item removed!");
            }
            
        }
    }
    public void GetItemData()
    {
        if (itemData != null)
        {
            InventoryItemData currentItemData = itemData;
            var descryption = currentItemData.discreption;
            var price = currentItemData.itemCost;
            itemCategory = currentItemData.itemCategory;
            itemSubCategory = currentItemData.itemSubCategory;
            itemDescryption.text = descryption;
            itemPrice.text = price.ToString();

            itemIcon.GetComponent<Image>().sprite = currentItemData.itemIcon;
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
        GetItemData();
    }
}
