using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Inventory3ItemSlotUI : MonoBehaviour
{
    public GameObject itemSprite;
    public InventoryItemData itemData;
    
    [SerializeField] private TextMeshProUGUI itemCount = null;
    [SerializeField] private GameObject itemSellPanel;
    [SerializeField] private Button itemSlotButton;

    public Inventory3Maneger inventory3Manager { get; private set; }

    //[SerializeField] private GameObject inventorySellManeger;
    private void Awake()
    {
        itemSlotButton?.onClick.AddListener(OnUISlotClick);
        itemSlotButton.interactable = false;
    }

    public void ClearSlot()
    {
        itemData = null;
        itemSprite.GetComponent<Image>().sprite = null;
        itemSprite.GetComponent<Image>().color = Color.clear;
        itemSprite.SetActive(false);
        itemSlotButton.interactable = false;
    }

    public void SetToDefault()
    {
        itemSprite.GetComponent<Image>().color = Color.white;
        itemSlotButton.interactable = true;
    }
    private void Update()
    {
        if (itemData != null)
        {
            itemSprite.SetActive(true);
            itemSprite.GetComponent<Image>().sprite = itemData.itemIcon;
            itemSlotButton.interactable = true;

            itemSlotButton.onClick.AddListener(SetActiveItemSellPanel);
            itemSlotButton.onClick.AddListener(SetSellPanelItemData);

        }
        else
        {
            

        }

        if (itemData == null)
        {
            //Debug.Log("itemData is null!");
        }
    }

    void SetActiveItemSellPanel()
    {
        itemSellPanel.SetActive(true);
    }


    void SetSellPanelItemData()
    {
        itemSellPanel.GetComponent<Inventory3SellManager>().itemData = itemData;

    }

    public void OnUISlotClick()
    {
        inventory3Manager?.SlotClicked(this);
    }

}
