using CompleteProject;
using System.IO;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
	public void Save()
	{
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		GameObject[] monsters = GameObject.FindGameObjectsWithTag("Monster");
		EnemyManager[] enemyManagers = GameObject.Find("EnemyManager").GetComponents<EnemyManager>();

		GameData data = new GameData(player, monsters, enemyManagers);

		string json = JsonUtility.ToJson(data);

		string path = Path.Combine(Application.dataPath, "SaveData");
		if (!Directory.Exists(path))
		{
			Directory.CreateDirectory(path);
		}

		StreamWriter writer = new StreamWriter(path + "/save.json", false);
		writer.Write(json);
		writer.Close();
	}
}
