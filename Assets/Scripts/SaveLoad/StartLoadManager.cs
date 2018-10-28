using CompleteProject;
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
	}
}
