using CompleteProject;
using System;

[Serializable]
public class SerializableEnemyManager : SerializableObject<EnemyManager>
{
	public string enemy;
	public float time;

	public SerializableEnemyManager()
	{
	}

	public SerializableEnemyManager(EnemyManager enemyManager)
	{
		Serialize(enemyManager);
	}

	public override void Serialize(EnemyManager enemyManager)
	{
		enemy = enemyManager.enemy.name;
		time = enemyManager.time;
	}

	public override void Deserialize(EnemyManager enemyManager)
	{
		enemyManager.AdvanceTime(time);
	}
}
