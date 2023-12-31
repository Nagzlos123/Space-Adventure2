using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveData : MonoBehaviour
{



	int currentScore = 0;
	string currentName = "Asd";
	float currentTimePlayed = 5.0f;

	void Start()
	{
		SaveFile();
		LoadFile();
	}

	public void SaveFile()
	{
		string destination = Application.persistentDataPath + "/save.dat";
		FileStream file;

		if (File.Exists(destination)) file = File.OpenWrite(destination);
		else file = File.Create(destination);

		//GameSaveData data = new GameSaveData(currentScore, currentName, currentTimePlayed);
		BinaryFormatter bf = new BinaryFormatter();
		//bf.Serialize(file, data);
		file.Close();
	}

	public void LoadFile()
	{
		string destination = Application.persistentDataPath + "/save.dat";
		FileStream file;

		if (File.Exists(destination)) file = File.OpenRead(destination);
		else
		{
			Debug.LogError("File not found");
			return;
		}

		BinaryFormatter bf = new BinaryFormatter();
		GameSaveData data = (GameSaveData)bf.Deserialize(file);
		file.Close();

		//currentScore = data.score;
		//currentName = data.name;
		//currentTimePlayed = data.timePlayed;

		//Debug.Log(data.name);
		//Debug.Log(data.score);
		//Debug.Log(data.timePlayed);
	}

}

