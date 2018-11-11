using CompleteProject;
using System.IO;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
	public void Save()
	{
		GameData data = new GameData();

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
