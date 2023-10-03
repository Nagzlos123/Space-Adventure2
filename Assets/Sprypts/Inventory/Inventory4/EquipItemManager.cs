using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class EquipItemManager : MonoBehaviour
{
    public InventoryItemData itemData;
    public InventoryItemData itemDataEquiped;
   [SerializeField] private GameObject mouseItem;
    [SerializeField] private GameObject mouseParent;
    [SerializeField] private StatsUpgradeManager upgradeManager;
    [SerializeField] private Inventory4Manager inventory4;
    public GameObject[] playerSlots;



    public string itemCategory;
    public string itemSubCategory;


    public void EquipItem()
    {
        for (int i = 0; i < playerSlots.Length; i++)
        {
            if(itemCategory == playerSlots[i].GetComponent<PlayerInvemtorySlot4>().acceptableSlotCategory 
                && itemSubCategory == playerSlots[i].GetComponent<PlayerInvemtorySlot4>().acceptableSlotSubCategory && itemSubCategory != "")
            {
                if (playerSlots[i].GetComponent<PlayerInvemtorySlot4>().itemData == null)
                {
                    Debug.Log("Item equiped!");
                    playerSlots[i].GetComponent<PlayerInvemtorySlot4>().SetEquiptItemIcon(itemCategory, itemSubCategory, itemData);
                    inventory4.RemoveItem(itemData);
                    inventory4.SortItemList();
                    inventory4.CreateInventorySlots(itemCategory);
                    AddPlayerStats(itemCategory, itemSubCategory);
                    mouseItem.GetComponent<MouseItemData4>().itemData = null;
                    mouseItem.SetActive(false);
                }
                else
                {
                    inventory4.AddItem(playerSlots[i].GetComponent<PlayerInvemtorySlot4>().itemData);
                    inventory4.SortItemList();
                    SubtractPlayerStats(itemCategory, itemSubCategory);
                    Debug.Log("Item equiped!");
                    playerSlots[i].GetComponent<PlayerInvemtorySlot4>().SetEquiptItemIcon(itemCategory, itemSubCategory, itemData);
                    inventory4.RemoveItem(itemData);
                    inventory4.SortItemList();
                    inventory4.CreateInventorySlots(itemCategory);
                    AddPlayerStats(itemCategory, itemSubCategory);
                    mouseItem.GetComponent<MouseItemData4>().itemData = null;
                    mouseItem.SetActive(false);
                }
            }

          

            if (itemCategory == playerSlots[i].GetComponent<PlayerInvemtorySlot4>().acceptableSlotCategory && itemSubCategory == "")
            {
                if (playerSlots[i].GetComponent<PlayerInvemtorySlot4>().itemData == null)
                {
                    Debug.Log("Item equiped!");
                    playerSlots[i].GetComponent<PlayerInvemtorySlot4>().SetEquiptItemIcon(itemCategory, itemSubCategory, itemData);
                    inventory4.RemoveItem(itemData);
                    inventory4.SortItemList();
                    inventory4.CreateInventorySlots(itemCategory);
                    AddPlayerStats(itemCategory, itemSubCategory);
                    mouseItem.GetComponent<MouseItemData4>().itemData = null;
                    mouseItem.SetActive(false);
                    mouseParent.SetActive(false);
                }
                else
                {
                    inventory4.AddItem(playerSlots[i].GetComponent<PlayerInvemtorySlot4>().itemData);
                    inventory4.SortItemList();
                    SubtractPlayerStats(itemCategory, itemSubCategory);
                    Debug.Log("Item equiped!");
                    playerSlots[i].GetComponent<PlayerInvemtorySlot4>().SetEquiptItemIcon(itemCategory, itemSubCategory, itemData);
                    inventory4.RemoveItem(itemData);
                    inventory4.SortItemList();
                    inventory4.CreateInventorySlots(itemCategory);
                    AddPlayerStats(itemCategory, itemSubCategory);
                    mouseItem.GetComponent<MouseItemData4>().itemData = null;
                    mouseItem.SetActive(false);
                    mouseParent.SetActive(false);
                }
            }

        
        }
            
            
    }



    public void GetItemDataCategory()
    {
        if (itemData != null)
        {
            InventoryItemData currentItemData = itemData;
            itemCategory = currentItemData.itemCategory;
            itemSubCategory = currentItemData.itemSubCategory;
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

    private void AddPlayerStats(string itemCategory, string itemSubCategory)
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

    private void MouseOf()
    {
        if (Input.GetMouseButtonDown(1))
        {
            mouseItem.GetComponent<MouseItemData4>().itemData = null;
            mouseItem.SetActive(false);
            mouseParent.SetActive(false);
            if(mouseParent.activeSelf == false)
            {
                //mouseParent.transform.GetChild(1).gameObject.SetActive(false);
                //mouseParent.transform.GetChild(2).gameObject.SetActive(false);
            }
        }
    }

    private void Update()
    {
        MouseOf();
        GetItemDataCategory();
     

   
    }
}
