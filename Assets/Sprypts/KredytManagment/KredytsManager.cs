using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KredytsManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI mainKredytsNumber;
  
   
  
    [Header("Inventory System ")]
    [SerializeField] private TextMeshProUGUI yourKredytsNumberSystem;
    [SerializeField] private TextMeshProUGUI shopBuyKredytsNumberSystem;
    [SerializeField] private TextMeshProUGUI shopSellKredytsNumberSystem;
   
    public  float yourKredyts;
    public bool saveKredyts = false;

    private void Start()
    {
        //PlayerPrefs.SetFloat("yourKredytNumber", 0);
    }

    private void Update()
    {

        ResetKredyts();
        yourKredyts = PlayerPrefs.GetFloat("yourKredytNumber");

        if (mainKredytsNumber != null)
            mainKredytsNumber.text = PlayerPrefs.GetFloat("yourKredytNumber").ToString();

        if (yourKredytsNumberSystem != null)
            yourKredytsNumberSystem.text = PlayerPrefs.GetFloat("yourKredytNumber").ToString();

        if (shopBuyKredytsNumberSystem != null)
            shopBuyKredytsNumberSystem.text = PlayerPrefs.GetFloat("yourKredytNumber").ToString();

        if (shopSellKredytsNumberSystem != null)
            shopSellKredytsNumberSystem.text = PlayerPrefs.GetFloat("yourKredytNumber").ToString();
    }

    public void ResetKredyts()
    {
        if (saveKredyts == true) PlayerPrefs.SetFloat("yourKredytNumber", 0);
    }


    public void SubtractKredyts(float itemPrice)
    {
        if (yourKredyts != 0)
        {
            PlayerPrefs.SetFloat("yourKredytNumber", PlayerPrefs.GetFloat("yourKredytNumber") - itemPrice);
        }
    }

    public void AddKredyts(float itemPrice)
    {
        PlayerPrefs.SetFloat("yourKredytNumber", PlayerPrefs.GetFloat("yourKredytNumber") + itemPrice);
    }

    public static void CheatAddKredyts(float cheatKredytsToAdd)
    {
        PlayerPrefs.SetFloat("yourKredytNumber", PlayerPrefs.GetFloat("yourKredytNumber") + cheatKredytsToAdd);
    }
}
