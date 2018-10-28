using CompleteProject;
using System;
using UnityEngine;

[Serializable]
public class GameData
{
	public int score;
	public SerializablePlayer player;
	public SerializableMonster[] monsters;
	public SerializableEnemyManager[] enemyManagers;

	public GameData(GameObject player, GameObject[] monsters, EnemyManager[] enemyManagers)
	{
		this.player = new SerializablePlayer(player);

		this.monsters = new SerializableMonster[monsters.Length];
		for (int i = 0; i < monsters.Length; ++i)
		{
			this.monsters[i] = new SerializableMonster(monsters[i]);
		}

		this.enemyManagers = new SerializableEnemyManager[enemyManagers.Length];
		for (int i = 0; i < enemyManagers.Length; ++i)
		{
			this.enemyManagers[i] = new SerializableEnemyManager(enemyManagers[i]);
		}
	}
}
