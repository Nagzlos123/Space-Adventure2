using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class MouseItemData : MonoBehaviour
{
    public Image itemSprite;
    public TextMeshProUGUI itemCount;
    public InventorySlot assignedInventorySlot;

    private void Awake()
    {
        itemSprite.color = Color.clear;
        itemCount.text = "";
    }

    internal void UpdateMouseSlot(InventorySlot inventorySlot)
    {
        assignedInventorySlot.AssignItem(inventorySlot);
        itemSprite.sprite = inventorySlot.ItemData.itemIcon;
        itemCount.text = inventorySlot.StackSize.ToString();
        itemSprite.color = Color.white;

    }

    private void Update()
    {
        if (assignedInventorySlot.ItemData != null)
        {
            transform.position = Input.mousePosition;

            if(Mouse.current.leftButton.wasPressedThisFrame && !IsPointerOwerUIObject())
            {
                ClearSlot();
            }
        }
    }

    public void ClearSlot()
    {
        assignedInventorySlot.ClearSlot();
        itemCount.text = "";
        itemSprite.color = Color.clear;
        itemSprite.sprite = null;
    }

    public static bool IsPointerOwerUIObject()
    {
        PointerEventData pointerEventDataCurrentPosition = new PointerEventData(EventSystem.current);
        pointerEventDataCurrentPosition.position = Mouse.current.position.ReadValue();

        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerEventDataCurrentPosition, results);
        return results.Count > 0;
    }

}
