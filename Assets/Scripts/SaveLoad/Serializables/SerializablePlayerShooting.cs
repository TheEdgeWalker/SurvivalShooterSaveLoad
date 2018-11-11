using CompleteProject;
using System;

[Serializable]
public class SerializablePlayerShooting : SerializableObject<PlayerShooting>
{
	public bool areEffectsEnabled = false;
	public float time;

	public SerializablePlayerShooting()
	{
	}

	public SerializablePlayerShooting(PlayerShooting playerShooting)
	{
		Serialize(playerShooting);
	}

	public override void Serialize(PlayerShooting playerShooting)
	{
		areEffectsEnabled = playerShooting.AreEffectsEnabled();
		time = playerShooting.time;
	}

	public override void Deserialize(PlayerShooting playerShooting)
	{
		if (areEffectsEnabled)
		{
			playerShooting.EnableEffects(time);
		}
	}
}
