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

	public void Break() {
		if (!isBroken) {
			isBroken = true;
			StopCoroutine("ReformRoutine");
			model.gameObject.SetActive(false);
			breakEffect.Play();
			reformEffect.Stop();
		}
	}

	public void Reform() {
		if (isBroken) {
			isBroken = false;
			StartCoroutine("ReformRoutine");
		}
	}

	IEnumerator ReformRoutine() {
		model.gameObject.SetActive(true);
		Material mat = render.material;
		Color color = mat.color;
		reformEffect.Play();
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
