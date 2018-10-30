public abstract class SerializableObject<T>
{
	public abstract void Serialize(T t);
	public abstract void Deserialize(T t);
}
