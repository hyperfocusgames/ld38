using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour {

	public Transform model;
	public ParticleSystem breakEffect;
	public ParticleSystem reformEffect;


	public void Break() {
		model.gameObject.SetActive(false);
		breakEffect.Play();
	}

	public void Reform() {
		StartCoroutine(ReformRoutine());
	}

	IEnumerator ReformRoutine() {
		reformEffect.Play();
		yield return new WaitForSeconds(reformEffect.main.duration);
		model.gameObject.SetActive(true);
	}

}
