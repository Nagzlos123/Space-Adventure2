using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PortalColisions : MonoBehaviour
{
   
    public string sceneName;
    void Start()
    {
        

    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        ProcessCollision(collider.gameObject);
    }
    void ProcessCollision(GameObject collider)
    {

        if (collider.CompareTag("Portal"))
        {
            //PlayerPrefs.GetFloat("kredytAmountWin", kredytAmount);
            //SceneManager.LoadScene("GameCompleted");
            GetComponent<LoadScen>().LoadScnenName(sceneName);
        }
    }
}

