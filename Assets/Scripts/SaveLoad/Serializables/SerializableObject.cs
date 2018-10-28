using UnityEngine;

public abstract class SerializableObject<T>
{
	public abstract void Deserialize(T t);
}
