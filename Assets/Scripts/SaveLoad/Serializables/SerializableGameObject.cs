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

	public override void Deserialize(GameObject gameObject)
	{
		transform.Deserialize(gameObject.transform);
	}
}
