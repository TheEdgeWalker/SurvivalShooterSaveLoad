using System.Collections;
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

		StreamWriter writer = new StreamWriter("Assets/SaveData/save.json", false);
		writer.Write(json);
		writer.Close();

		Debug.Log("End Save");
	}
}
