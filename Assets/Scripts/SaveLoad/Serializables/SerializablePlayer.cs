using CompleteProject;
using System;
using UnityEngine;

[Serializable]
public class SerializablePlayer : SerializableGameObject
{
	public SerializablePlayerHealth health;
	public SerializablePlayerShooting shooting;

	public SerializablePlayer(GameObject player) : base(player)
	{
		health = SerializeComponent<SerializablePlayerHealth, PlayerHealth>(player);
		shooting = SerializeComponent<SerializablePlayerShooting, PlayerShooting>(player);
	}

	public override void Deserialize(GameObject player)
	{
		base.Deserialize(player);

		DeserializeComponent(player, health);
		DeserializeComponent(player, shooting);
	}
}
