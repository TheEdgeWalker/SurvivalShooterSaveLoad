using System;
using UnityEngine;

public abstract class SerializableObject
{
	public abstract void Serialize(object obj);
	public abstract void Deserialize(object obj);
}

public abstract class SerializableObject<T> : SerializableObject
{
	public abstract void Serialize(T t);
	public abstract void Deserialize(T t);

	public override void Serialize(object obj)
	{
		if (obj.GetType().IsAssignableFrom(typeof(T)))
		{
			Serialize((T)obj);
		}
		else
		{
			Debug.Log("Cannot Serialize: " + obj.GetType());
		}
	}

	public override void Deserialize(object obj)
	{
		if (obj.GetType().IsAssignableFrom(typeof(T)))
		{
			Deserialize((T)obj);
		}
		else
		{
			Debug.Log("Cannot Deserialize: " + obj.GetType());
		}
	}
}
