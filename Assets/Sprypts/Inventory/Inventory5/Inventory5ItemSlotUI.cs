using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Inventory5ItemSlotUI : MonoBehaviour
{
    public GameObject itemIcon;
    public InventoryItemData itemData;
    public GameObject equipedPanel;
    public bool isEquip = false;

    
    public GameObject itemEquipPanel = null;
    [SerializeField] private Button itemSlotButton;

    private void Update()
    {
        if (itemData != null)
        {
            itemIcon.SetActive(true);
            itemIcon.GetComponent<Image>().sprite = itemData.itemIcon;


            itemSlotButton.onClick.AddListener(ItemEquipPanel);
            itemSlotButton.onClick.AddListener(SetEquipPanelItemData);
            if(isEquip == true)
            {
                equipedPanel.SetActive(true);
            }
            else
            {
                equipedPanel.SetActive(false);
            }

        }
    }

    public void ItemEquipPanel()
    {
        itemEquipPanel.SetActive(true);
    }

    void SetEquipPanelItemData()
    {
        itemEquipPanel.GetComponent<ItemEquipPanel>().itemData = itemData;
        itemEquipPanel.GetComponent<ItemEquipPanel>().currentItemSlot = this.GetComponent<Inventory5ItemSlotUI>();

    }
}
