using System.Collections;
using System.Collections.Generic;

public interface IShipStat { }

public class ShipStat<T> : IShipStat {

	public T baseValue; 

	public T value {
		get {
			return baseValue;
		}
	}

}

[System.Serializable] public class FloatShipStat : ShipStat<float> {}
[System.Serializable] public class IntShipStat : ShipStat<int> {}

[System.Serializable] public class MaxHealthShipStat : IntShipStat {}
[System.Serializable] public class MoveSpeedShipStat : FloatShipStat {}
[System.Serializable] public class DamageRateShipStat : IntShipStat {}
[System.Serializable] public class FireRateShipStat : FloatShipStat {}
[System.Serializable] public class ShieldCountShipStat : IntShipStat {}
[System.Serializable] public class ShieldRechargeRateShipStat : FloatShipStat {}