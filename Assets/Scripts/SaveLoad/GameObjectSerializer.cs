using System;
using UnityEngine;

[Serializable, ExecuteInEditMode]
public class GameObjectSerializer : MonoBehaviour
{
	[HideInInspector]
	public string id;

	public bool shouldInstantiate = false;
	public string[] components;

	private void Awake()
	{
		if (string.IsNullOrEmpty(id))
		{
			id = Guid.NewGuid().ToString();
		}
	}

	public SerializableGameObject Serialize()
	{
		return new SerializableGameObject(gameObject, components);
	}

	public void Deserialize(SerializableGameObject serializable)
	{
		serializable.Deserialize(gameObject);
	}
}
