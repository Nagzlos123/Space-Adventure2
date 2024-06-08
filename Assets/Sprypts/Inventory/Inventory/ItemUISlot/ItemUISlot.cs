using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;
public class ItemUISlot 
{
    public InventoryItemData itemData;
    [SerializeField] private GameObject itemSprite;
    [SerializeField] private GameObject underlay;
    [SerializeField] private Button itemSlotButton;

    public void SetPanelItemData()
    {

    }

    public void ActivatePanelItemData()
    {

    }

    protected void InitItemSlot(UnityAction activatePanelItemData, UnityAction setPanelItemData)
    {

    }
}
