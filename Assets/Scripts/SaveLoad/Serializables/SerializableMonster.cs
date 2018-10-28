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

		health = SerializeComponent<SerializableEnemyHealth, EnemyHealth>(monster);
	}

	public override void Deserialize(GameObject monster)
	{
		base.Deserialize(monster);

		DeserializeComponent(monster, health);
		health.Deserialize(monster.GetComponent<EnemyHealth>());
	}
}
