using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour {

	public Transform model;
	public ParticleSystem breakEffect;
	public ParticleSystem reformEffect;
	
	public bool isBroken { get; private set; }

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
		reformEffect.Play();
		yield return new WaitForSeconds(reformEffect.main.duration);
		model.gameObject.SetActive(true);
	}

}
