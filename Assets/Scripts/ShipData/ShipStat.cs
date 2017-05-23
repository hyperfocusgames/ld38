using System;
using System.Collections;
using System.Collections.Generic;


[Serializable]
public class ShipStat {

	public float baseValue; 

	public float value {
		get {
			return baseValue;
		}
	}

	public static implicit operator float(ShipStat stat) {
		return stat.value;
	}

	public static IEnumerable<ShipStatID> allIDs {
		get {
			return Enum.GetValues(typeof(ShipStatID)) as ShipStatID[];
		}
	}
}

public enum ShipStatID {
	MoveSpeed,
	MaxHealth,
	MaxShields,
	ShieldRechargeDelay,
	RecoveryDelay,
	Damage,
	FireDelay
}

public class ShipStatCollection<T> {

	public T moveSpeed;
	public T maxHealth;
	public T maxShields;
	public T shieldRechargeDelay;
	public T recoveryDelay;
	public T damage;
	public T fireDelay;

	public T this[ShipStatID id] {
		get {
			switch (id) {
				case ShipStatID.MoveSpeed:
					return moveSpeed;
				case ShipStatID.MaxHealth:
					return maxHealth;
				case ShipStatID.MaxShields:
					return maxShields;
				case ShipStatID.ShieldRechargeDelay:
					return shieldRechargeDelay;
				case ShipStatID.RecoveryDelay:
					return recoveryDelay;
				case ShipStatID.Damage:
					return damage;
				case ShipStatID.FireDelay:
					return fireDelay;
			}
			return default(T);
		}
		set {
			switch (id) {
				case ShipStatID.MoveSpeed:
					moveSpeed = value;
					break;
				case ShipStatID.MaxHealth:
					maxHealth = value;
					break;
				case ShipStatID.MaxShields:
					maxShields = value;
					break;
				case ShipStatID.ShieldRechargeDelay:
					shieldRechargeDelay = value;
					break;
				case ShipStatID.RecoveryDelay:
					recoveryDelay = value;
					break;
				case ShipStatID.Damage:
					damage = value;
					break;
				case ShipStatID.FireDelay:
					fireDelay = value;
					break;
			}

		}
	}

}

[Serializable]
public class ShipStatCollection : ShipStatCollection<ShipStat> {}