using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Inventory System/Inventory Item")]
public class InventoryItemData : ScriptableObject
{
    public Sprite itemIcon;
    public int maxStackSize;
    public int itemCost;
    public int armorAmplifier;
    public int healthAmplifier;
    public int attackAmplifier;
    public string displayName;
    public string itemCategory;
    public string itemSubCategory;
    
    [TextArea(4, 4)]
    public string discreption;

}
