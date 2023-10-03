using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SwitchInventory : MonoBehaviour
{
    [SerializeField] private GameObject shopButton;
    [SerializeField] private TextMeshProUGUI inventorySystemName;

    [SerializeField] private GameObject mainSystem1;
    [SerializeField] private GameObject mainSystem2;
    [SerializeField] private GameObject mainSystem3;
    [SerializeField] private GameObject mainSystem4;
    [SerializeField] private GameObject mainSystem5;

    [SerializeField] private GameObject shopSystem2;
    [SerializeField] private GameObject shopSystem4;
    [SerializeField] private GameObject shopSystem5;

    [SerializeField] private GameObject statsUpgradeManager1;
    [SerializeField] private GameObject statsUpgradeManager2;
    [SerializeField] private GameObject statsUpgradeManager3;
    [SerializeField] private GameObject statsUpgradeManager4;
    [SerializeField] private GameObject statsUpgradeManager5;

    [SerializeField] private GameObject cheatsSystem1;
    [SerializeField] private GameObject cheatsSystem2;
    [SerializeField] private GameObject cheatsSystem3;
    [SerializeField] private GameObject cheatsSystem4;
    [SerializeField] private GameObject cheatsSystem5;


    public ButtonIventorySwitch buttonIventorySwitch;

    public int inventorySystemActive;
    void Start()
    {
        inventorySystemActive = PlayerPrefs.GetInt("InventorySystemActive");
    }

  public void SwitchInventorySystem()
    {
        inventorySystemActive = PlayerPrefs.GetInt("InventorySystemActive");
        if (inventorySystemActive == 1)
        {
            shopButton.SetActive(false);
            inventorySystemName.text = "Equipment 1";

            mainSystem1.SetActive(true);
            mainSystem2.SetActive(false);
            mainSystem3.SetActive(false);
            mainSystem4.SetActive(false);
            mainSystem5.SetActive(false);

            statsUpgradeManager1.SetActive(true);
            statsUpgradeManager2.SetActive(false);
            statsUpgradeManager3.SetActive(false);
            statsUpgradeManager4.SetActive(false);
            statsUpgradeManager5.SetActive(false);

            cheatsSystem1.SetActive(true);
            cheatsSystem2.SetActive(false);
            cheatsSystem3.SetActive(false);
            cheatsSystem4.SetActive(false);
            cheatsSystem5.SetActive(false);
        }
        else if (inventorySystemActive == 2)
        {
            shopButton.SetActive(true);
            inventorySystemName.text = "Equipment 2";

            mainSystem1.SetActive(false);
            mainSystem2.SetActive(true);
            mainSystem3.SetActive(false);
            mainSystem4.SetActive(false);
            mainSystem5.SetActive(false);

            shopSystem2.SetActive(true);
            shopSystem4.SetActive(false);
            shopSystem5.SetActive(false);

            statsUpgradeManager1.SetActive(false);
            statsUpgradeManager2.SetActive(true);
            statsUpgradeManager3.SetActive(false);
            statsUpgradeManager4.SetActive(false);
            statsUpgradeManager5.SetActive(false);

            cheatsSystem1.SetActive(false);
            cheatsSystem2.SetActive(true);
            cheatsSystem3.SetActive(false);
            cheatsSystem4.SetActive(false);
            cheatsSystem5.SetActive(false);


        }
        else if(inventorySystemActive == 3)
        {
            shopButton.SetActive(false);
            inventorySystemName.text = "Equipment 3";

            mainSystem1.SetActive(false);
            mainSystem2.SetActive(false);
            mainSystem3.SetActive(true);
            mainSystem4.SetActive(false);
            mainSystem5.SetActive(false);

            statsUpgradeManager1.SetActive(false);
            statsUpgradeManager2.SetActive(false);
            statsUpgradeManager3.SetActive(true);
            statsUpgradeManager4.SetActive(false);
            statsUpgradeManager5.SetActive(false);

            cheatsSystem1.SetActive(false);
            cheatsSystem2.SetActive(false);
            cheatsSystem3.SetActive(true);
            cheatsSystem4.SetActive(false);
            cheatsSystem5.SetActive(false);

        }
        else if (inventorySystemActive == 4)
        {
            shopButton.SetActive(true);
            inventorySystemName.text = "Equipment 4";

            mainSystem1.SetActive(false);
            mainSystem2.SetActive(false);
            mainSystem3.SetActive(false);
            mainSystem4.SetActive(true);
            mainSystem5.SetActive(false);

            shopSystem2.SetActive(false);
            shopSystem4.SetActive(true);
            shopSystem5.SetActive(false);

            statsUpgradeManager1.SetActive(false);
            statsUpgradeManager2.SetActive(false);
            statsUpgradeManager3.SetActive(false);
            statsUpgradeManager4.SetActive(true);
            statsUpgradeManager5.SetActive(false);

            cheatsSystem1.SetActive(false);
            cheatsSystem2.SetActive(false);
            cheatsSystem3.SetActive(false);
            cheatsSystem4.SetActive(true);
            cheatsSystem5.SetActive(false);

        }
        else if (inventorySystemActive == 5)
        {
            shopButton.SetActive(true);
            inventorySystemName.text = "Equipment 5";

            mainSystem1.SetActive(false);
            mainSystem2.SetActive(false);
            mainSystem3.SetActive(false);
            mainSystem4.SetActive(false);
            mainSystem5.SetActive(true);

            shopSystem2.SetActive(false);
            shopSystem4.SetActive(false);
            shopSystem5.SetActive(true);

            statsUpgradeManager1.SetActive(false);
            statsUpgradeManager2.SetActive(false);
            statsUpgradeManager3.SetActive(false);
            statsUpgradeManager4.SetActive(false);
            statsUpgradeManager5.SetActive(true);

            cheatsSystem1.SetActive(false);
            cheatsSystem2.SetActive(false);
            cheatsSystem3.SetActive(false);
            cheatsSystem4.SetActive(false);
            cheatsSystem5.SetActive(true);

        }
    }

    private void Update()
    {
        SwitchInventorySystem();
    }
}
