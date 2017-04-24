using UnityEngine;
using UnityEngine.Audio;
using System.Collections;
using System.Collections.Generic;

public class MusicManager : SingletonBehaviour<MusicManager> {

	public AudioClip mainMusic;
	public float menuEffectTransitionTime = 0.5f;

	AudioSource source;

	public AudioMixerSnapshot defaultSnapshot;
	public AudioMixerSnapshot menuEffectSnapshot;

	bool _menuEffectEnabled;
	public bool menuEffectEnabled {
		get {
			return _menuEffectEnabled;
		}
		set {
			if (value != _menuEffectEnabled) {
				_menuEffectEnabled = value;
				(value ? menuEffectSnapshot : defaultSnapshot).TransitionTo(menuEffectTransitionTime);
			}
		}
	}

	void Awake() {
		if (instance != this) {
			Destroy(gameObject);
		}
		DontDestroyOnLoad(gameObject);
		source = GetComponent<AudioSource>();
		source.clip = mainMusic;
	}

	public void SetCustomMusic(AudioClip music) {
		source.clip = music;
		source.Play();
	}

	public void ResetCustomMusic() {
		SetCustomMusic(mainMusic);
	}

}
