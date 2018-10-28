using CompleteProject;
using System;

[Serializable]
public class SerializableEnemyHealth : SerializableComponent<EnemyHealth>
{
	public int startingHealth;
	public int currentHealth;

	public SerializableEnemyHealth(EnemyHealth enemyHealth) : base(enemyHealth)
	{
	}

	protected override void Serialize(EnemyHealth enemyHealth)
	{
		startingHealth = enemyHealth.startingHealth;
		currentHealth = enemyHealth.currentHealth;
	}

	public override void Deserialize(EnemyHealth enemyHealth)
	{
		enemyHealth.SetHealth(startingHealth, currentHealth);
	}
}
