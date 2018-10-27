using System;
using UnityEngine;

[Serializable]
public class GameData
{
	public SerializablePlayer player;
	public SerializableMonster[] monsters;

	public GameData(GameObject player, GameObject[] monsters)
	{
		this.player = new SerializablePlayer(player);

		this.monsters = new SerializableMonster[monsters.Length];
		for (int i = 0; i < monsters.Length; ++i)
		{
			this.monsters[i] = new SerializableMonster(monsters[i]);
		}
	}
}
