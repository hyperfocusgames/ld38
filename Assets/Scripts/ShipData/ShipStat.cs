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

[System.Serializable]
public class FloatShipStat : ShipStat<float> {}
[System.Serializable]
public class IntShipStat : ShipStat<int> {}

public class MaxHealthStat : IntShipStat {}