using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Inventory4BigSlotUI : MonoBehaviour
{
    public InventoryItemData itemData;
    [SerializeField] private GameObject itemSprite;
    [SerializeField] private Button itemSlotButton;
    [HideInInspector]
    public GameObject removeItemPanel = null;


    private void Update()
    {
        if (itemData != null)
        {
            itemSprite.SetActive(true);



            itemSlotButton.onClick.AddListener(ItemRemovePanel);
            itemSlotButton.onClick.AddListener(SetRemovePanelItemData);
        }
    }


    public void ItemRemovePanel()
    {
        removeItemPanel.SetActive(true);
    }

    public void SetRemovePanelItemData()
    {
        removeItemPanel.GetComponent<AddRemoveItemPanel>().itemData = itemData;
    }



}
