using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryUpgradeManager : MonoBehaviour
{
    public static bool gamePause = false;
    public GameObject upgradePanel;
    [SerializeField] private InventoryItemData[] itemData;
    [SerializeField] private TextMeshProUGUI itemDescryption;
    [SerializeField] private TextMeshProUGUI itemPrice;
    [SerializeField] private TextMeshProUGUI yourKredytsAmount;
    
    [SerializeField] private GameObject itemIcon;

    [SerializeField] private GameObject upgradeButton;
    [SerializeField] private GameObject maxButton;
    [SerializeField] private GameObject playerItemEquiptIcon;

    [SerializeField] private GameObject refusalToBuyPanel;

    [SerializeField] private StatsUpgradeManager upgradeManager;

   
    public string panelName;

    private int playerNormalHP;
    public int hpUpgrade;
    
    private int attackUpgrade;
    private int armorUpgrade;

    private string descryption;
    private float price;
    private float yourKredyts;
    [SerializeField] private GameObject kredytsManager;

    public int itemDataID = 0;


    private void Awake()
    {
       
    }

    private void Start()
    {
       
        //yourKredytsAmount =
        GetItemData(itemDataID);

        panelName = upgradePanel.name;
    }

    public void GetItemData(int itemDataID)
    {
        InventoryItemData currentItemData = itemData[itemDataID];
        descryption = currentItemData.discreption;
        price = currentItemData.itemCost;
        itemDescryption.text = descryption;
        itemPrice.text = price.ToString();
        hpUpgrade = currentItemData.healthAmplifier;
        //Image currentItemIcon = upgradeIcons[itemDataID];
        itemIcon.GetComponent<Image>().sprite = currentItemData.itemIcon;
        
    }

    private void UpgradePlayerStats(int itemDataID, string panelName)
    {
        InventoryItemData currentItemData = itemData[itemDataID];
        playerNormalHP = PlayerPrefs.GetInt("PlayerNormalHP");


        hpUpgrade = currentItemData.healthAmplifier;
        armorUpgrade = currentItemData.armorAmplifier;
        attackUpgrade = currentItemData.attackAmplifier;

        if (panelName == "HelmetUpgradePanel")
        {
            Debug.Log("HelmetUpgradePanel is active");
            upgradeManager.GetComponent<StatsUpgradeManager>().AddHelmetItemAmplifiers(armorUpgrade);
        }

        if (panelName == "ShouldersUpgradePanel")
        {
            upgradeManager.GetComponent<StatsUpgradeManager>().AddShouldersItemAmplifiers(hpUpgrade, armorUpgrade, attackUpgrade);
        }

        if (panelName == "BodyArmorUpgradePanel")
        {
            upgradeManager.GetComponent<StatsUpgradeManager>().AddBodyArmorItemAmplifiers(hpUpgrade, armorUpgrade);
        }

        if (panelName == "PantsUpgradePanel")
        {
            upgradeManager.GetComponent<StatsUpgradeManager>().AddPantsItemAmplifiers(hpUpgrade, armorUpgrade);
        }

        if (panelName == "GlovesUpgradePanel")
        {
            upgradeManager.GetComponent<StatsUpgradeManager>().AddGlovesItemAmplifiers(armorUpgrade, attackUpgrade);
        }

        if (panelName == "BootsUpgradePanel")
        {
            upgradeManager.GetComponent<StatsUpgradeManager>().AddBootsItemAmplifiers(armorUpgrade);
        }

        if (panelName == "BracersUpgradePanel")
        {
            upgradeManager.GetComponent<StatsUpgradeManager>().AddBracersItemAmplifiers(attackUpgrade);
        }

        if (panelName == "Liser1UpgradePanel")
        {
            upgradeManager.GetComponent<StatsUpgradeManager>().AddLiser1ItemAmplifiers(attackUpgrade);
        }

        if (panelName == "Liser2UpgradePanel")
        {
            upgradeManager.GetComponent<StatsUpgradeManager>().AddLiser2ItemAmplifiers(attackUpgrade);
        }

        if (panelName == "EngineUpgradePanel")
        {
            upgradeManager.GetComponent<StatsUpgradeManager>().AddEngineItemAmplifiers(hpUpgrade);
        }



        //playerHP.text = PlayerPrefs.GetInt("PlayerFullHP").ToString();
        //playerArmor.text = PlayerPrefs.GetInt("PlayerFullArmor").ToString();
        //playerAttack.text = 
    }
    private void UpdatePlayerEquiptItem(int itemDataID)
    {
        InventoryItemData currentItemData = itemData[itemDataID];
        playerItemEquiptIcon.GetComponent<Image>().sprite = currentItemData.itemIcon;
        playerItemEquiptIcon.gameObject.SetActive(true);
     

    }
    public void UpdateInventorySlot()
    {

        if (CheckItemCost())
        {
            ExecuteChanges();
        }
       
    }
    public void ExecuteChanges()
    {
        panelName = upgradePanel.name;
        
        GetItemData(itemDataID + 1);

        UpdatePlayerEquiptItem(itemDataID);
        UpgradePlayerStats(itemDataID, panelName);

        itemDataID++;

        if (itemDataID + 1 < itemData.Length + 1)
        {
            upgradeButton.SetActive(true);
            maxButton.SetActive(false);
        }

        if (itemDataID + 1 == itemData.Length)
        {
            upgradeButton.SetActive(false);
            maxButton.SetActive(true);
        }
    }

    public void ExecuteChanges2()
    {
        panelName = upgradePanel.name;

        GetItemData(itemDataID);
        if (itemDataID! == 0)
        {
            UpdatePlayerEquiptItem(itemDataID -1);
            UpgradePlayerStats(itemDataID -1, panelName);
        }
        
      

        itemDataID++;

        if (itemDataID  < itemData.Length)
        {
            upgradeButton.SetActive(true);
            maxButton.SetActive(false);
        }

        if (itemDataID == itemData.Length)
        {
            upgradeButton.SetActive(false);
            maxButton.SetActive(true);
        }
    }

    private bool CheckItemCost()
    {
        if (yourKredyts >= price )
        {
            Debug.Log("You bought upgrade ");
            kredytsManager.GetComponent<KredytsManager>().SubtractKredyts(price);
            return true;
        }
        else
        {
            Debug.Log("You don't have enough kredyts");
            refusalToBuyPanel.SetActive(true);
            return false;
        }
    }




    private void Update()
    {

        yourKredyts = PlayerPrefs.GetFloat("yourKredytNumber");
        panelName = upgradePanel.name;

  


    }
}
