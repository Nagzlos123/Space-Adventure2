using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KosmosData : MonoBehaviour
{
    public GameObject[] artefacts;
    public StoreData storeData;
    public GameObject artefact1Panel = null;
    public GameObject artefact2Panel = null;
    public GameObject artefact3Panel = null;
    public GameObject artefact4Panel = null;
    public GameObject shopManager = null;
    [SerializeField] private GameObject moz4Image = null;
    [SerializeField] private GameObject moz5Image = null;
    [SerializeField] private GameObject compliteArtefacButton = null;
    [SerializeField] private GameObject goButton = null;
    
    [SerializeField] private Button P1Button = null;
    [SerializeField] private Button P2Button = null;
    [SerializeField] private Button P3Button = null;
    [SerializeField] private Button P4Button = null;
    public static KosmosData Instance;

    private int Planet1On;
    private int Planet2On;
    private int Planet3On;
    private int Planet4On;
    private int NewGame;
    private int artefactPanel;
    private int resetAll;


    void Awake()
    {
        Instance = this;
        
    }

    void Start()
    {


        /*
        if (storeData.playButtonOn)
        {



            resetAll = PlayerPrefs.GetInt("ResetAll");
            Debug.Log("number" + resetAll);

            if (resetAll == 1)
            {
                //shopManager.GetComponent<ShopManager>().ReseteAll();
            }

            LoadGameState();

           
            
                
            
            
           
          
            //storeData.playButtonOn = false;
        }

        if (storeData.gameWinOkButtonOn)
        {

            LoadGameState();


        }

    }
    public void LoadGameState()
    {
        Planet1On = PlayerPrefs.GetInt("Planet1On");
        Planet2On = PlayerPrefs.GetInt("Planet2On");
        Planet3On = PlayerPrefs.GetInt("Planet3On");
        Planet4On = PlayerPrefs.GetInt("Planet4On");
        NewGame = PlayerPrefs.GetInt("NewGame");
        artefactPanel = PlayerPrefs.GetInt("ArtefactPanel");
        


        for (int artefactIndex = 0; artefactIndex <= 5; artefactIndex++)
        {
            if (artefactIndex != artefactPanel)
            {
                artefacts[artefactIndex].SetActive(false);
            }
            else
            {

                artefacts[artefactIndex].SetActive(true);

            }

        }

       if(moz4Image.activeSelf)
        {
            compliteArtefacButton.SetActive(true);
        }

        if (moz5Image.activeSelf)
        {
            goButton.SetActive(true);
        }

        if (Planet1On == 1)
        {
            
            P1Button.interactable = true;
        }
        else
        {
            P1Button.interactable = false;
        }

        if (Planet2On == 1)
        {
            
            P2Button.interactable = true;
        }
        else
        {
            P2Button.interactable = false;
        }

        if (Planet3On == 1)
        {
            
            P3Button.interactable = true;
        }
        else
        {
            P3Button.interactable = false;
        }


        if (Planet4On == 1)
        {
            P4Button.interactable = true;
            
        }
        else
        {
            P4Button.interactable = false;
        }

        if (NewGame == 1)
        {
            
            P1Button.interactable = false;
            P2Button.interactable = false;
            P3Button.interactable = false;
            P4Button.interactable = false;
        }
        */

    }

}
