using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MainMenuManager : MonoBehaviour
{
    public void StartGame()
    {
        PlayerPrefs.SetInt("InventorySystemActive", 1);
        PlayerPrefs.SetInt("yourKredytNumber", 0);
        PlayerPrefs.SetInt("GameLoaded", 0);
    }

    public void ContinueGame()
    {
        PlayerPrefs.SetInt("GameLoaded", 1);
    }
}
