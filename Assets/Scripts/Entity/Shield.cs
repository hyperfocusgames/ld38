using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour {

	public Transform model;
	public ParticleSystem breakEffect;
	public ParticleSystem reformEffect;
	
	public bool isBroken { get; private set; }

	Renderer render;
	float matAlpha;

	void Awake() {
		render = model.GetComponent<Renderer>();
		matAlpha = render.material.color.a;
	}

	public void Hit() {
		breakEffect.Play();
	}

	public void Break() {
		isBroken = true;
		StopCoroutine("ReformRoutine");
		model.gameObject.SetActive(false);
		reformEffect.Stop();
	}

	public void Reform() {
		StartCoroutine("ReformRoutine");
	}

	IEnumerator ReformRoutine() {
		reformEffect.Play();
		if (isBroken) {
			isBroken = false;
			model.gameObject.SetActive(true);
			Material mat = render.material;
			Color color = mat.color;
			float duration = reformEffect.main.duration;
			float t = 0;
			while (t < duration) {
				t += Time.deltaTime;
				color.a = matAlpha * (t / duration);
				mat.color = color;
				render.material = mat;
				yield return null;
			}
		}
	}

}
