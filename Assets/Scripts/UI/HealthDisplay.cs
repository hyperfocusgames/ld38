using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HealthDisplay : MonoBehaviour {

	public Transform heartPrefab;

	public float margin = 1;
	public float spacing = 1;

	List<Transform> hearts;

	int _health;
	public int health {
		get {
			return _health;
		}
		set {
			if (_health != value) {
				_health = value;
				if (hearts.Count < value) {
					for (int i = hearts.Count; i < value; i ++) {
						Transform heart = Instantiate(heartPrefab);
						heart.name = heartPrefab.name;
						heart.transform.parent = transform;
						Vector3 position = transform.position;
						position += Vector3.right * (i * spacing);
						heart.transform.position = position;
						hearts.Add(heart);
					}
				}
				for (int i = 0; i < hearts.Count; i ++) {
					hearts[i].gameObject.SetActive(i < value);
				}
			}
		}
	}

	void Awake() {
		hearts = new List<Transform>();
	}

	void Update() {
		Camera camera = UI3D.instance.cam;
		transform.position = camera.transform.position + new Vector3 (
			(- camera.orthographicSize * camera.aspect) + margin,
			camera.orthographicSize - margin,
			camera.farClipPlane / 2
		);
		health = (int) PlayerData.player.hp;
	}

}
