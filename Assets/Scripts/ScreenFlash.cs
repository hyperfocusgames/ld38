using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ScreenFlash : SingletonBehaviour<ScreenFlash> {

	Color color;
	float duration = 0;

	Image image;
	float t;

	void Awake() {
		image = GetComponent<Image>();
		color = Color.clear;
		t = 0;
	}

	public void Flash(Color color, float duration) {
		this.color = color;
		this.duration = duration;
		t = 0;
	}

	void Update() {
		t += Time.deltaTime;
		Color transparent = color;
		transparent.a = 0;
		image.color = Color.Lerp(color, transparent, t / duration);
	}


}
