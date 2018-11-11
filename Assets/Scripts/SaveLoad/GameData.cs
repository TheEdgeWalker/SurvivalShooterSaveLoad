using CompleteProject;
using System;
using UnityEngine;

[Serializable]
public class GameData
{
	public SerializableGameObject[] gameObjects;

	public GameData()
	{
		gameObjects = SerializeManager.Instance.GetSerializableGameObjects();
	}
}
