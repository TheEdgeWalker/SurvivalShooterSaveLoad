using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SerializableGameObject
{
	public SerializableTransform transform;

	public SerializableGameObject(GameObject gameObject)
	{
		transform = new SerializableTransform(gameObject.transform);
	}
}
