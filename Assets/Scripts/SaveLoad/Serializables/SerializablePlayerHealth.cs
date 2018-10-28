using CompleteProject;
using System;

[Serializable]
public class SerializablePlayerHealth : SerializableObject<PlayerHealth>
{
	public int startingHealth;
	public int currentHealth;

	public SerializablePlayerHealth(PlayerHealth playerHealth)
	{
		startingHealth = playerHealth.startingHealth;
		currentHealth = playerHealth.currentHealth;
	}

	public override void Deserialize(PlayerHealth playerHealth)
	{
		playerHealth.SetHealth(startingHealth, currentHealth);
	}
}
