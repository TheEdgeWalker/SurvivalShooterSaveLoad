using System;
using UnityEngine;

[Serializable]
public class GameData
{
	public SerializableGameObject player;
	public SerializableGameObject[] monsters;

	public GameData(GameObject player, GameObject[] monsters)
	{
		this.player = ConvertToSerializableGameObject(player);

		this.monsters = new SerializableGameObject[monsters.Length];
		for (int i = 0; i < monsters.Length; ++i)
		{
			this.monsters[i] = ConvertToSerializableGameObject(monsters[i]);
		}
	}

	private SerializableGameObject ConvertToSerializableGameObject(GameObject gameObject)
	{
		return new SerializableGameObject(gameObject);
	}
}
