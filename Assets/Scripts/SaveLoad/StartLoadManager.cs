using CompleteProject;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class StartLoadManager : MonoBehaviour
{
	public Canvas canvas;
	public Button loadButton;

	private string path;

	private void Start()
	{
		Time.timeScale = 0f;

		path = Path.Combine(Application.dataPath, "SaveData/save.json");
		loadButton.enabled = File.Exists(path);
	}

	public void StartGame()
	{
		Time.timeScale = 1f;
		canvas.enabled = false;
	}

	public void Load()
	{
		ApplyGameData(LoadGameData());

		Time.timeScale = 1f;
		canvas.enabled = false;
	}

	private GameData LoadGameData()
	{
		StreamReader reader = new StreamReader(path);
		string json = reader.ReadToEnd();
		return JsonUtility.FromJson<GameData>(json);
	}

	private void ApplyGameData(GameData data)
	{
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		data.player.Deserialize(player);

		GameObject[] monsterPrefabs = Resources.LoadAll<GameObject>("Monsters");
		Dictionary<string, GameObject> monsterPrefabDictionary = new Dictionary<string, GameObject>(monsterPrefabs.Length);
		foreach (GameObject monsterPrefab in monsterPrefabs)
		{
			monsterPrefabDictionary.Add(monsterPrefab.name, monsterPrefab);
		}

		foreach (SerializableMonster monster in data.monsters)
		{
			GameObject monsterPrefab;
			if (monsterPrefabDictionary.TryGetValue(monster.name, out monsterPrefab))
			{
				GameObject newMonster = Instantiate(monsterPrefab);
				monster.Deserialize(newMonster);
			}
			else
			{
				Debug.LogError("Failed to Instantiate monster: " + monster.name);
			}
		}
	}
}
