using System;
using UnityEngine;

[Serializable]
public class GameObjectSerializer : MonoBehaviour
{
	public bool isInstantiated;
	public string[] components;

	private void Awake()
	{
	}
}
