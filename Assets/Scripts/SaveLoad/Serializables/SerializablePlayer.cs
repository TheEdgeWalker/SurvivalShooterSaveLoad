using CompleteProject;
using System;
using UnityEngine;

[Serializable]
public class SerializablePlayer : SerializableGameObject
{
	public int health;

	public SerializablePlayer(GameObject player) : base(player)
	{
		PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
		if (playerHealth)
		{
			health = playerHealth.currentHealth;
		}
	}
}
