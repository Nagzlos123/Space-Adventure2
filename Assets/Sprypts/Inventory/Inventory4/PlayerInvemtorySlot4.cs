using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInvemtorySlot4 : MonoBehaviour
{
    public InventoryItemData itemData;
    public GameObject itemIcon;
    public string acceptableSlotCategory;
    public string acceptableSlotSubCategory;
    public GameObject removeItemPanel = null;
    [SerializeField] private Button playerSlotButton;
    [SerializeField] private RemoveEquipedItem removeItem;
    [SerializeField] private GameObject mouseItem;
    [SerializeField] private GameObject equipItemPanel;
    [SerializeField] private GameObject noItemMach;
    [SerializeField] private EquipItemManager equipItemManager;
    public void SetEquiptItemIcon(string slotCategoty, string slotSubCategoty, InventoryItemData itemData4)
    {

        if (acceptableSlotCategory == "SpaceshipElements" && acceptableSlotSubCategory == slotSubCategoty)
        {
            itemData = itemData4;
            itemIcon.SetActive(true);
            itemIcon.GetComponent<Image>().sprite = itemData.itemIcon;
        }

        if (acceptableSlotCategory == slotCategoty && acceptableSlotSubCategory == "")
        {
            itemData = itemData4;
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
            //playerSlotButton.interactable = false;
        }

        if (itemData != null)
        {
            itemIcon.SetActive(true);
            //playerSlotButton.interactable = true;
      
        }

        if(itemData == null && mouseItem.activeSelf == true)
        {
            //playerSlotButton.onClick.AddListener(EguipOn);
            playerSlotButton.onClick.AddListener(GetPlayerInventorySlot);
            //Debug.Log("itemData ")
        }
        if (itemData != null && mouseItem.activeSelf == true)
        {
            //playerSlotButton.onClick.AddListener(EguipOn);
           
            playerSlotButton.onClick.AddListener(ItemRemovePanelOff);
            playerSlotButton.onClick.AddListener(GetPlayerInventorySlot);
        }

        if (itemData != null && mouseItem.activeSelf == false)
        {
            playerSlotButton.onClick.AddListener(ItemRemovePanel);
            playerSlotButton.onClick.AddListener(SetRemovePanelItemData);
        }
    }

    public void ItemRemovePanel()
    {
        removeItemPanel.SetActive(true);
    }
    public void ItemRemovePanelOff()
    {
        removeItemPanel.SetActive(false);
    }


    public void SetRemovePanelItemData()
    {
        removeItem.itemData = itemData;
    }

    public void GetPlayerInventorySlot()
    {
        mouseItem.GetComponent<MouseItemData4>().playerInvemtorySlot4 = this.GetComponent<PlayerInvemtorySlot4>();
        

        if (mouseItem.GetComponent<MouseItemData4>().itemCategory == acceptableSlotCategory)
        {
            Debug.Log("Items categorys do mach!");
            equipItemPanel.SetActive(true);
        }
        else
        {
            Debug.Log("Items categorys don't mach!");
            noItemMach.SetActive(true);
        }
    }
  
}
