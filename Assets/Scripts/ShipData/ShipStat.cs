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

}

public class ShipStatCollection<T> {

	public T moveSpeed;
	public T maxHealth;
	public T maxShields;
	public T shieldRechargeDelay;
	public T recoveryDelay;
	public T damage;
	public T fireDelay;

}

[Serializable]
public class ShipStatCollection : ShipStatCollection<ShipStat> {}