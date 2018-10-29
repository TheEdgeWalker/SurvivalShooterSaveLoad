using System;
using UnityEngine;

[Serializable]
public class SerializableGameObject : SerializableObject<GameObject>
{
	public SerializableTransform transform;

	public SerializableGameObject(GameObject gameObject)
	{
		transform = new SerializableTransform(gameObject.transform);
	}

	public SerializableGameObject()
	{
	}

	public override void Deserialize(GameObject gameObject)
	{
		transform.Deserialize(gameObject.transform);
	}

	protected Serializable SerializeComponent<Serializable, Component>(GameObject gameObject)
	{
		Component component = gameObject.GetComponentInChildren<Component>();
		if (component != null)
		{
			return (Serializable)Activator.CreateInstance(typeof(Serializable), component);
		}

		Debug.LogError("SerializeComponent failed: " + typeof(Component));
		return default(Serializable);
	}

	protected void DeserializeComponent<Component>(GameObject gameObject, SerializableObject<Component> serializableObject)
	{
		Component component = gameObject.GetComponentInChildren<Component>();
		if (component != null)
		{
			serializableObject.Deserialize(component);
		}
		else
		{
			Debug.LogError("DeserializeComponent failed: " + typeof(Component));
		}
	}
}
