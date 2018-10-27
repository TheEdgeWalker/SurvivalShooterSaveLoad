using UnityEngine;

public abstract class SerializableComponent<T>
{
	public SerializableComponent(T component)
	{
		Serialize(component);
	}

	protected abstract void Serialize(T component);
	public abstract void Deserialize(T component);
}
