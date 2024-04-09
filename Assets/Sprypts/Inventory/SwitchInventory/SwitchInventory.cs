using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SwitchInventory : MonoBehaviour
{
    [SerializeField] private GameObject shopButton;
    [SerializeField] private TextMeshProUGUI inventorySystemName;   
    [SerializeField] private GameObject mainSystem2;
 
    [SerializeField] private GameObject shopSystem4;
   
    [SerializeField] private GameObject cheatsSystem4;



    public ButtonIventorySwitch buttonIventorySwitch;

    public int inventorySystemActive;
    void Start()
    {
        inventorySystemActive = PlayerPrefs.GetInt("InventorySystemActive");
    }

  public void SwitchInventorySystem()
    {
        inventorySystemActive = PlayerPrefs.GetInt("InventorySystemActive");

        if (inventorySystemActive == 6)
        {
            shopButton.SetActive(true);
            inventorySystemName.text = "Equipment 6";

         
            mainSystem2.SetActive(true);

            shopSystem4.SetActive(true);
            cheatsSystem4.SetActive(true);




        }


    }

    private void Update()
    {
        SwitchInventorySystem();
    }
}
