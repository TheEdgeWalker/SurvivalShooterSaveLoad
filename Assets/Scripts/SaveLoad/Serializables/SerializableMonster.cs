using System;
using UnityEngine;

[Serializable]
public class SerializableMonster : SerializableGameObject
{
	public SerializableMonster(GameObject monster) : base(monster)
	{
	}
}
