using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameWinControler : MonoBehaviour
{
    [SerializeField] private GameObject dataControl = null;
    [SerializeField] private Button OkButton = null;
    private float kredytAmount;
    Text kredytWinNumber;
 
    private float kredytAmountWin;
    private float kredyts;
    private float yourKredyts;
    
    Text yourKredytNumber;
   

    // Start is called before the first frame update
    void Start()
    {
        kredytWinNumber = GameObject.Find("KredytWinNumber").GetComponent<Text>();
        kredytWinNumber.text = PlayerPrefs.GetFloat("kredytAmountWin").ToString();

        
        OkButton.onClick.AddListener(() => {


            
        
        PlayerPrefs.SetFloat("yourKredytNumber", PlayerPrefs.GetFloat("yourKredytNumber") + PlayerPrefs.GetFloat("kredytAmountWin"));

            PlayerPrefs.SetInt("AutoLoadOn", 1);
            SceneManager.LoadScene("MainGame");
            
        });
        
        
    }

    public void OnGameWinOkButtonClick()
    {
        //KosmosData.Instance.LoadGameState();
       dataControl.GetComponent<GameWinData>().SetGameWinOkButtonOn();
    }

  
}
