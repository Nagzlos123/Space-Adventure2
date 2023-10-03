using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InventorySlot 
{
    [SerializeField] private InventoryItemData itemData;
    [SerializeField] private int stackSize;

    public InventoryItemData ItemData => itemData;
    public int StackSize => stackSize;
    
    public InventorySlot(InventoryItemData sorce, int amount)
    {
        itemData = sorce;
        stackSize = amount;
    }

    public InventorySlot()
    {
        ClearSlot();
    }

    public void AssignItem(InventorySlot inventorySlot)
    {
        if (itemData = inventorySlot.itemData) AddToStack(inventorySlot.stackSize);
        else
        {
            itemData = inventorySlot.itemData;
            stackSize = 0;
            AddToStack(inventorySlot.stackSize);
        }
    }

    public void ClearSlot()
    {
        itemData = null;
        stackSize = -1;
    }

    public void AddToStack(int amount)
    {
        stackSize += amount;
    }

    public void RemoveFromStack(int amount)
    {
        stackSize -= amount;
    }

    public bool RoomInStack(int amountToAdd)
    {
        if (stackSize + amountToAdd <= itemData.maxStackSize) return true;
        else return false;
    }

    public bool RoomInStack(int amountToAdd, out int amountRemaining)
    {
        amountRemaining = itemData.maxStackSize - stackSize;
        return RoomInStack(amountToAdd);
    }
    public void UdateInventorySlot(InventoryItemData data, int amount)
    {
        itemData = data;
        stackSize = amount;
    }

}
