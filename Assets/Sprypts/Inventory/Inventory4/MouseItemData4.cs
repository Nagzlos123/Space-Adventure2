using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class MouseItemData4 : MonoBehaviour
{
    public GameObject itemIcon;
    public InventoryItemData itemData;
    public PlayerInvemtorySlot4 playerInvemtorySlot4;

    public string itemCategory;
    public string itemSubCategory;

    private void Update()
    {
        //GetItemDataCategory();

        if (itemData != null)
        {
            itemIcon.GetComponent<Image>().sprite = itemData.itemIcon;

            transform.position = Input.mousePosition;

            if (Mouse.current.leftButton.wasPressedThisFrame && !IsPointerOwerUIObject())
            {
                ClearSlot();
            }
        }
    }

    public void ClearSlot()
    {
        itemIcon.GetComponent<Image>().color = Color.clear;
        itemIcon.GetComponent<Image>().sprite = null;
    }

    public static bool IsPointerOwerUIObject()
    {
        PointerEventData pointerEventDataCurrentPosition = new PointerEventData(EventSystem.current);
        pointerEventDataCurrentPosition.position = Mouse.current.position.ReadValue();

        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerEventDataCurrentPosition, results);
        return results.Count > 0;
    }

    public void GetItemDataCategory()
    {
        if (itemData != null)
        {
            InventoryItemData currentItemData = itemData;
            itemCategory = currentItemData.itemCategory;
            itemSubCategory = currentItemData.itemSubCategory;
        }
    }
}
