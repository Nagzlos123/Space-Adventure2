using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KredytsManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI mainKredytsNumber;
    [Header("System 1")]
    [SerializeField] private TextMeshProUGUI yourKredytsNumberSystem1;
    [Header("System 2")]
    [SerializeField] private TextMeshProUGUI yourKredytsNumberSystem2;
    [Header("System 3")]
    [SerializeField] private TextMeshProUGUI yourKredytsNumberSystem3;
    [Header("System 4")]
    [SerializeField] private TextMeshProUGUI yourKredytsNumberSystem4;
    [SerializeField] private TextMeshProUGUI shopBuyKredytsNumberSystem4;
    [SerializeField] private TextMeshProUGUI shopSellKredytsNumberSystem4;
    [Header("System 5")]
    [SerializeField] private TextMeshProUGUI yourKredytsNumberSystem5;
    [SerializeField] private TextMeshProUGUI shopKredytsNumberSystem5;
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

        mainKredytsNumber.text = PlayerPrefs.GetFloat("yourKredytNumber").ToString();
        if (yourKredytsNumberSystem1 != null)
            yourKredytsNumberSystem1.text = PlayerPrefs.GetFloat("yourKredytNumber").ToString();

        if (yourKredytsNumberSystem2 != null)
            yourKredytsNumberSystem2.text = PlayerPrefs.GetFloat("yourKredytNumber").ToString();

        if (yourKredytsNumberSystem3 != null)
        yourKredytsNumberSystem3.text = PlayerPrefs.GetFloat("yourKredytNumber").ToString();

        if (yourKredytsNumberSystem4 != null)
            yourKredytsNumberSystem4.text = PlayerPrefs.GetFloat("yourKredytNumber").ToString();

        if (shopBuyKredytsNumberSystem4 != null)
            shopBuyKredytsNumberSystem4.text = PlayerPrefs.GetFloat("yourKredytNumber").ToString();

        if (shopSellKredytsNumberSystem4 != null)
            shopSellKredytsNumberSystem4.text = PlayerPrefs.GetFloat("yourKredytNumber").ToString();

        if (yourKredytsNumberSystem5 != null)
            yourKredytsNumberSystem5.text = PlayerPrefs.GetFloat("yourKredytNumber").ToString();

        if (shopKredytsNumberSystem5 != null)
            shopKredytsNumberSystem5.text = PlayerPrefs.GetFloat("yourKredytNumber").ToString();

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
