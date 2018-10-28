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
		ScoreManager.score = data.score;
		ApplyPlayer(data);
		ApplyMonsters(data);
		ApplyEnemyManagers(data);
	}

	private void ApplyPlayer(GameData data)
	{
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		data.player.Deserialize(player);
	}

	private void ApplyMonsters(GameData data)
	{
		GameObject[] monsterPrefabs = Resources.LoadAll<GameObject>("Monsters");
		Dictionary<string, GameObject> monsterPrefabDictionary = new Dictionary<string, GameObject>(monsterPrefabs.Length);
		foreach (GameObject monsterPrefab in monsterPrefabs)
		{
			monsterPrefabDictionary.Add(monsterPrefab.name, monsterPrefab);
		}

		foreach (SerializableMonster serializableMonster in data.monsters)
		{
			GameObject monsterPrefab;
			if (monsterPrefabDictionary.TryGetValue(serializableMonster.name, out monsterPrefab))
			{
				GameObject newMonster = Instantiate(monsterPrefab);
				serializableMonster.Deserialize(newMonster);
			}
			else
			{
				Debug.LogError("Failed to Instantiate monster: " + serializableMonster.name);
			}
		}
	}

	private void ApplyEnemyManagers(GameData data)
	{
		EnemyManager[] enemyManagers = GameObject.Find("EnemyManager").GetComponents<EnemyManager>();
		Dictionary<string, EnemyManager> enemyManagerDictionary = new Dictionary<string, EnemyManager>(enemyManagers.Length);
		foreach (EnemyManager enemyManager in enemyManagers)
		{
			enemyManagerDictionary.Add(enemyManager.enemy.name, enemyManager);
		}

		foreach (SerializableEnemyManager serializableEnemyManager in data.enemyManagers)
		{
			EnemyManager enemyManager;
			if (enemyManagerDictionary.TryGetValue(serializableEnemyManager.enemy, out enemyManager))
			{
				serializableEnemyManager.Deserialize(enemyManager);
			}
			else
			{
				Debug.LogError("Failed to Deserialize EnemyManager: " + serializableEnemyManager.enemy);
			}
		}
	}
}
