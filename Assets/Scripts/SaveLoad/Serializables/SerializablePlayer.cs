using CompleteProject;
using System;
using UnityEngine;

[Serializable]
public class SerializablePlayer : SerializableGameObject
{
	public SerializablePlayerHealth health;

	public SerializablePlayer(GameObject player) : base(player)
	{
		PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
		if (playerHealth)
		{
			health = new SerializablePlayerHealth(playerHealth);
		}
	}

	public override void Deserialize(GameObject gameObject)
	{
		base.Deserialize(gameObject);
		health.Deserialize(gameObject.GetComponent<PlayerHealth>());
	}
}
