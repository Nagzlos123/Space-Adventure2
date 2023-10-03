using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemEquipPanel : MonoBehaviour
{
    public InventoryItemData itemData;
    public Inventory5ItemSlotUI currentItemSlot;
    public GameObject[] playerSlots;
    public Inventory5ItemSlotUI[] inventorySlots;
    [SerializeField] private TextMeshProUGUI itemNameText;
    [SerializeField] private TextMeshProUGUI itemDescryption;
    
    [SerializeField] private GameObject itemIcon;
    [SerializeField] private GameObject kredytsManager;
    [SerializeField] private GameObject equipButton;
    [SerializeField] private GameObject removeButton;
    [SerializeField] private GameObject itemStatusPanel;
    [SerializeField] private StatsUpgradeManager upgradeManager;
    [SerializeField] private GameObject refuseToEquipPanel;

    public bool isEquiped = false;
    public string itemCategory;
    public void GetItemData()
    {
        if (itemData != null)
        {
            InventoryItemData currentItemData = itemData;
            var itemName = currentItemData.displayName;
            var descryption = currentItemData.discreption;
            itemCategory = currentItemData.itemCategory;
            itemNameText.text = itemName;
            itemDescryption.text = descryption;
            

            itemIcon.GetComponent<Image>().sprite = currentItemData.itemIcon;
        }
    }
    private void AddPlayerStats(string itemCategory)
    {
        InventoryItemData currentItemData = itemData;
        var playerNormalHP = PlayerPrefs.GetInt("PlayerNormalHP");


        var hpUpgrade = currentItemData.healthAmplifier;
        var armorUpgrade = currentItemData.armorAmplifier;
        var attackUpgrade = currentItemData.attackAmplifier;

        if (itemCategory == "Helmets")
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
    }
    private void SubtractPlayerStats(string itemCategory)
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
    }
    public void EquipItem()
    {
        for (int i = 0; i < playerSlots.Length; i++)
        {
            if (itemCategory == playerSlots[i].GetComponent<PlayerInvemtorySlot5>().acceptableSlotCategory)
            {
                if (playerSlots[i].GetComponent<PlayerInvemtorySlot5>().itemData == null)
                {
                    RemovePreviousItem();
                    Debug.Log("Item equiped!");
                    playerSlots[i].GetComponent<PlayerInvemtorySlot5>().SetEquiptItemIcon(itemCategory, itemData);
                    //isEquiped = true;
                    currentItemSlot.isEquip = true;
                    //equipButton.SetActive(false);
                    //removeButton.SetActive(true);
                    //itemStatusPanel.SetActive(true);
                    AddPlayerStats(itemCategory);

                }
                else
                {
                    refuseToEquipPanel.SetActive(true);
                    //RemovePreviousItem();
                    //SubtractPlayerStats(itemCategory);
                    //Debug.Log("Item equiped!");
                    //playerSlots[i].GetComponent<PlayerInvemtorySlot5>().SetEquiptItemIcon(itemCategory, itemData);
                    //currentItemSlot.isEquip = true;
                    //AddPlayerStats(itemCategory);
                }
            }
                
        }
        
        
    }

    public void RemoveItem()
    {
        Debug.Log("Item removed!");
        currentItemSlot.isEquip = false;
        for (int i = 0; i < playerSlots.Length; i++)
        {
            if (itemCategory == playerSlots[i].GetComponent<PlayerInvemtorySlot5>().acceptableSlotCategory)
            {
                playerSlots[i].GetComponent<PlayerInvemtorySlot5>().ResetPlayerSlot(itemCategory);
            }
        }
        SubtractPlayerStats(itemCategory);
    }

    private void RemovePreviousItem()
    {
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            
                if (inventorySlots[i].itemData.itemCategory == currentItemSlot.itemData.itemCategory)
                {
                    if(inventorySlots[i].isEquip == true)
                    {
                        Debug.Log("Inventory Slot is equiped" + inventorySlots[i].itemData.displayName);
                    }
                }
        
        }
    }
     

    private void Update()
    {

        if(currentItemSlot.isEquip == false)
        {
            equipButton.SetActive(true);
            removeButton.SetActive(false);
            itemStatusPanel.SetActive(false);
        }
        else
        {
            equipButton.SetActive(false);
            removeButton.SetActive(true);
            itemStatusPanel.SetActive(true);
        }

        //inventorySlots
        /*
       if(isEquiped == false)
        {
            equipButton.SetActive(true);
            removeButton.SetActive(false);
            itemStatusPanel.SetActive(false);
        }
        else
        {
            equipButton.SetActive(false);
            removeButton.SetActive(true);
            itemStatusPanel.SetActive(true);
        }
        */
        GetItemData();
    }
}
