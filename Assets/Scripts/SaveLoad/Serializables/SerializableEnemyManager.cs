using CompleteProject;
using System;

[Serializable]
public class SerializableEnemyManager : SerializableObject<EnemyManager>
{
	public string enemy;
	public float time;
	
	public SerializableEnemyManager(EnemyManager enemyManager)
	{
		enemy = enemyManager.enemy.name;
		time = enemyManager.time;
	}

	public override void Deserialize(EnemyManager enemyManager)
	{
		enemyManager.AdvanceTime(time);
	}
}
