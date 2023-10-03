using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public static class SaveGameManeger
{
    public static GameSaveData CurrentGameSaveData = new GameSaveData();

    public const string directory = "/SaveData/";
    public const string fileName = "Save.txt";
    public static bool Save()
    {
        var dir = Application.persistentDataPath + directory;
        if (!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }

        string json = JsonUtility.ToJson(CurrentGameSaveData, true);
        File.WriteAllText(dir + fileName, json);
        GUIUtility.systemCopyBuffer = dir;
        return true;
    }

    public static void Load()
    {
        string fullPath = Application.persistentDataPath + directory + fileName;
        GameSaveData tempData = new GameSaveData();

        if (File.Exists(fullPath))
        {
            string json = File.ReadAllText(fullPath);
            tempData = JsonUtility.FromJson<GameSaveData>(json);

        }
        else
        {
            Debug.LogError("Save file dose not exist!");
        }

        CurrentGameSaveData = tempData;
    }
}
