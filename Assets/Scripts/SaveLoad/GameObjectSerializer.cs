using System;
using UnityEngine;

[Serializable]
public class GameObjectSerializer : MonoBehaviour
{
	public bool shouldInstantiate = false;
	public string[] components;

	public SerializableGameObject Serialize()
	{
		return new SerializableGameObject(gameObject, components);
	}

	public void Deserialize(SerializableGameObject serializable)
	{
		serializable.Deserialize(gameObject);
	}
}
