using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Inventory4ItemSlotUI : MonoBehaviour
{
    public GameObject itemSprite;
    public InventoryItemData itemData;

    [SerializeField] private TextMeshProUGUI itemCount = null;
    [HideInInspector]
    public GameObject itemInfoPanel = null;
    [HideInInspector]
    public GameObject addItemPanel = null;
    [HideInInspector]
    public GameObject buyOrSellPanel = null;
    [HideInInspector]
    public GameObject mouseItem = null;
    [HideInInspector]
    public GameObject mouseParent = null;
    public GameObject equipItemPanel;
    public GameObject noItemMach;
    public EquipItemManager equipRemoveItem = null;
    [SerializeField] private Button itemSlotButton;
   

    public Inventory4Manager inventory4Manager { get; private set; }
    public SelectedBuySellItems selectedBuyItems { get; private set; }
   
    private void Awake()
    {
        //itemSlotButton?.onClick.AddListener(OnUISlotClick);
        
    }
    private void Update()
    {


        if (addItemPanel != null && buyOrSellPanel != null)
        {
            


            itemSlotButton.onClick.AddListener(ItemAddPanel);
            itemSlotButton.onClick.AddListener(SetAddPanelItemData);

        }


      
        if (mouseItem != null && equipRemoveItem != null)
        {
            itemSlotButton.onClick.AddListener(SetEguipRemovePanelItemData);
            itemSlotButton.onClick.AddListener(MouseItemPanel);


        }
    }




    public void OnItemSlotButtonEnter()
    {
        itemInfoPanel.SetActive(true);
        itemInfoPanel.GetComponent<ItemInfoShopPanel>().GetItemData();
    }

    public void ONItemSlotButtonExit()
    {
        itemInfoPanel.SetActive(false);
    }


    public void ItemAddPanel()
    {
        addItemPanel.SetActive(true);
    }
    void SetAddPanelItemData()
    {
        addItemPanel.GetComponent<AddRemoveItemPanel>().itemData = itemData;

    }
    public void MouseItemPanel()
    {
        equipItemPanel.SetActive(false);
        noItemMach.SetActive(false);
        mouseParent.SetActive(true);
        mouseItem.SetActive(true);
        mouseItem.GetComponent<MouseItemData4>().itemData = itemData;
        mouseItem.GetComponent<MouseItemData4>().GetItemDataCategory();
    }
    public void SetEguipRemovePanelItemData()
    {
        equipRemoveItem.itemData = itemData;

    }
}
