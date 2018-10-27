﻿using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
	public void Save()
	{
		Debug.Log("Start Save");

		GameObject player = GameObject.FindGameObjectWithTag("Player");
		GameObject[] monsters = GameObject.FindGameObjectsWithTag("Monster");
		GameData data = new GameData(player, monsters);

		string json = JsonUtility.ToJson(data);

		string path = Path.Combine(Application.dataPath, "SaveData");
		if (!Directory.Exists(path))
		{
			Directory.CreateDirectory(path);
		}

		StreamWriter writer = new StreamWriter(path + "/save.json", false);
		writer.Write(json);
		writer.Close();

		Debug.Log("End Save");
	}
}
