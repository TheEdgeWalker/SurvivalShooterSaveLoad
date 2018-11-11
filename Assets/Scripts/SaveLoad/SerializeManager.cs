using System;
using System.Collections.Generic;
using UnityEngine;

public class SerializeManager
{
	private static SerializeManager instance = null;
	public static SerializeManager Instance
	{
		get
		{
			if (instance == null)
			{
				instance = new SerializeManager();
			}

			return instance;
		}
	}

	private Dictionary<string, GameObject> gameObjects = new Dictionary<string, GameObject>();

	private SerializeManager()
	{
	}

	public void Add(PersistentID persistentID)
	{
		Debug.LogFormat("SerializeManager.Add: {0}, {1}", persistentID.guid, persistentID.name);
		gameObjects[persistentID.guid] = persistentID.gameObject;
	}

	public void Remove(string guid)
	{
		Debug.LogFormat("SerializeManager.Remove: {0}", guid);
		gameObjects.Remove(guid);
	}

	public GameObject GetGameObject(string guid)
	{
		GameObject gameObject;
		gameObjects.TryGetValue(guid, out gameObject);
		return gameObject;
	}

	public SerializableGameObject[] GetSerializableGameObjects()
	{
		SerializableGameObject[] serialized = new SerializableGameObject[gameObjects.Count];
		int i = 0;
		foreach (KeyValuePair<string, GameObject> entry in gameObjects)
		{
			serialized[i] = new SerializableGameObject(entry.Value);
		}
		return serialized;
	}
}
