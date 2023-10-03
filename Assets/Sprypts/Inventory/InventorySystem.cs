using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;

[System.Serializable]
public class InventorySystem
{
    [SerializeField] private List<InventorySlot> inventorySlots;

    public List<InventorySlot> inventorySlotsP => inventorySlots;

    public int inventorySize => inventorySlots.Count;
    //action to add item to inventory
    public UnityAction<InventorySlot> OnInventoryChanged;

    public InventorySystem(int size)
    {
        inventorySlots = new List<InventorySlot>(size);

        for (int i = 0; i < size; i++)
        {
            inventorySlots.Add(new InventorySlot());
        }
    }

    public bool AddToInventory(InventoryItemData itemToAdd, int amount)
    {
        if (ContainsItem(itemToAdd, out List<InventorySlot> inventorySlots))// Sprawdz czy item istnieje.
        {
            foreach (var slot in inventorySlots)
            {
                if(slot.RoomInStack(amount))
                {
                    slot.AddToStack(amount);
                    OnInventoryChanged?.Invoke(slot);
                    return true;
                }
            }
           
        }
         if(HaveFreeSlot(out InventorySlot freeSlot)) // Gets first item
        {
            freeSlot.UdateInventorySlot(itemToAdd, amount);
            OnInventoryChanged?.Invoke(freeSlot);
            return true;
        }
        return false;
    }

    public bool ContainsItem(InventoryItemData itemToAdd, out List<InventorySlot> inventorySlots)
    {
        inventorySlots = inventorySlotsP.Where(i => i.ItemData == itemToAdd).ToList();
        return inventorySlots == null ? false : true; // If list hava a at least 1 item return true else false 
    }  

    public bool HaveFreeSlot(out InventorySlot freeSlot)
    {
        freeSlot = inventorySlotsP.FirstOrDefault(i => i.ItemData == null);
        return freeSlot == null ? false : true;
    }
}
