using CompleteProject;
using System.IO;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
	public void Save()
	{
		int score = ScoreManager.score;
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		GameObject[] monsters = GameObject.FindGameObjectsWithTag("Monster");
		EnemyManager[] enemyManagers = GameObject.Find("EnemyManager").GetComponents<EnemyManager>();

		GameData data = new GameData(score, player, monsters, enemyManagers);

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
