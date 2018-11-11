using System;
using UnityEngine;

[ExecuteInEditMode]
public class PersistentID : MonoBehaviour
{
	[ShowOnly]
	public string guid;

	private void Awake()
	{
		if (string.IsNullOrEmpty(guid))
		{
			guid = Guid.NewGuid().ToString();
		}

		SerializeManager.Instance.Add(this);
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
