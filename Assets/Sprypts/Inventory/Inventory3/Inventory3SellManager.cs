using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Inventory3SellManager : MonoBehaviour
{

    //public InventoryItemData[] itemData;
    public InventoryItemData itemData; 
    //public List<InventoryItemData> itemData = new List<InventoryItemData>();
    [SerializeField] private TextMeshProUGUI itemDescryption;
    [SerializeField] private TextMeshProUGUI itemPrice;
    [SerializeField] private TextMeshProUGUI yourKredytsAmount;

    [SerializeField] private GameObject itemIcon;


    [SerializeField] private GameObject sellButton;
    
    [SerializeField] private GameObject playerItemEquiptIcon;

    [SerializeField] private GameObject kredytsManager;
    public Inventory3ItemSlotUI currentClickedUISlot;
    public GameObject inventory3;
    private bool sellButtonClicked = false;
    private string descryption;
    private float price;
    private float yourKredyts;
   

    private void Start()
    {
        sellButtonClicked = false;
        GetItemData();
    }
    public void GetItemData()
    {
        if(itemData!= null)
        {
            InventoryItemData currentItemData = itemData;
            descryption = currentItemData.discreption;
            price = currentItemData.itemCost;
            itemDescryption.text = descryption;
            itemPrice.text = price.ToString();
            itemIcon.GetComponent<Image>().sprite = currentItemData.itemIcon;
        }
       

    }

    public void SellItem()
    {
        sellButtonClicked = true;
        InventoryItemData currentItemData = itemData;
        Debug.Log("Item sold!" + currentItemData.name);
        kredytsManager.GetComponent<KredytsManager>().AddKredyts(price);
        PlayerPrefs.SetInt("ItemSold", 1);
        //sellButton.GetComponent<Button>().onClick.AddListener(RemoweSoldItem);
        //currentClickedUISlot.ClearSlot();
        RemoweSoldItem();
        ResetSellPanelItemData();
        //this.gameObject.SetActive(false);
    }

    private void RemoweSoldItem()
    {
        inventory3.GetComponent<InventoryItemManager>().RemoweItem(itemData);
        
    }
    public void ResetSellPanelItemData()
    {
        itemData = null;
    }



    private void Update()
    {
        GetItemData();
        //itemData = inventory3.GetComponent<Inventory3ItemSlotUI>().itemData;
    }
        //public InventoryItemData[] newItemData = { inventory3.GetComponent<Inventory3ItemSlotUI>().itemData };

    //itemData[0] = inventory3.GetComponent<InventoryItemManager>().GetItemDataFromUISlot();
    //GetItemData(0);
}
    





