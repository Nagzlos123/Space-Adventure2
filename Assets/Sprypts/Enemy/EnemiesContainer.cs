using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesContainer : MonoBehaviour
{
    [SerializeField] private GameObject kreystalSpawner;

    public int enemyCount;
    //[SerializeField] private GameObject[] allChildren;
   private void Start()
    {
        kreystalSpawner.SetActive(false);
    }

    //[System.Obsolete]
    private void Update()
    {

        enemyCount = this.gameObject.transform.childCount;
        //enemyCount = gameObject.transform.GetChildCount();
        if(enemyCount == 0)
        {

            kreystalSpawner.SetActive(true);
          
        }
        else kreystalSpawner.SetActive(false);
        //SetSpawnerActive();
    }
    private void SetSpawnerActive()
    {
        Transform[] allChildren = GetComponentsInChildren<Transform>();
        if(allChildren != null)
        {
            foreach (Transform child in allChildren)
            {
                for (int i = 0; i < allChildren.Length; i++)
                {
                    allChildren[i] = transform.GetChild(i);
                }
            }
        }
    
        
     
    }
}
