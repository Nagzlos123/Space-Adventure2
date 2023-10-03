using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class ItemPickup : MonoBehaviour
{
    //public float pickupRadius = 1f;
    public InventoryItemData itemData;

    private BoxCollider2D collider2D;

    private void Awake()
    {
        collider2D = GetComponent<BoxCollider2D>();
        collider2D.isTrigger = true;
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var inventory = collision.transform.GetComponent<InventoryHolder>();
        if (!inventory) return;

        if (inventory.InventorySystem.AddToInventory(itemData, 1))
        {
            Destroy(this.gameObject);
        }
    }
}
