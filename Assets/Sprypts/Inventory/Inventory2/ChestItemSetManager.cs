using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChestItemSetManager : MonoBehaviour
{
    //public List<InventoryItemData> ChestItemSet = new List<InventoryItemData>();
    public InventoryItemManager inventoryItemManager;
    [SerializeField] private InventoryItemData[] chestItemSet;
    [SerializeField] private GameObject nextButton;
    [SerializeField] private GameObject backButton;
    [SerializeField] private TextMeshProUGUI currentItemName;
    [SerializeField] private GameObject itemIcon;
 
    public int itemDataID = 0;

    private void Start()
    {
        GetChestItemSet();
        GetItemData(itemDataID);
        nextButton.SetActive(true);
        backButton.SetActive(false);
    }
    public void AddItem(InventoryItemData itemData)
    {
        //ChestItemSet.Add(itemData);
    }

    public void RemoveItem(InventoryItemData itemData)
    {
        //ChestItemSet.Remove(itemData);
    }


    private void GetChestItemSet()
    {
        chestItemSet = new InventoryItemData[inventoryItemManager.chestItemSetNumber];
        
        for (int i = 0; i < inventoryItemManager.chestItemSet.Length; i++)
        {
            chestItemSet[i] = inventoryItemManager.chestItemSet[i];
        }
       
    }
    public void GetItemData(int itemDataID)
    {
        InventoryItemData currentItemData = chestItemSet[itemDataID];
        var itemName = currentItemData.displayName;
        itemIcon.GetComponent<Image>().sprite = currentItemData.itemIcon;
        currentItemName.text = itemName.ToString();

    }
    public void OnNextButtonCliked()
    {

        
            GetItemData(itemDataID + 1);
            itemDataID++;
        


        
    }

    private void Update()
    {
        if (chestItemSet == null)
        {
            GetChestItemSet();
            GetItemData(itemDataID);
        }

        if (itemDataID + 1 < chestItemSet.Length)
        {
            nextButton.SetActive(true);
            backButton.SetActive(false);
        }

        if (itemDataID + 1 == chestItemSet.Length)
        {

            nextButton.SetActive(false);
            backButton.SetActive(true);
        }
    }
    public void OnBackButtonCliked()
    {
        itemDataID = 0;
        itemIcon.GetComponent<Image>().sprite = null;
        currentItemName.text = "itemName";
        chestItemSet = null;
        inventoryItemManager.chestItemSet = null;
    }

}
