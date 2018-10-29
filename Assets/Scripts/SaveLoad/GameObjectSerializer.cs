using System;
using UnityEngine;

[Serializable]
public class GameObjectSerializer : MonoBehaviour
{
	public bool shouldInstantiate = false;
	public string[] components;

	public SerializableGameObject Serialize()
	{
		SerializableGameObject serializable = new SerializableGameObject();
		return serializable;
	}

	public void Deserialize(SerializableGameObject serializable)
	{

	}
}
