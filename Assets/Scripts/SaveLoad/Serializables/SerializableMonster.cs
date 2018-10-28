using CompleteProject;
using System;
using UnityEditor;
using UnityEngine;

[Serializable]
public class SerializableMonster : SerializableGameObject
{
	public string name;
	public SerializableEnemyHealth health;

	public SerializableMonster(GameObject monster) : base(monster)
	{
		name = monster.name;

		EnemyHealth enemyHealth = monster.GetComponent<EnemyHealth>();
		if (enemyHealth)
		{
			health = new SerializableEnemyHealth(enemyHealth);
		}
	}
}
