using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWinData : MonoBehaviour
{
    public StoreData storeData;


    public void SetGameWinOkButtonOn()
    {
        storeData.gameWinOkButtonOn = true;
    }
}
