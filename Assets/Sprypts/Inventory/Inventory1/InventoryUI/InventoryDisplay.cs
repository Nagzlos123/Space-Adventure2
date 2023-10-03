using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;



public abstract class InventoryDisplay : MonoBehaviour
{
    [SerializeField] MouseItemData mouseItemData;
    protected InventorySystem inventorySystem;
    protected Dictionary<InventorySlotUI, InventorySlot> slotDictionary;

    public InventorySystem InventorySystem => inventorySystem;
    public Dictionary<InventorySlotUI, InventorySlot> SlotDictionary => slotDictionary;

    protected virtual void Start()
    {

    }
    public abstract void AssignSlot(InventorySystem inventoryToDisplay);
    protected virtual void UpdateSlot(InventorySlot updateSlot)
    {
        foreach (var slot in SlotDictionary)
        {
            if (slot.Value == updateSlot) // Slot value
            {
                slot.Key.UpdateUISlot(updateSlot); // UI reprezentation of the value.
            }
        }
    }

    public void SlotClicked(InventorySlotUI clickedUISlot)
    {
        //Cliked slot has an item, mouse doesn't, pick up the item
        if(clickedUISlot.AssignedInventorySlot.ItemData != null && mouseItemData.assignedInventorySlot.ItemData == null)
        {
            //If player is holding shift key splite the stack

            mouseItemData.UpdateMouseSlot(clickedUISlot.AssignedInventorySlot);
            clickedUISlot.ClearSlot();
            return;
        }
        //Cliked slot doesn't have an item, mouse does, place the item in the emty inventoru slot
        if (clickedUISlot.AssignedInventorySlot.ItemData == null && mouseItemData.assignedInventorySlot.ItemData != null)
        {
            clickedUISlot.AssignedInventorySlot.AssignItem(mouseItemData.assignedInventorySlot);
            clickedUISlot.UpdateUISlot();

            mouseItemData.ClearSlot();
        }
        /*
        // Both slots have a iteam
        if(clickedUISlot.AssignedInventorySlot.ItemData != null && mouseItemData.assignedInventorySlot.ItemData != null)
        {
            //if items are the same
            if (clickedUISlot.AssignedInventorySlot.ItemData == mouseItemData.assignedInventorySlot.ItemData &&
                clickedUISlot.AssignedInventorySlot.RoomInStack(mouseItemData.assignedInventorySlot.StackSize))
            {

            }
            //if items aren't the same
            if (clickedUISlot.AssignedInventorySlot.ItemData != mouseItemData.assignedInventorySlot.ItemData)
            {
                SwapSlots(clickedUISlot);
            }
        }
        */
    }

    private void SwapSlots(InventorySlotUI clickedUISlot)
    {
        var cloundSlot = new InventorySlot(mouseItemData.assignedInventorySlot.ItemData, mouseItemData.assignedInventorySlot.StackSize);
        mouseItemData.ClearSlot();

        mouseItemData.UpdateMouseSlot(clickedUISlot.AssignedInventorySlot);

        clickedUISlot.ClearSlot();
        clickedUISlot.AssignedInventorySlot.AssignItem(cloundSlot);
        clickedUISlot.UpdateUISlot();
    }
}
