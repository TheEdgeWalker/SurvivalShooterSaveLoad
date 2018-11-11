using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SerializableGameObject : SerializableObject<GameObject>
{
	public string guid;
	public SerializableObject[] serializableObjects;

	public SerializableGameObject(GameObject gameObject)
	{
		PersistentID persistentID = gameObject.GetComponent<PersistentID>();
		if (persistentID == null)
		{
			Debug.LogError("Cannot serialize a GameObject that does not have PersistentID");
			return;
		}

		guid = persistentID.guid;

		List<SerializableObject> serializableObjects = new List<SerializableObject>();
		foreach (Component component in gameObject.GetComponents<Component>())
		{
			string serializableTypeName = "Serializable" + GetComponentName(component);
			Type type = Type.GetType(serializableTypeName, false);
			if (type != null)
			{
				Debug.Log(serializableTypeName);
				SerializableObject serializable = (SerializableObject)Activator.CreateInstance(type);
				serializable.Serialize(component);
				serializableObjects.Add(serializable);
			}
		}
		this.serializableObjects = serializableObjects.ToArray();
	}

	private string GetComponentName(Component component)
	{
		string fullName = component.GetType().ToString();
		string[] str = fullName.Split('.');
		if (str.Length > 1)
		{
			return str[str.Length - 1];
		}

		return str[0];
	}

	public override void Serialize(GameObject gameObject)
	{
	}

	public override void Deserialize(GameObject gameObject)
	{
	}
}
