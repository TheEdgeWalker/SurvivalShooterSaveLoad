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

	public void Add(string guid, GameObject gameObject)
	{
		Debug.LogFormat("SerializeManager.Add: {0}, {1}", guid, gameObject.name);
		gameObjects[guid] = gameObject;
	}

	public void Remove(string guid)
	{
		Debug.LogFormat("SerializeManager.Remove: {0}", guid);
		gameObjects.Remove(guid);
	}

	public GameObject GetGameObject(string guid)
	{
		GameObject ret;
		gameObjects.TryGetValue(guid, out ret);
		return ret;
	}
}
