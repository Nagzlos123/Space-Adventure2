using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Inventory2ItemSlotUI : MonoBehaviour
{
    public GameObject itemSprite;
    public InventoryItemData itemData;

    [SerializeField] private TextMeshProUGUI itemCount = null;
    [HideInInspector]
    public GameObject itemEquipSellPanel = null;
    [SerializeField] private Button itemSlotButton;



    private void Update()
    {
        if (itemData != null)
        {
            itemSprite.SetActive(true);
            itemSprite.GetComponent<Image>().sprite = itemData.itemIcon;
            

            itemSlotButton.onClick.AddListener(ItemEquipSellPanel);
            itemSlotButton.onClick.AddListener(SetSellPanelItemData);

        }
    }

    public void ItemEquipSellPanel()
    {
        itemEquipSellPanel.SetActive(true);
    }

    void SetSellPanelItemData()
    {
        itemEquipSellPanel.GetComponent<ItemEquipSellPanel>().itemData = itemData;

    }


}
