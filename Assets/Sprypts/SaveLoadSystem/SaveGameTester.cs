using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveGameTester : MonoBehaviour
{
    public void SaveGame()
    {
        SaveGameManeger.Save();
    }

    public void LoadGame()
    {
        SaveGameManeger.Load();
    }
}
