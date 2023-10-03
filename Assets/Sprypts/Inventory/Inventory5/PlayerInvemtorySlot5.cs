using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInvemtorySlot5 : MonoBehaviour
{
    public InventoryItemData itemData;
    public GameObject itemIcon;
    public string acceptableSlotCategory;
    public string acceptableSlotSubCategory;
    //public GameObject removeItemPanel = null;
    [SerializeField] private Button playerSlotButton;

    public void SetEquiptItemIcon(string slotCategoty, InventoryItemData itemData5)
    {
        if (acceptableSlotCategory == slotCategoty )
        {
            itemData = itemData5;
            itemIcon.SetActive(true);
            itemIcon.GetComponent<Image>().sprite = itemData.itemIcon;
        }
        else
        {
            Debug.Log("Can't set EquiptItemIcon!");
        }

    }

    public void ResetPlayerSlot(string slotCategoty)
    {
        if (acceptableSlotCategory == slotCategoty) itemData = null;
    }

    public void ResetPlayerSlot()
    {
        itemData = null;
    }
    private void Update()
    {
        if (itemData == null)
        {
            itemIcon.SetActive(false);
            playerSlotButton.interactable = false;
        }

        if (itemData != null)
        {
            itemIcon.SetActive(true);
            playerSlotButton.interactable = true;
            //playerSlotButton.onClick.AddListener(ItemRemovePanel);
            //playerSlotButton.onClick.AddListener(SetRemovePanelItemData);
        }
    }
    /*
    public void ItemRemovePanel()
    {
        removeItemPanel.SetActive(true);
    }

    public void SetRemovePanelItemData()
    {
        removeItemPanel.GetComponent<ItemRemovePanel>().itemData = itemData;
    }
    */
}
