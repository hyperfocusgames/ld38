using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RandomPitchTweak : MonoBehaviour {

	public float tweakAmount = 0.05f;

	AudioSource audioSource;

	void Awake() {
		audioSource = GetComponent<AudioSource>();
		audioSource.pitch *= 1 + Random.Range(-tweakAmount, tweakAmount);
	}

}
