using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SystemInstruction : MonoBehaviour
{
    [SerializeField] private GameObject nextButton;
    [SerializeField] private GameObject previousButton;
    [SerializeField] private TextMeshProUGUI panelTitleName;
    [SerializeField] private TextMeshProUGUI infoDescryption;
    [SerializeField] private GameObject infoImage;
    [SerializeField] private GameInstructionData[] instructionDatas;
    public int instructionDataID = 0;
    private void Start()
    {
        //GetGameInstructionData(instructionDataID);
    }
    public void GetGameInstructionData(int instructionDataID)
    {
        GameInstructionData currentTnstructionData = instructionDatas[instructionDataID];
        var panelName = currentTnstructionData.panelName;
        var descryption = currentTnstructionData.discreption;
        panelTitleName.text = panelName;
        infoDescryption.text = descryption;

        infoImage.GetComponent<Image>().sprite = currentTnstructionData.displayImage;

    }

    public void NextInfoPanel()
    {
        if(instructionDataID != instructionDatas.Length -1) instructionDataID++;
    }

    public void PreviousInfoPanel()
    {
        if (instructionDataID != 0) instructionDataID--;
    }

    public void BackButton()
    {
        instructionDataID = 0;
    }

    private void Update()
    {
        if (instructionDataID == 0)
        {
            previousButton.SetActive(false);
            nextButton.SetActive(true);
        }

        if (instructionDataID > 0 && instructionDataID < instructionDatas.Length)
        {
            previousButton.SetActive(true);
            nextButton.SetActive(true);
        }

        if(instructionDataID == instructionDatas.Length -1)
        {
            previousButton.SetActive(true);
            nextButton.SetActive(false);
        }

        //if(instructionDataID != instructionDatas.Length)
        GetGameInstructionData(instructionDataID);
    }
}
