using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemEquipSellPanel : MonoBehaviour
{
    [Header("Old")]
    public GameObject[] playerSlots;
    [SerializeField] private TextMeshProUGUI yourKredytsAmount;
    [SerializeField] private GameObject kredytsManager;
    [SerializeField] private StatsUpgradeManager upgradeManager;

    public Inventory2Manager inventory2;
    private float yourKredyts;
    [Header("Data Getter")]
    public ItemEquipSellPanelGetter itemDataGetter;
    private void Start()
    {
        itemDataGetter.GetItemData();
    }
    public void EquipItem()
    {
       
        for (int i = 0; i < playerSlots.Length; i++)
        {
            
            if(itemDataGetter.itemCategory == playerSlots[i].GetComponent<PlayerInvemtorySlot>().acceptableSlotCategory 
                && itemDataGetter.itemSubCategory == playerSlots[i].GetComponent<PlayerInvemtorySlot>().acceptableSlotSubCategory 
                && itemDataGetter.itemSubCategory != "")
            {
                if(playerSlots[i].GetComponent<PlayerInvemtorySlot>().itemData == null)
                {
                    Debug.Log("Item equiped!");
                    playerSlots[i].GetComponent<PlayerInvemtorySlot>().SetEquiptItemIcon(itemDataGetter.itemCategory,
                        itemDataGetter.itemSubCategory, itemDataGetter.itemData);
                    inventory2.RemoveItem(itemDataGetter.itemData);
                    inventory2.SortItemList();
                    inventory2.CreateCorrectInventorySlots(inventory2.categoryItem);
                    upgradeManager.AddPlayerStats(itemDataGetter.itemCategory, itemDataGetter.itemSubCategory, itemDataGetter.itemData);
                }
                else
                {
                    inventory2.AddItem(playerSlots[i].GetComponent<PlayerInvemtorySlot>().itemData);
                    inventory2.SortItemList();
                    upgradeManager.SubtractPlayerStats(itemDataGetter.itemCategory, itemDataGetter.itemSubCategory, itemDataGetter.itemData);
                    Debug.Log("Item equiped!");
                    playerSlots[i].GetComponent<PlayerInvemtorySlot>().SetEquiptItemIcon(itemDataGetter.itemCategory,
                        itemDataGetter.itemSubCategory, itemDataGetter.itemData);
                    inventory2.RemoveItem(itemDataGetter.itemData);
                    inventory2.SortItemList();
                    inventory2.CreateCorrectInventorySlots(inventory2.categoryItem);
                    upgradeManager.AddPlayerStats(itemDataGetter.itemCategory, itemDataGetter.itemSubCategory, itemDataGetter.itemData);
                }
               
            }

            if (itemDataGetter.itemCategory == playerSlots[i].GetComponent<PlayerInvemtorySlot>().acceptableSlotCategory 
                && itemDataGetter.itemSubCategory == "")
            {
                if (playerSlots[i].GetComponent<PlayerInvemtorySlot>().itemData == null)
                {
                    Debug.Log("Item equiped!");
                    playerSlots[i].GetComponent<PlayerInvemtorySlot>().SetEquiptItemIcon(itemDataGetter.itemCategory,
                        itemDataGetter.itemSubCategory, itemDataGetter.itemData);
                    inventory2.RemoveItem(itemDataGetter.itemData);
                    inventory2.SortItemList();
                    inventory2.CreateCorrectInventorySlots(inventory2.categoryItem);
                    upgradeManager.AddPlayerStats(itemDataGetter.itemCategory, itemDataGetter.itemSubCategory, itemDataGetter.itemData);
                }
                else
                {
                    inventory2.AddItem(playerSlots[i].GetComponent<PlayerInvemtorySlot>().itemData);
                    inventory2.SortItemList();
                    upgradeManager.SubtractPlayerStats(itemDataGetter.itemCategory, itemDataGetter.itemSubCategory, itemDataGetter.itemData);
                    Debug.Log("Item equiped!");
                    playerSlots[i].GetComponent<PlayerInvemtorySlot>().SetEquiptItemIcon(itemDataGetter.itemCategory,
                        itemDataGetter.itemSubCategory, itemDataGetter.itemData);
                    inventory2.RemoveItem(itemDataGetter.itemData);
                    inventory2.SortItemList();
                    inventory2.CreateCorrectInventorySlots(inventory2.categoryItem);
                    upgradeManager.AddPlayerStats(itemDataGetter.itemCategory, itemDataGetter.itemSubCategory, itemDataGetter.itemData);
                }

            }
        }
    }

    public void SellItem()
    {
        Debug.Log("Item sold!");
        inventory2.RemoveItem(itemDataGetter.itemData);
        inventory2.SortItemList();
        kredytsManager.GetComponent<KredytsManager>().AddKredyts(itemDataGetter.price);
        inventory2.CreateCorrectInventorySlots(inventory2.categoryItem);
    }

    private void Update()
    {
        yourKredyts = PlayerPrefs.GetFloat("yourKredytNumber");
        itemDataGetter.GetItemData();
    }
}
