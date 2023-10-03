using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestShopManager : MonoBehaviour
{
    //private float price;
    private float yourKredyts;
    [SerializeField] private GameObject kredytsManager;
    [SerializeField] private GameObject refusalToBuyPanel;
    [SerializeField] private GameObject boughtChesItemSetPanel;
    [SerializeField] private GameObject inventory2;
    private ChestItemSetManager chestItemSetManager;
    public int itemNumber;

    private void Start()
    {
        boughtChesItemSetPanel.SetActive(false);
    }
    private bool CheckItemCost(float price, int itemNumber)
    {
        if (yourKredyts >= price)
        {
            Debug.Log("You bought chest ");
            kredytsManager.GetComponent<KredytsManager>().SubtractKredyts(price);
            inventory2.GetComponent<InventoryItemManager>().ChestRandomItemSet(itemNumber);
            boughtChesItemSetPanel.SetActive(true);
            return true;
        }
        else
        {
            Debug.Log("You don't have enough kredyts");
            refusalToBuyPanel.SetActive(true);
            return false;
        }
    }

    public void GetItemNumber(int itemNum)
    {
        itemNumber = itemNum;
    }
    public void BuyChest(float price)
    {
        if (CheckItemCost(price, itemNumber))
        {
            //Debug.Log("");
        }
    }
    private void Update()
    {
        yourKredyts = PlayerPrefs.GetFloat("yourKredytNumber");
    }
}
