using System;
using UnityEngine;

[Serializable, ExecuteInEditMode]
public class GameObjectSerializer : MonoBehaviour
{
	public string guid;

	public bool shouldInstantiate = false;
	public string[] components;

	private void Awake()
	{
		if (string.IsNullOrEmpty(guid))
		{
			guid = Guid.NewGuid().ToString();
		}

		SerializeManager.Instance.Add(guid, gameObject);
	}

	public SerializableGameObject Serialize()
	{
		return new SerializableGameObject(gameObject, components);
	}

	public void Deserialize(SerializableGameObject serializable)
	{
		serializable.Deserialize(gameObject);
	}

	private void OnDestroy()
	{
		if (string.IsNullOrEmpty(guid))
		{
			Debug.LogError("GUID cannot be null or empty: " + name);
			return;
		}

		SerializeManager.Instance.Remove(guid);
	}
}
