using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MainMenuManager : MonoBehaviour
{
    [SerializeField] GameObject ContinueButton;
    [SerializeField] int isGameSaved;
    public void StartGame()
    {
        PlayerPrefs.SetInt("InventorySystemActive", 6);
        PlayerPrefs.SetInt("yourKredytNumber", 0);
        PlayerPrefs.SetInt("GameLoaded", 0);
        PlayerPrefs.SetInt("GameSaved", 0);
    }

    public void ContinueGame()
    {
        PlayerPrefs.SetInt("GameLoaded", 1);
    }
    private void Update()
    {
        isGameSaved = PlayerPrefs.GetInt("GameSaved");

        if(isGameSaved == 1)
        {
            ActivateButton();
        }
        else
        {
            DeactivateButton();
        }
    }
    private void DeactivateButton()
    {
        ContinueButton.GetComponent<Button>().interactable = false;
    }

    private void ActivateButton()
    {
        ContinueButton.GetComponent<Button>().interactable = true;
    }
}
