using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class WarpFlash : SingletonBehaviour<WarpFlash> {

	public Color color;
	public float fadeDuration = 2;

	Image image;
	float t;

	void Awake() {
		image = GetComponent<Image>();
		t = fadeDuration;
	}

	public void Flash() {
		t = 0;
	}

	void Update() {
		t += Time.deltaTime;
		Color transparent = color;
		transparent.a = 0;
		image.color = Color.Lerp(color, transparent, t / fadeDuration);
	}


}
