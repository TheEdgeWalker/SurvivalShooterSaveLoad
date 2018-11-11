using System;
using UnityEngine;

[Serializable]
public class SerializableTransform : SerializableObject<Transform>
{
	public float[] position;
	public float[] rotation;

	public SerializableTransform()
	{
	}

	public SerializableTransform(Transform transform)
	{
		Serialize(transform);
	}

	public override void Serialize(Transform transform)
	{
		position = Vector3ToArray(transform.position);
		rotation = QuaternionToArray(transform.rotation);
	}

	public override void Deserialize(Transform transform)
	{
		transform.position = ArrayToVector3(position);
		transform.rotation = ArrayToQuaternion(rotation);
	}

	private float[] Vector3ToArray(Vector3 vector)
	{
		float[] array = new float[3];

		array[0] = vector.x;
		array[1] = vector.y;
		array[2] = vector.z;

		return array;
	}

	private float[] QuaternionToArray(Quaternion quaternion)
	{
		float[] array = new float[4];

		array[0] = quaternion.x;
		array[1] = quaternion.y;
		array[2] = quaternion.z;
		array[3] = quaternion.w;

		return array;
	}

	private Vector3 ArrayToVector3(float[] array)
	{
		if (array.Length != 3)
		{
			Debug.LogError("Array size is not 3");
			return Vector3.zero;
		}

		return new Vector3(array[0], array[1], array[2]);
	}

	private Quaternion ArrayToQuaternion(float[] array)
	{
		if (array.Length != 4)
		{
			Debug.LogError("Array size is not 4");
			return Quaternion.identity;
		}

		return new Quaternion(array[0], array[1], array[2], array[3]);
	}
}
