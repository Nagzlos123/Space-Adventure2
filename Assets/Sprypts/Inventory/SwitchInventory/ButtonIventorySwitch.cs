using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ButtonIventorySwitch : MonoBehaviour
{
  

    private void Start()
    {
        PlayerPrefs.SetInt("InventorySystemActive", PlayerPrefs.GetInt("InventorySystemActive"));
    }
   
    public void OnButtonClicked(Button selectedButton)
    {

    }

    public void OnSystemButton1Clicked()
    {
 
        PlayerPrefs.SetInt("InventorySystemActive", 1);
    }

    public void OnSystemButton2Clicked()
    {

        PlayerPrefs.SetInt("InventorySystemActive", 2);
        SetPlayerStac();
    }

    public void OnSystemButton3Clicked()
    {

        PlayerPrefs.SetInt("InventorySystemActive", 3);
        SetPlayerStac();
    }

    public void OnSystemButton4Clicked()
    {

        PlayerPrefs.SetInt("InventorySystemActive", 4);
        SetPlayerStac();
    }

    public void OnSystemButton5Clicked()
    {

        PlayerPrefs.SetInt("InventorySystemActive", 5);
        SetPlayerStac();
    }

    public void ResetInventorySystem()
    {
        SceneManager.LoadScene("MainGame");
    }

    public void SetPlayerStac()
    {
        PlayerPrefs.SetInt("PlayerNormalHP", 1000);
        PlayerPrefs.SetInt("PlayerNormalArmor", 500);
        PlayerPrefs.SetInt("PlayerNormalAttack", 20);

        PlayerPrefs.SetInt("StarshipNormalHP", 600);
        PlayerPrefs.SetInt("StarshipNormalAttack", 5);

        PlayerPrefs.SetInt("PlayerFullHP", PlayerPrefs.GetInt("PlayerNormalHP"));
        PlayerPrefs.SetInt("PlayerFullArmor", PlayerPrefs.GetInt("PlayerNormalArmor"));
        PlayerPrefs.SetInt("PlayerFullAttack", PlayerPrefs.GetInt("PlayerNormalAttack"));

        PlayerPrefs.SetInt("SpaceshipFullAttack", PlayerPrefs.GetInt("StarshipNormalAttack"));
        PlayerPrefs.SetInt("SpaceshipFullHP", PlayerPrefs.GetInt("StarshipNormalHP"));
    }
}

