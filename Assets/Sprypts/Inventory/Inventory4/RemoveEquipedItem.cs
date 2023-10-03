using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RemoveEquipedItem : MonoBehaviour
{
    public InventoryItemData itemData;

    [SerializeField] private GameObject mouseItem;
    [SerializeField] private GameObject mouseParent;
    [SerializeField] private StatsUpgradeManager upgradeManager;
    [SerializeField] private Inventory4Manager inventory4;
    public GameObject[] playerSlots;

    [SerializeField] private TextMeshProUGUI itemDescryption;
    [SerializeField] private TextMeshProUGUI itemPrice;
    [SerializeField] private TextMeshProUGUI itemNameText;
    [SerializeField] private GameObject itemIcon;



    public string itemCategory;
    public string itemSubCategory;

    public void RemoveItem()
    {

        for (int i = 0; i < playerSlots.Length; i++)
        {
            if (itemCategory == playerSlots[i].GetComponent<PlayerInvemtorySlot4>().acceptableSlotCategory
                && itemSubCategory == playerSlots[i].GetComponent<PlayerInvemtorySlot4>().acceptableSlotSubCategory && itemSubCategory != "")
            {
                inventory4.AddItem(itemData);
                inventory4.SortItemList();
                inventory4.CreateInventorySlots(itemCategory);
                playerSlots[i].GetComponent<PlayerInvemtorySlot4>().ResetPlayerSlot(itemCategory);
                SubtractPlayerStats(itemCategory, itemSubCategory);
                Debug.Log("Item removed!");
            }
            if (itemCategory == playerSlots[i].GetComponent<PlayerInvemtorySlot4>().acceptableSlotCategory && itemSubCategory == "")
            {
                inventory4.AddItem(itemData);
                inventory4.SortItemList();
                inventory4.CreateInventorySlots(itemCategory);
                playerSlots[i].GetComponent<PlayerInvemtorySlot4>().ResetPlayerSlot(itemCategory);
                SubtractPlayerStats(itemCategory, itemSubCategory);
                Debug.Log("Item removed!");
            }
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
    public void GetItemData()
    {
        if (itemData != null)
        {
            InventoryItemData currentItemData = itemData;
            var descryption = currentItemData.discreption;
            var price = currentItemData.itemCost;
            var itemName = currentItemData.displayName;
            itemCategory = currentItemData.itemCategory;
            itemSubCategory = currentItemData.itemSubCategory;
            itemDescryption.text = descryption;
            itemPrice.text = price.ToString();
            itemNameText.text = itemName;
            itemIcon.GetComponent<Image>().sprite = currentItemData.itemIcon;
        }
    }

    private void Update()
    {
        GetItemData();
    }
}
