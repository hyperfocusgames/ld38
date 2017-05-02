using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// base class for planet terrain generation modules
// modules do nothing without an instance of PlanetGenerator present on the planet
public abstract class GenerationModule : MonoBehaviour {

	PlanetGenerator _generator;
	public PlanetGenerator generator {
		get {
			if (_generator == null) {
				_generator = GetComponent<PlanetGenerator>();
			}
			return _generator;
		}
	}

	public virtual Planet planet {
		get {
			return generator.planet;
		}
	}

	// override this method to specify generation behaviour
	public abstract void Generate();	

	// try to spawn and place a prop, keep trying until it succeeds. only use this when you know it wont take forever
	public T EnsurePropSpawn<T>(T prefab, System.Func<Vector3> position) where T : TerrainProp {
			T prop = null;
			int tries = 500;	// after this many tries, give up and return null
			do {
				prop = Instantiate(prefab);
				prop.name = prefab.name;
				tries --;
			} while(tries > 0 && !PlaceProp(prop, position()));
			return prop;
	}
	public T EnsurePropSpawn<T>(T prefab) where T : TerrainProp { return EnsurePropSpawn(prefab, () => Random.onUnitSphere); }

	// try to place a prop at a position on the planet (position in planetary local space)
	// if there is not enough space, destroy the prop and return false
	// return true if prop is succesfully placed
	public bool PlaceProp(TerrainProp prop, Vector3 position) {
			position = position.normalized * planet.radius;
			if (Physics.CheckSphere(planet.transform.position + position, prop.exclusionRadius, generator.propMaskLayers)) {
				Destroy(prop.gameObject);
				return false;
			}
			prop.transform.parent = planet.transform;
			prop.transform.localPosition = position;
			prop.planet = planet;
			foreach (TerrainProp p in generator.props) {
				float distance = Vector3.Distance(p.transform.position, prop.transform.position);
				if (distance < (p.exclusionRadius + prop.exclusionRadius)) {
					Destroy(prop.gameObject);
					return false;
				}
			}
			generator.props.Add(prop);
			// randomize facing direction
			Vector3 normal = prop.transform.localPosition.normalized;
			Vector3 forward = Vector3.ProjectOnPlane(Random.onUnitSphere, normal);
			prop.transform.LookAt(prop.transform.position + forward, normal);
			return true;
	}

}
