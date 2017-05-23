using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu]
public class UpgradeAsset : ScriptableObject {
	public UpgradeAssetShipStatModifierCollection statModifiers;
}

[Serializable]
public class UpgradeAssetShipStatModifier {
	public bool active;
	public float increment;
}

[Serializable]
public class UpgradeAssetShipStatModifierCollection : ShipStatCollection<UpgradeAssetShipStatModifier> {}