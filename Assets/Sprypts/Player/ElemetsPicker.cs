using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ElemetsPicker : MonoBehaviour
{
    private float kredytAmount = 0;
    public static float kredytAmountTmp;
    [SerializeField] private Text kredytNumber = null;
    [SerializeField] private Text coinsNumber = null;
    [SerializeField] private GameObject dataControl = null;
    private float coins = 0;
  

    private static float kredytAmountWin;

    void Start()
    {
   


    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        ProcessCollision(collider.gameObject);
    }
    void ProcessCollision(GameObject collider)
    { 

        if (collider.CompareTag("KredytDrop"))
        {
            kredytAmount += 20;
            kredytNumber.text = kredytAmount.ToString();
            kredytAmountTmp = kredytAmount;
            Debug.Log("Kredyt" + kredytAmountTmp);
            PlayerPrefs.SetFloat("kredytAmountWin", kredytAmount);
            Destroy(collider.gameObject);
        }

        if (collider.CompareTag("Artefact1"))
        {
            SceneManager.LoadScene("KosmosPanel");
            //dataControl.GetComponent<ArtefactData>().SetArtefact1PanelActive();
           
        }

        if (collider.CompareTag("Artefact2"))
        {
            SceneManager.LoadScene("KosmosPanel");
            //dataControl.GetComponent<ArtefactData>().SetArtefact2PanelActive();
        }

        if (collider.CompareTag("Artefact3"))
        {
            SceneManager.LoadScene("KosmosPanel");
            //dataControl.GetComponent<ArtefactData>().SetArtefact3PanelActive();
        }

        if (collider.CompareTag("Artefact4"))
        {
            SceneManager.LoadScene("KosmosPanel");
            //dataControl.GetComponent<ArtefactData>().SetArtefact4PanelActive();
        }
        if (collider.CompareTag("Coin"))
        {
            coins++;
            coinsNumber.text = coins.ToString();
            PlayerPrefs.SetFloat("coinAmountWin", coins);
            Destroy(collider.gameObject);
        }
    }

  
}

   
